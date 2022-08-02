using FluentValidation;

namespace Subscriptions.Application.Commands.AddStripePaymentMethod
{
    public class AddStripePaymentMethodCommandValidator : AbstractValidator<AddStripePaymentMethodCommand>
    {
        public AddStripePaymentMethodCommandValidator()
        {
            RuleFor(x => x.SubscriberId)
                .NotNull();
            RuleFor(x => x.PaymentMethodId)
                .NotNull();
        }
    }
}