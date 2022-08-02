using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Subscriptions.Application.Commands.AddOfferToPlan.Persistence;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Persistence.Commands.AddOffer
{
    public class AddOfferPersistence : IAddOfferToPlanCommandPersistence
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public AddOfferPersistence(IUnitOfWorkContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }



        public async Task<long> AddOffer(long planId, Offer offer)
        {
            var con = _unitOfWorkContext.GetSqlConnection();
            var batch = new NpgsqlBatch(con);
            var insertOfferCmd = new NpgsqlBatchCommand(
                "insert into offer (plan_id,name, description) values (@planId,@name,@description);");
            insertOfferCmd.Parameters.AddRange(new object []
            {
                ("PlanId",planId),
                ("name",offer.Name),
                ("description",@offer.Description)
            });
            batch.BatchCommands.Add(insertOfferCmd);
            foreach (var timeLineDefinition in offer.TimeLineDefinitions)
            {
                var batchCmd = new NpgsqlBatchCommand
                {
                    CommandText = @"insert into timeline_definition (name, offer_id,repeat, time_span,
                                            auto_charging,amount,""order"",discriminator)
                                            values (@name, currval(offer_id_seq), @repeat, @time_span, @auto_charging
                                            , @amount, @order, @discriminator)"
                };
                
                batchCmd.Parameters.AddRange(new NpgsqlParameter []
                {
                    new ("name",timeLineDefinition.Name),
                    new ("plan_name",timeLineDefinition.Offer.Plan.Name),
                    new ("offer_name",offer.Name),
                    new ("order",timeLineDefinition.Order),
                    new ("discriminator",timeLineDefinition.TimeLineDefinitionType)
                });


                if (timeLineDefinition is PaidTimeLineDefinition paidTimeLineDefinition)
                {
                    batchCmd.Parameters.AddRange(new NpgsqlParameter []
                    {
                        new ("amount",paidTimeLineDefinition.Amount),
                        new ("auto_charging",paidTimeLineDefinition.AutoCharging)
                    });
                }


                if (timeLineDefinition is IFiniteTimeLineDefinition finiteTimeLineDefinition)
                {
                    batchCmd.Parameters.AddRange(new NpgsqlParameter []
                    {
                        new ("time_span",finiteTimeLineDefinition.Expiration.Period)
                    });
                }

                
            }
            batch.BatchCommands.Add(new NpgsqlBatchCommand()
            {
                CommandText = "select currval(offer_id_seq)"
            });
            var offerId = await batch.ExecuteScalarAsync();
            
            return (long) offerId!;
        }
    }
}