using FluentValidation;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Common.Validators
{
    public class FiniteFreeTimelineDefinitionValidator : AbstractValidator<FiniteFreeTimeLineDefinition>
    {
        public FiniteFreeTimelineDefinitionValidator()
        {
            RuleFor(x => x.Expiration)
                .SetValidator(new ExpirationValidator());
        }
    }
}