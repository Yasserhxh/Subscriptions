using FluentValidation;

namespace Subscriptions.Application.Commands.UpdatePlan
{
    public class UpdatePlanCommandValidator : AbstractValidator<UpdatePlanCommand>
    {
        public UpdatePlanCommandValidator()
        {
            RuleFor(x => x.AppId).NotNull();
        }
    }
}