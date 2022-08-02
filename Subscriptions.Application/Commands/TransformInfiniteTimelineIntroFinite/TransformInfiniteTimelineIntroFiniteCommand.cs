using MediatR;

namespace Subscriptions.Application.Commands.TransformInfiniteTimelineIntroFinite
{
    public class TransformInfiniteTimelineIntoFiniteCommand : IRequest<TransformInfiniteTimelineIntoFiniteResponse>
    {
        public string TimelineId { get; set; }
    }
}