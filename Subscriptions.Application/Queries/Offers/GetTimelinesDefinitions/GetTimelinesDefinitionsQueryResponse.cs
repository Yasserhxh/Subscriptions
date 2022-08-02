using System.Collections.Generic;

namespace Subscriptions.Application.Queries.Offers.GetTimelinesDefinitions
{
    public class GetTimelinesDefinitionsQueryResponse
    {
        public List<TimelineDefinitionDto> Definitions { get; set; } = new();
    }
}