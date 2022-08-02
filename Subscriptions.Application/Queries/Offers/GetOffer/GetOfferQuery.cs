using MediatR;
using Subscriptions.Application.Queries.Plans.GetPlans;

namespace Subscriptions.Application.Queries.Offers.GetOffer
{
    public class GetOfferQuery : IRequest<GetOfferQueryResponse>
    {
        public long Id { get; set; }
    }
}