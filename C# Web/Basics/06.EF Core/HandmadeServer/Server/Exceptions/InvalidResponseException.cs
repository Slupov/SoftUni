using System;

namespace HandmadeServer.Server.Exceptions
{
    public class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message)
            : base(message)
        {
        }
    }
}
