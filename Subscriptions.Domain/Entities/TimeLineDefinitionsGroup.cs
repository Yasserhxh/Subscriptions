using System.Collections.Generic;

namespace Subscriptions.Domain.Entities
{
    public class TimeLineDefinitionsGroup
    {
        public TimeLineDefinitionsGroup()
        {
            TimeLineDescriptions = new List<TimeLineDefinition>();
        }

        public string Name { get; set; }
        public ICollection<TimeLineDefinition> TimeLineDescriptions { get; set; }
    }
}