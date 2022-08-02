using MediatR;

namespace Subscriptions.Application.Commands.AddFeatureToPlan
{
    public class AddFeatureToPlanCommand : IRequest<AddFeatureToPlanResponse>
    {
        public string Description { get; set; }
        public string PlanName { get; set; }
    }
}