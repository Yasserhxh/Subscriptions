using MediatR;

namespace Subscriptions.Application.Commands.AddSubscriber
{
    public class AddSubscriberCommand : IRequest<Unit>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}