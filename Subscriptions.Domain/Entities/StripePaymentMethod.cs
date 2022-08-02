namespace Subscriptions.Domain.Entities
{
    public class StripePaymentMethod : PaymentMethod
    {
        public string StripePaymentMethodId { get; set; }

        public StripePaymentMethod(string id, Subscriber subscriber, string stripePaymentMethodId) : base(id, subscriber)
        {
            StripePaymentMethodId = stripePaymentMethodId;
            Platform = Platform.Stripe;
        }
    }
}