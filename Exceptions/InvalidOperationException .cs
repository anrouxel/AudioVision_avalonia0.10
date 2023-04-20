using System;

namespace AudioVision.Exceptions
{
    class InvalidOperationException : Exception
    {
        public InvalidOperationException(string message) : base(message)
        {

        }
        public InvalidOperationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}