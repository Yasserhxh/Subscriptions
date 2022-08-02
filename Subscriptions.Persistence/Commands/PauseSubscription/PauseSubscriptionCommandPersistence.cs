using System.Threading.Tasks;
using Dapper;
using Subscriptions.Application.Commands.PauseSubscription.Persistence;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Persistence.Commands.PauseSubscription
{
    public class PauseSubscriptionCommandPersistence : IPauseSubscriptionCommandPersistence
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public PauseSubscriptionCommandPersistence(IUnitOfWorkContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<Subscription> GetSubscription(string id)
        {
            var sql = "select * from subscription where id = @id";
            var con = _unitOfWorkContext.GetSqlConnection();
            return await con.QueryFirstOrDefaultAsync<Subscription>(sql, new {id}, _unitOfWorkContext.GetTransaction());
        }

        public Task SetStatus(SubscriptionStatus paused)
        {
            throw new System.NotImplementedException();
        }
    }
}