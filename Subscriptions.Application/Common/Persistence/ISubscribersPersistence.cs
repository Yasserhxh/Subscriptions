using System.Threading.Tasks;

namespace Subscriptions.Application.Common.Persistence
{
    public interface ISubscribersPersistence
    {
        public Task<bool> SubscriberExist(string subscriberId);
    }
}