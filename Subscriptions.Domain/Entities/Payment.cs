namespace Subscriptions.Domain.Entities
{
    public class Payment
    {
        public Payment(string id)
        {
            Id = id;
            Status = PaymentStatus.Processing;
        }

        public Payment(string id ,PaymentStatus status) 
        {
            Id = id;
            Status = status;
        }

        public string Id { get; set; }
        public PaymentStatus Status { get; set; }
    }

    public enum PaymentStatus
    {
        Processing,
        Failed,
        Succeeded
    }

  
}