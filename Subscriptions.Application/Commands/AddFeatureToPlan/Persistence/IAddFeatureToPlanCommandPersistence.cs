using System.Threading.Tasks;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.AddFeatureToPlan.Persistence
{
    public interface IAddFeatureToPlanCommandPersistence
    {
        public Task AddFeatureToPlan(string planName, Feature feature);
        Task<bool> PlanExist(string planName);
    }
}