using System;
using System.Collections.Generic;

namespace AudioVision.Models
{
    /// <summary>
    /// This interface is used to set the options for media conversion.
    /// </summary>
    public interface IMediaConversionOptions
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        public List<string> GetOptions();
    }
}