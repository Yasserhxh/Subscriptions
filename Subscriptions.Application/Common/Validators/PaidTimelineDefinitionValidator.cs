using FluentValidation;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Common.Validators
{
    public class PaidTimelineDefinitionValidator : AbstractValidator<PaidTimeLineDefinition>
    {
        public PaidTimelineDefinitionValidator()
        {
            RuleFor(x => x.Amount)
                .NotNull();
            
        }
    }
}