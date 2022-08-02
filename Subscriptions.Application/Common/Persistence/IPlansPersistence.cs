using System.Threading.Tasks;

namespace Subscriptions.Application.Common.Persistence
{
    public interface IPlansPersistence
    {
         Task<bool> PlanExist(long planId);
    }
}