using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Subscriptions.Application.Common.Interfaces;

using Subscriptions.Application.Queries.Offers.GetTimelinesDefinitions;
using Subscriptions.Application.Queries.Offers.GetTimelinesDefinitions.Persistence;

namespace Subscriptions.Persistence.Queries.Offers.GetTimelinesDefinitions
{
    public class GetTimelinesDefinitionsPersistence : IGetTimelinesDefinitionsPersistence
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public GetTimelinesDefinitionsPersistence(IUnitOfWorkContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<List<TimelineDefinitionDto>> GetTimelinesDefinitions(long offerId)
        {
            var sql = @"select * from timeline_definition where offer_id = @offerId";
            var con = _unitOfWorkContext.GetSqlConnection();
            return (await con.QueryAsync<TimelineDefinitionDto>(sql, new
            {
                offerId
            })).ToList();
        }
    }
}