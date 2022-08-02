namespace Subscriptions.Contracts
{
    public class AddSubscriberMessage
    {
        public string AppId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}