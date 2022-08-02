using FluentValidation;

namespace Subscriptions.Application.Commands.PauseSubscription
{
    public class PauseSubscriptionCommandValidator : AbstractValidator<PauseSubscriptionCommand>
    {
        public PauseSubscriptionCommandValidator()
        {
            RuleFor(x => x.SubscriptionId)
                .NotNull();
        }
    }
}