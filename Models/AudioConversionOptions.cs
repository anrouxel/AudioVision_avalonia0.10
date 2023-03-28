namespace AudioVision.Models
{
    public class AudioConversionOptions : IMediaConversionOptions
    {
        public string AudioCodec { get; private set; } = default!;
        public int AudioBitrate { get; private set; }
        public int AudioChannels { get; private set; }
        public int AudioSampleRate { get; private set; }

        private AudioConversionOptions() { }

        public class Builder
        {
            private string _audioCodec = default!;
            private int _audioBitrate;
            private int _audioChannels;
            private int _audioSampleRate;

            public Builder SetAudioCodec(string codec)
            {
                this._audioCodec = codec;
                return this;
            }

            public Builder SetAudioBitrate(int bitrate)
            {
                this._audioBitrate = bitrate;
                return this;
            }

            public Builder SetAudioChannels(int channels)
            {
                this._audioChannels = channels;
                return this;
            }

            public Builder SetAudioSampleRate(int samplerate)
            {
                this._audioSampleRate = samplerate;
                return this;
            }

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

        public string GetOptions()
        {
            return $"#transcode{{acodec={this.AudioCodec},ab={this.AudioBitrate},channels={this.AudioChannels},samplerate={this.AudioSampleRate}}}:";
        }
    }
}