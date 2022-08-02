using System;
using System.Collections.Generic;
using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public class FiniteFreeTimeLineDefinition : TimeLineDefinition,IFiniteTimeLineDefinition
    {
        public TimelineExpiration Expiration { get; set; }
        public FiniteFreeTimeLineDefinition()
        {
            TimeLineDefinitionType = TimelineDefinitionType.FiniteFreeTimeLineDefinition;
        }
        public override IEnumerable<TimeLine> Build(DateTime now)
        {
            var dateTimeRange = Expiration.CreateDateTimeRangeFromExpiration(now);
            return new List<TimeLine>()
            {
                new FiniteFreeTimeLine(dateTimeRange)
            };
        }

        
    }
}