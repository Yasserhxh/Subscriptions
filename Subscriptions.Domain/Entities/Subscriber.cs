using System.Collections.Generic;

namespace Subscriptions.Domain.Entities
{
    public class Subscriber
    {
       
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public List<PaymentMethod> PaymentMethods { get; set; }
        public PaymentMethod DefaultPaymentMethod { get; set; }
        public string Email { get; set; }
    }
}