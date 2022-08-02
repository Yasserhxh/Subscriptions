using FluentValidation;

namespace Subscriptions.Application.Commands.TransformInfiniteTimelineIntroFinite
{
    public class TransformInfiniteTimelineIntroFiniteCommandValidator : AbstractValidator<TransformInfiniteTimelineIntoFiniteCommand>
    {
        public TransformInfiniteTimelineIntroFiniteCommandValidator()
        {
            RuleFor(x => x.TimelineId)
                .NotNull();
        }
    }
}