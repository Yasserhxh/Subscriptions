using FluentValidation;
using Subscriptions.Application.Commands.CreatePlan;

namespace Subscriptions.Application.Commands.AddPlan
{
    public class CreatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
    {
        public CreatePlanCommandValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty();

        }
    }
}