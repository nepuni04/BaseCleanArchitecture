using System;

namespace Application.Common.Exceptions
{
    public class UnauthorizedUserException : Exception
    {
        public UnauthorizedUserException() : base()
        {
        }

        public UnauthorizedUserException(string message) : base(message)
        {
        }
    }
}
