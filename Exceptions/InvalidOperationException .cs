using System;

namespace AudioVision.Exceptions
{
    /// <summary>
    /// This exception is thrown when there is an error with the media conversion options.
    /// </summary>
    class InvalidOperationException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">The message.</param>
        public InvalidOperationException(string message) : base(message)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public InvalidOperationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}