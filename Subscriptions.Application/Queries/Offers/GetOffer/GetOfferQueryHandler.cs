using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Queries.Offers.GetOffer.Persistence;

namespace Subscriptions.Application.Queries.Offers.GetOffer
{
    public class GetOfferQueryHandler : IRequestHandler<GetOfferQuery,GetOfferQueryResponse>
    {
        private readonly IGetOfferQueryPersistence _getOfferQueryPersistence;
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public GetOfferQueryHandler(IGetOfferQueryPersistence getOfferQueryPersistence,IUnitOfWorkContext unitOfWorkContext)
        {
            _getOfferQueryPersistence = getOfferQueryPersistence;
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<GetOfferQueryResponse> Handle(GetOfferQuery request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = await _unitOfWorkContext.CreateUnitOfWork();
            await unitOfWork.BeginWork();
            try
            {
                return new GetOfferQueryResponse()
                {
                    Offer = await _getOfferQueryPersistence.GetOffer(request.Id)
                };
            }catch (Exception)
            {
                await unitOfWork.RollBack();
                throw;
            }
        }
    }
}