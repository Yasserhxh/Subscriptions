using System;

namespace Subscriptions.Application.Common.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException()
        {
            
        }
        public NotAuthorizedException(string message) : base(message)
        {
        }
    }
}