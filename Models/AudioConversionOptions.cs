using System;
using System.Collections.Generic;

namespace AudioVision.Models
{
    /// <summary>
    /// This class is used to set the options for audio conversion.
    /// </summary>
    public class AudioConversionOptions : IMediaConversionOptions
    {
        /// <summary>
        /// The audio codec to use.
        /// </summary>
        public string AudioCodec { get; private set; } = default!;

        /// <summary>
        /// The audio bitrate to use.
        /// </summary>
        public int AudioBitrate { get; private set; }

        /// <summary>
        /// The audio channels to use.
        /// </summary>
        public int AudioChannels { get; private set; }

        /// <summary>
        /// The audio sample rate to use.
        /// </summary>
        public int AudioSampleRate { get; private set; }

        /// <summary>
        /// Private constructor.
        /// </summary>
        private AudioConversionOptions() { }

        /// <summary>
        /// Builder class for <see cref="AudioConversionOptions"/>.
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// The audio codec to use.
            /// </summary>
            private string _audioCodec = default!;

            /// <summary>
            /// The audio bitrate to use.
            /// </summary>
            private int _audioBitrate;

            /// <summary>
            /// The audio channels to use.
            /// </summary>
            private int _audioChannels;

            /// <summary>
            /// The audio sample rate to use.
            /// </summary>
            private int _audioSampleRate;

            /// <summary>
            /// Sets the audio codec to use.
            /// </summary>
            /// <param name="codec">The audio codec to use.</param>
            /// <returns>The builder.</returns>
            public Builder SetAudioCodec(string codec)
            {
                this._audioCodec = codec;
                return this;
            }

            /// <summary>
            /// Sets the audio bitrate to use.
            /// </summary>
            /// <param name="bitrate">The audio bitrate to use.</param>
            /// <returns>The builder.</returns>
            public Builder SetAudioBitrate(int bitrate)
            {
                this._audioBitrate = bitrate;
                return this;
            }

            /// <summary>
            /// Sets the audio channels to use.
            /// </summary>
            /// <param name="channels">The audio channels to use.</param>
            /// <returns>The builder.</returns>
            public Builder SetAudioChannels(int channels)
            {
                this._audioChannels = channels;
                return this;
            }

            /// <summary>
            /// Sets the audio sample rate to use.
            /// </summary>
            /// <param name="samplerate">The audio sample rate to use.</param>
            /// <returns>The builder.</returns>
            public Builder SetAudioSampleRate(int samplerate)
            {
                this._audioSampleRate = samplerate;
                return this;
            }

            /// <summary>
            /// Builds the <see cref="AudioConversionOptions"/>.
            /// </summary>
            /// <returns>The <see cref="AudioConversionOptions"/>.</returns>
            public AudioConversionOptions Build()
            {
                return new AudioConversionOptions()
                {
                    AudioCodec = this._audioCodec,
                    AudioBitrate = this._audioBitrate,
                    AudioChannels = this._audioChannels,
                    AudioSampleRate = this._audioSampleRate
                };
            }
        }

        /// <summary>
        /// Returns the audio codec to use.
        /// </summary>
        /// <returns>The audio codec to use.</returns>
        public string GetAudioCodec()
        {
            return $"acodec={this.AudioCodec}";
        }

        /// <summary>
        /// Returns the audio bitrate to use.
        /// </summary>
        /// <returns>The audio bitrate to use.</returns>
        public string GetAudioBitrate()
        {
            return $"ab={this.AudioBitrate}";
        }

        /// <summary>
        /// Returns the audio channels to use.
        /// </summary>
        /// <returns>The audio channels to use.</returns>
        public string GetAudioChannels()
        {
            return $"channels={this.AudioChannels}";
        }

        /// <summary>
        /// Returns the audio sample rate to use.
        /// </summary>
        /// <returns>The audio sample rate to use.</returns>
        public string GetAudioSampleRate()
        {
            return $"samplerate={this.AudioSampleRate}";
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <returns>The options.</returns>
        public List<string> GetOptions()
        {
            return new List<string>()
            {
                this.GetAudioCodec(),
                this.GetAudioBitrate(),
                this.GetAudioChannels(),
                this.GetAudioSampleRate()
            };
        }
    }
}