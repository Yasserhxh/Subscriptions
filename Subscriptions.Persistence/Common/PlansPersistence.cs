using System.Threading.Tasks;
using Dapper;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Common.Persistence;

namespace Subscriptions.Persistence.Common
{
    public class PlansPersistence : IPlansPersistence
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public PlansPersistence(IUnitOfWorkContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<bool> PlanExist(long planId)
        {
            var sql = "select 1 from plan where id = @planId";
            var con = _unitOfWorkContext.GetSqlConnection();
            await using var reader = await con.ExecuteReaderAsync(sql, new { planId}, _unitOfWorkContext.GetTransaction());
            return reader.HasRows;
        }
    }
}