using AutoMapper;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.CreateSubscription.Mapping
{
    public class SubscriptionDtoProfile : Profile
    {
        public SubscriptionDtoProfile()
        {
            CreateMap<Subscription, SubscriptionDto>();
        }
    }
}