using MediatR;

namespace Subscriptions.Application.Queries.Offers.GetTimelinesDefinitions
{
    public class GetTimelinesDefinitionsQuery : IRequest<GetTimelinesDefinitionsQueryResponse>
    {
        public long OfferId { get; set; }
    }
}