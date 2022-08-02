using System.Threading.Tasks;
using Dapper;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Queries.Offers.GetOffer;
using Subscriptions.Application.Queries.Offers.GetOffer.Persistence;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Persistence.Queries.Offers.GetOffer
{
    public class GetOfferQueryPersistence : IGetOfferQueryPersistence
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public GetOfferQueryPersistence(IUnitOfWorkContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<OfferDto> GetOffer(long id)
        {
            var sql = @"select * from offer where id = @id";
            var con = _unitOfWorkContext.GetSqlConnection();
            return await con.QueryFirstOrDefaultAsync<OfferDto>(sql, new
            {
                id
            });
        }
    }
}