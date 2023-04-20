using System;

namespace AudioVision.Exceptions
{
    class MediaConversionOptionsException : Exception
    {
        public MediaConversionOptionsException(string message) : base(message)
        {

        }
        public MediaConversionOptionsException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}