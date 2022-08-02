namespace Subscriptions.Domain.Entities
{
    public class PaymentMethod
    {
        public PaymentMethod(string id, Subscriber subscriber)
        {
            Id = id;
            Subscriber = subscriber;
        }

        public string Id { get; set; }
        public Subscriber Subscriber { get; set; }
        public Platform Platform { get; set; }
    }

    public enum Platform
    {
        Stripe
    }
    
}