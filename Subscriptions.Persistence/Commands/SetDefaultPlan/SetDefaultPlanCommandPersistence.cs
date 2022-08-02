using System.Threading.Tasks;
using Dapper;
using Subscriptions.Application.Commands.SetDefaultPlan.Persistence;
using Subscriptions.Application.Common.Interfaces;

namespace Subscriptions.Persistence.Commands.SetDefaultPlan
{
    public class SetDefaultPlanCommandPersistence : ISetDefaultPlanCommandPersistence
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public SetDefaultPlanCommandPersistence(IUnitOfWorkContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<bool> PlanExist(string name)
        {
            var sql = "select 1 from plan where name = @name";
            var con = _unitOfWorkContext.GetSqlConnection();
            var reader = await con.ExecuteReaderAsync(sql, new {name}, _unitOfWorkContext.GetTransaction());
            return reader.HasRows;
        }

        public Task SetDefaultPlan(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}