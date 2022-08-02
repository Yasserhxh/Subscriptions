using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Subscriptions.Application.Queries.Plans.GetPlans
{ 
    public class GetPlansQueryHandler : IRequestHandler<GetPlanQuery,GetPlansQueryResponse>
    {
        public Task<GetPlansQueryResponse> Handle(GetPlanQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}