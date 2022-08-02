using System;
using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public interface IFiniteTimeLineDefinition
    {
        public TimelineExpiration Expiration { get; set; }
    }
}