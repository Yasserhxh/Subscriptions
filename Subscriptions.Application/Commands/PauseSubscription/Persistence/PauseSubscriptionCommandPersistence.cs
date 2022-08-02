using System.Threading.Tasks;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.PauseSubscription.Persistence
{
    public interface IPauseSubscriptionCommandPersistence 
    {
        Task<Subscription> GetSubscription(string requestSubscriptionId);
        Task SetStatus(SubscriptionStatus paused);
    }
}