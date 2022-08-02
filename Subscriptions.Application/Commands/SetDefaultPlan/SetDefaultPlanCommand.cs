using MediatR;

namespace Subscriptions.Application.Commands.SetDefaultPlan
{
    public class SetDefaultPlanCommand : IRequest
    {
        public string PlanName { get; set; }
        public long? AppId { get; set; }
    }
}