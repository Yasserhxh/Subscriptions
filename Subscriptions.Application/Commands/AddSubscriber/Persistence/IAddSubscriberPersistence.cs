using System.Threading.Tasks;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.AddSubscriber.Persistence
{
    public interface IAddSubscriberPersistence
    {
        Task AddSubscriber(Subscriber subscriber);
    }
}