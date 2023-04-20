using System;
using System.IO;
using System.Collections.Generic;
using LibVLCSharp.Shared;

namespace AudioVision.Models
{
    public class MediaConversionInfo
    {
        public FileInfo Input { get; private set; } = default!;
        public FileInfo Output { get; private set; } = default!;
        public HashSet<IMediaConversionOptions> ConversionOptions { get; private set; } = default!;

        private MediaConversionInfo() { }

        public class Builder
        {
            private readonly FileInfo _input;
            private FileInfo _output = default!;
            private HashSet<IMediaConversionOptions> _conversionOptions = default!;

            public Builder(FileInfo input)
            {
                this._input = input ?? throw new ArgumentNullException(nameof(input));
                ValidateInputFile();
            }

            public Builder SetOutput(FileInfo output)
            {
                this._output = output ?? throw new ArgumentNullException(nameof(output));
                return this;
            }

            public Builder SetFormat(string format)
            {
                if (_output == null)
                {
                    throw new InvalidOperationException("Vous devez appeler SetOutput avant SetFormat.");
                }
                this._output = new FileInfo(Path.ChangeExtension(this._output.FullName, format));
                return this;
            }

            public Builder AddAudio(AudioConversionOptions audioConversionOptions)
            {
                this._conversionOptions.Add(audioConversionOptions);
                return this;
            }

            public Builder AddVideo(VideoConversionOptions videoConversionOptions)
            {
                this._conversionOptions.Add(videoConversionOptions);
                return this;
            }

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

            private void ValidateInputFile()
            {
                if (!this._input.Exists)
                {
                    throw new FileNotFoundException("Fichier d'entrée non trouvé.", this._input.FullName);
                }
            }

            private void ValidateOutputFile()
            {
                if (this._output == null)
                {
                    throw new InvalidOperationException("Vous devez appeler SetOutput avant Build.");
                }
            }
        }

        public void Convert()
        {

        }
    }
}