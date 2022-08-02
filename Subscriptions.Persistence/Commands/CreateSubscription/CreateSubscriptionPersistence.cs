using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Npgsql;
using Subscriptions.Application.Commands.CreateSubscription.Persistence;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Domain.Entities;
using Subscriptions.Persistence.Commands.CreateSubscription.Contracts;

namespace Subscriptions.Persistence.Commands.CreateSubscription
{
    public class CreateSubscriptionPersistence : ICreateSubscriptionCommandPersistence
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;
        private readonly IMapper _mapper;

        public CreateSubscriptionPersistence(IUnitOfWorkContext unitOfWorkContext,IMapper mapper)
        {
            _unitOfWorkContext = unitOfWorkContext;
            _mapper = mapper;
        }

        public async Task<Offer> GetOffer(long id)
        {
            var sql = @"select o.name,o.description,t.*
                        from offer as o inner join timeline_definition as t on
                        o.id = t.offer_id
                        where o.id = @id";
            var con = _unitOfWorkContext.GetSqlConnection();
            var rows = (await con.QueryAsync<GetOfferContract>(sql, new
            {
                id
            })).ToList();
            if (rows.Any())
            {
                var offer = new Offer();
                var firstRow = rows.First();
                _mapper.Map(firstRow, offer);
                foreach (var row in rows)
                {
                    switch (row.Discriminator)
                    {
                        case TimelineDefinitionType.InfinitePaidTimelineDefinition :
                            offer.AddTimelineDefinition(_mapper.Map<InfinitePaidTimelineDefinition>(row));
                            break;
                        case TimelineDefinitionType.FiniteFreeTimeLineDefinition :
                            offer.AddTimelineDefinition(_mapper.Map<FiniteFreeTimeLineDefinition>(row));
                            break;
                        case TimelineDefinitionType.FinitePaidTimeLineDefinition:
                            offer.AddTimelineDefinition(_mapper.Map<FinitePaidTimeLineDefinition>(row));
                            break;
                        case TimelineDefinitionType.InfiniteFreeTimeLineDefinition:
                            offer.AddTimelineDefinition(_mapper.Map<InfiniteFreeTimeLineDefinition>(row));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                return offer;
            }

            return null;
        }

        public async Task<long> AddSubscription(Subscription subscription)
        {
            var con = _unitOfWorkContext.GetSqlConnection();
            var batch = new NpgsqlBatch(con);
            var insertSubCmd = new NpgsqlBatchCommand()
            {
                CommandText = @"insert into subscription (subscriber_id, offer_id,status) 
                                values (@subscriberId,@offerId,@status)"
            };
             insertSubCmd.Parameters.AddRange(new object []
             {
                 ("subscriber_id",subscription.Subscriber.Id),
                 ("plan_name",subscription.Offer.Plan.Name),
                 ("offerId",subscription.Offer.Id),
             });

            foreach (var timeLine in subscription.TimeLines)
            {
                var insertTimelineCmd = new NpgsqlBatchCommand
                {
                    CommandText = @"insert into timeline (during,timeline_definition_id
                        , subscription_id,paid,amount, discriminator) 
                        values ('[@start,@end]', @timeline_definition_id ,currval(subscription_id_seq)
                        , @paid, @amount, @discriminator)"
                };
                insertTimelineCmd.Parameters.AddRange(new object []
                    {
                        ("timeline_definition_id",timeLine.TimeLineDefinition.Id), 
                        ("offer_name",timeLine.TimeLineDefinition.Offer.Name),
                        ("plan_name",timeLine.TimeLineDefinition.Offer.Plan.Name),
                        ("start",timeLine.DateTimeRange.Start.ToString("h:mm:ss tt zz")),
                        ("end",(timeLine is IInfiniteTimeLine
                            ? "infinity"
                            : timeLine.DateTimeRange.End?.ToString("h:mm:ss tt zz")!) ?? string.Empty),
                    });
                
                if (timeLine is PaidTimeLine paidTimeLine )
                {
                    
                   insertTimelineCmd.Parameters.AddRange(new object[]
                   {
                       ("paid",paidTimeLine.Paid),
                       ("amount",paidTimeLine.Amount)
                   });
                    
                }
                batch.BatchCommands.Add(new NpgsqlBatchCommand()
                {
                    CommandText = "select currval(subscription_id_seq)"
                });
                batch.BatchCommands.Add(insertTimelineCmd);     

            }

            return (long) (await batch.ExecuteScalarAsync())!;
        }


    }
}