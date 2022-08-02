using System;
using System.Collections.Generic;
using System.Diagnostics;
using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public class FinitePaidTimeLineDefinition : PaidTimeLineDefinition,IFiniteTimeLineDefinition
    {
        public int Repeat { get; set; }

        public FinitePaidTimeLineDefinition(int repeat,TimelineExpiration expiration)
        {
            Repeat = repeat;
            Expiration = expiration;
            TimeLineDefinitionType = TimelineDefinitionType.FinitePaidTimeLineDefinition;
        }


        public TimelineExpiration Expiration { get; set; }
        public override IEnumerable<FinitePaidTimeLine> Build(DateTime now)
        {
            var nextTimelineStart = now;
            
            var timelines = new List<FinitePaidTimeLine>();
            for (var i = 0; i < Repeat; i++)
            {
                var timeline = new FinitePaidTimeLine(Expiration.CreateDateTimeRangeFromExpiration(nextTimelineStart),Amount,false,AutoCharging);
                timelines.Add(timeline);
                Debug.Assert(timeline.DateTimeRange.End != null, "timeline.DateTimeRange.End != null");
                nextTimelineStart = (DateTime) timeline.DateTimeRange.End;
            }

            return timelines;
        }
    }
}