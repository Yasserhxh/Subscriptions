using MediatR;

namespace Subscriptions.Application.Queries.Plans.GetPlans
{
    public class GetPlanQuery : IRequest<GetPlansQueryResponse>
    {
        public long PlanId { get; set; }
    }
}