using AutoMapper;
using Subscriptions.Domain.Entities;
using Subscriptions.Persistence.Commands.CreateSubscription.Contracts;

namespace Subscriptions.Persistence.Commands.CreateSubscription.Mapping
{
    public class GetOfferContractProfiles : Profile
    {
        public GetOfferContractProfiles()
        {
            CreateMap<GetOfferContract, Offer>();
            CreateMap<GetOfferContract, FinitePaidTimeLineDefinition>();
            CreateMap<GetOfferContract, FiniteFreeTimeLineDefinition>();
            CreateMap<GetOfferContract, InfiniteFreeTimeLineDefinition>();
            CreateMap<GetOfferContract, InfinitePaidTimelineDefinition>();
        }
    }
}