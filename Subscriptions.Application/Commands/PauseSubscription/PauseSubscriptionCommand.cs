using MediatR;

namespace Subscriptions.Application.Commands.PauseSubscription
{
    public class PauseSubscriptionCommand : IRequest<PauseSubscriptionCommandResponse>
    {
        public string SubscriptionId { get; set; }
    }
}