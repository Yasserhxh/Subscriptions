using AutoMapper;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.AddOfferToPlan.Mapping
{
    public class AddOfferToPlanCommandProfile : Profile
    {
        public AddOfferToPlanCommandProfile()
        {
            CreateMap<AddOfferToPlanCommand, Offer>();
        }
    }
}