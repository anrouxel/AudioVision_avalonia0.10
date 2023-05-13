using System;

namespace AudioVision.Exceptions
{
    /// <summary>
    /// This exception is thrown when there is an error with the media conversion options.
    /// </summary>
    class FileNotFoundException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">The message.</param>
        public FileNotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public FileNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}