using System.Collections.Generic;
using System.Threading.Tasks;

namespace Subscriptions.Application.Queries.Offers.GetTimelinesDefinitions.Persistence
{
    public interface IGetTimelinesDefinitionsPersistence
    {
        Task<List<TimelineDefinitionDto>> GetTimelinesDefinitions(long offerId);
    }
}