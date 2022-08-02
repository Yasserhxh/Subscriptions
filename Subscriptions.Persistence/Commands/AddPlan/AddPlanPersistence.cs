using System.Threading.Tasks;
using Dapper;
using Subscriptions.Application.Commands.CreatePlan.Persistence;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Persistence.Commands.AddPlan
{
    public class AddPlanPersistence : IAddPlanCommandPersistence
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public AddPlanPersistence(IUnitOfWorkContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }


        public async Task AddPlan(Plan plan)
        {
            var sql = "insert into plan (name,description) values (@name,@description)";
            var con = _unitOfWorkContext.GetSqlConnection();
            await con.ExecuteAsync(sql, new
            {
                plan.Description,
                plan.Name
            },_unitOfWorkContext.GetTransaction());        }
    }
}