using System;
using System.Collections.Generic;
using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public class InfinitePaidTimelineDefinition : PaidTimeLineDefinition
    {
        public InfinitePaidTimelineDefinition()
        {
            TimeLineDefinitionType = TimelineDefinitionType.InfinitePaidTimelineDefinition;
        }

        public override IEnumerable<TimeLine> Build(DateTime now)
        {
            return new List<TimeLine>()
            {
                new InfinitePaidTimeLine(now,Amount,false,AutoCharging)
            };
        }
    }
}