using FluentValidation;

namespace Subscriptions.Application.Commands.SetDefaultPlan
{
    public class SetDefaultPlanCommandValidator : AbstractValidator<SetDefaultPlanCommand>
    {
        public SetDefaultPlanCommandValidator()
        {
            RuleFor(x => x.AppId)
                .NotNull();
            RuleFor(x => x.PlanName)
                .NotEmpty();
        }
    }
}