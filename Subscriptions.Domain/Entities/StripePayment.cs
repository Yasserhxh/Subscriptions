namespace Subscriptions.Domain.Entities
{
    public class StripePayment : Payment
    {
        public string PaymentIntentId { get; set; }

        public StripePayment(string id, string paymentIntentId) : base(id)
        {
            PaymentIntentId = paymentIntentId;
        }

        public StripePayment(string id, PaymentStatus status, string paymentIntentId) : base(id, status)
        {
            PaymentIntentId = paymentIntentId;
        }
    }
}