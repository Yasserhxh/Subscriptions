using AutoMapper;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.UpdatePlan.Mapping
{
    public class UpdatePlanCommandProfile : Profile
    {
        public UpdatePlanCommandProfile()
        {
            CreateMap<UpdatePlanCommand, Plan>();
        }
    }
}