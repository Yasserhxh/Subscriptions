using FluentValidation;

namespace Subscriptions.Application.Commands.SetDefaultOfferForPlan
{
    public class SetDefaultOfferForPlanCommandValidator : AbstractValidator<SetDefaultOfferForPlanCommand>
    {
        public SetDefaultOfferForPlanCommandValidator()
        {
            RuleFor(x => x.AppId)
                .NotNull();
            RuleFor(x => x.OfferName)
                .NotEmpty();
            RuleFor(x => x.PlanName)
                .NotEmpty();
        }
    }
}