using MediatR;

namespace Subscriptions.Application.Commands.UpdatePlan
{
    public class UpdatePlanCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string NewName { get; set; }
        public string Description { get; set; }
        public long? AppId { get; set; }

    }
}