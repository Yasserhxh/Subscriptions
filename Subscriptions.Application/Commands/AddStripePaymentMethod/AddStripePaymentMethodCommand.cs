using MediatR;

namespace Subscriptions.Application.Commands.AddStripePaymentMethod
{
    public class AddStripePaymentMethodCommand : IRequest<AddStripePaymentMethodCommandResponse>
    {
        public string PaymentMethodId { get; set; }
        public string SubscriberId { get; set; }
    }
}