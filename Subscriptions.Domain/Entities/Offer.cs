
using System.Collections.Generic;

namespace Subscriptions.Domain.Entities
{
    public class Offer
    {
        public Offer()
        {
            TimeLineDefinitions = new List<TimeLineDefinition>();
        }

        public Offer(Plan plan)
        {
            Plan = plan;
            TimeLineDefinitions = new List<TimeLineDefinition>();
        }
        public string Name { get; set; }
        public Plan Plan { get; set; }
        public ICollection<TimeLineDefinition> TimeLineDefinitions { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }

        public void AddTimelineDefinition(TimeLineDefinition definition)
        {
            TimeLineDefinitions.Add(definition);
        }
    }
   
    
}