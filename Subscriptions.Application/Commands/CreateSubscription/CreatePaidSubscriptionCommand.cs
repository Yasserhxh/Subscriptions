using MediatR;

namespace Subscriptions.Application.Commands.CreateSubscription
{
    public class CreateSubscriptionCommand : IRequest<CreateSubscriptionCommandResponse>
    {
        public long OfferId { get; set; }
        public string SubscriberId { get; set; }
    }
}