using System.Threading.Tasks;

namespace Subscriptions.Application.Commands.SetDefaultPlan.Persistence
{
    public interface ISetDefaultPlanCommandPersistence
    {
        Task<bool> PlanExist(string name);
        Task SetDefaultPlan(string name);
    }
}