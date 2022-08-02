using FluentValidation;
using Subscriptions.Domain.Common;

namespace Subscriptions.Application.Common.Validators
{
    public class ExpirationValidator : AbstractValidator<TimelineExpiration>
    {
        public ExpirationValidator()
        {
             
        }
    }
}