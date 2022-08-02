using AutoMapper;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.AddFeatureToPlan.Mapping
{
    public class AddFeatureToPLanCommandProfile : Profile
    {
        public AddFeatureToPLanCommandProfile()
        {
            CreateMap<AddFeatureToPlanCommand, Feature>();
        }
    }
}