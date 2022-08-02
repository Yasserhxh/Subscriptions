using MediatR;

namespace Subscriptions.Application.Commands.SetDefaultOfferForPlan
{
    public class SetDefaultOfferForPlanCommand : IRequest
    {
        public long? AppId { get; set; }
        public string PlanName { get; set; } 
        public string OfferName { get; set; }
    }
}