using System.Threading.Tasks;
using Dapper;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Common.Persistence;

namespace Subscriptions.Persistence.Common
{
    public class SubscribersPersistence : ISubscribersPersistence
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public SubscribersPersistence(IUnitOfWorkContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<bool> SubscriberExist(string id)
        {
            var sql = "select 1 from subscriber where id= @id";
            var con = _unitOfWorkContext.GetSqlConnection();
            await using var reader = await con.ExecuteReaderAsync(sql, new { id}, _unitOfWorkContext.GetTransaction());
            return reader.HasRows;
        }
    }
}