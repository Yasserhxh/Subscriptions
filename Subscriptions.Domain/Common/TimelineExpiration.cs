using System;
using System.Collections.Generic;
using NodaTime;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Domain.Common
{
    public class TimelineExpiration : ValueObject
    {
        public Period Period { get; set; }
        public TimelineExpiration(int years,int months,int weeks,int days,int hours,int minutes)
        {
            var periodBuilder  = Period.Zero.ToBuilder();
            periodBuilder.Years = years;
            periodBuilder.Months = months;
            periodBuilder.Weeks = weeks;
            periodBuilder.Days = days;
            periodBuilder.Hours = hours;
            periodBuilder.Minutes = minutes;
            Period = periodBuilder.Build();
        }

        public DateTimeRange CreateDateTimeRangeFromExpiration(DateTime? start = null)
        {
            start ??= DateTime.Now;
            var end = start.Value.AddYears(Period.Years).AddMonths(Period.Months)
                .AddDays(Period.Days).AddHours(Period.Hours)
                .AddMinutes(Period.Minutes);
            
            return new DateTimeRange(start.Value, end);

        }

   
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Period;
            
        }
    }
}