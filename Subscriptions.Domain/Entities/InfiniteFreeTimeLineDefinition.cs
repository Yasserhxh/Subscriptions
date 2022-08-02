using System;
using System.Collections.Generic;
using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public class InfiniteFreeTimeLineDefinition : TimeLineDefinition
    {
        public InfiniteFreeTimeLineDefinition()
        {
            TimeLineDefinitionType = TimelineDefinitionType.InfiniteFreeTimeLineDefinition;
        }
        public override IEnumerable<TimeLine> Build(DateTime now)
        {
            return new List<TimeLine>()
            {
                new InfiniteFreeTimeLine(now)
            };
        }
    }
}