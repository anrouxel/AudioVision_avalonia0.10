using System;
using System.IO;
using System.Collections.Generic;
using LibVLCSharp.Shared;

namespace AudioVision.Models
{
    /// <summary>
    /// This class is used to set the options for media conversion.
    /// </summary>
    public class MediaConversionInfo
    {
        /// <summary>
        /// The input file.
        /// </summary>
        public FileInfo Input { get; private set; } = default!;

        /// <summary>
        /// The output file.
        /// </summary>
        public FileInfo Output { get; private set; } = default!;

        /// <summary>
        /// The conversion options.
        /// </summary>
        public HashSet<IMediaConversionOptions> ConversionOptions { get; private set; } = default!;

        /// <summary>
        /// Private constructor.
        /// </summary>
        private MediaConversionInfo() { }

        /// <summary>
        /// Builder class for <see cref="MediaConversionInfo"/>.
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// The input file.
            /// </summary>
            private readonly FileInfo _input;

            /// <summary>
            /// The output file.
            /// </summary>
            private FileInfo _output = default!;

            /// <summary>
            /// The conversion options.
            /// </summary>
            private HashSet<IMediaConversionOptions> _conversionOptions = default!;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="input">The input file.</param>
            /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
            public Builder(FileInfo input)
            {
                this._input = input ?? throw new ArgumentNullException(nameof(input));
                ValidateInputFile();
            }

            /// <summary>
            /// Sets the output file.
            /// </summary>
            /// <param name="output">The output file.</param>
            /// <returns>The builder.</returns>
            /// <exception cref="ArgumentNullException">Thrown when <paramref name="output"/> is null.</exception>
            public Builder SetOutput(FileInfo output)
            {
                this._output = output ?? throw new ArgumentNullException(nameof(output));
                return this;
            }

            /// <summary>
            /// Sets the format of the output file.
            /// </summary>
            /// <param name="format">The format of the output file.</param>
            /// <returns>The builder.</returns>
            /// <exception cref="InvalidOperationException">Thrown when <see cref="SetOutput(FileInfo)"/> has not been called before.</exception>
            public Builder SetFormat(string format)
            {
                if (_output == null)
                {
                    throw new InvalidOperationException("Vous devez appeler SetOutput avant SetFormat.");
                }
                this._output = new FileInfo(Path.ChangeExtension(this._output.FullName, format));
                return this;
            }

            /// <summary>
            /// Adds an audio conversion option.
            /// </summary>
            /// <param name="audioConversionOptions">The audio conversion option to add.</param>
            /// <returns>The builder.</returns>
            public Builder AddAudio(AudioConversionOptions audioConversionOptions)
            {
                this._conversionOptions.Add(audioConversionOptions);
                return this;
            }

            /// <summary>
            /// Adds a video conversion option.
            /// </summary>
            /// <param name="videoConversionOptions">The video conversion option to add.</param>
            /// <returns>The builder.</returns>
            public Builder AddVideo(VideoConversionOptions videoConversionOptions)
            {
                this._conversionOptions.Add(videoConversionOptions);
                return this;
            }

            /// <summary>
            /// Builds the <see cref="MediaConversionInfo"/>.
            /// </summary>
            /// <returns>The <see cref="MediaConversionInfo"/>.</returns>
            public MediaConversionInfo Build()
            {
                ValidateOutputFile();

                if (this._output.Directory != null && !this._output.Directory.Exists)
                {
                    this._output.Directory.Create();
                }
                return new MediaConversionInfo()
                {
                    Input = this._input,
                    Output = this._output,
                    ConversionOptions = this._conversionOptions
                };
            }

            /// <summary>
            /// Validates the input file.
            /// </summary>
            /// <exception cref="FileNotFoundException">Thrown when the input file does not exist.</exception>
            private void ValidateInputFile()
            {
                if (!this._input.Exists)
                {
                    throw new FileNotFoundException("Fichier d'entrée non trouvé.", this._input.FullName);
                }
            }

            /// <summary>
            /// Validates the output file.
            /// </summary>
            /// <exception cref="InvalidOperationException">Thrown when <see cref="SetOutput(FileInfo)"/> has not been called before.</exception>
            private void ValidateOutputFile()
            {
                if (this._output == null)
                {
                    throw new InvalidOperationException("Vous devez appeler SetOutput avant Build.");
                }
            }
        }

        public string GetOptions()
        {
            string options = "";
            foreach (IMediaConversionOptions option in ConversionOptions)
            {
                options += option.GetOptions();
            }
            return options;
        }

        /// <summary>
        /// Converts the media.
        /// </summary>
        public void Convert()
        {

        }
    }
}