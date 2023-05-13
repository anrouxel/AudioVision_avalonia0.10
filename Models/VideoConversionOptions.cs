namespace AudioVision.Models
{
    /// <summary>
    /// This class is used to set the options for video conversion.
    /// </summary>
    public class VideoConversionOptions : IMediaConversionOptions
    {
        /// <summary>
        /// The video codec to use.
        /// </summary>
        public string VideoCodec { get; private set; } = default!;

        /// <summary>
        /// The video bitrate to use.
        /// </summary>
        public int VideoBitrate { get; private set; }

        /// <summary>
        /// The video resolution to use.
        /// </summary>
        public int ResolutionX { get; private set; }

        /// <summary>
        /// The video resolution to use.
        /// </summary>
        public int ResolutionY { get; private set; }

        /// <summary>
        /// Private constructor.
        /// </summary>
        private VideoConversionOptions() { }

        /// <summary>
        /// Builder class for <see cref="VideoConversionOptions"/>.
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// The video codec to use.
            /// </summary>
            private string _videoCodec = default!;

            /// <summary>
            /// The video bitrate to use.
            /// </summary>
            private int _videoBitrate;

            /// <summary>
            /// The video resolution to use.
            /// </summary>
            private int _resolutionX;

            /// <summary>
            /// The video resolution to use.
            /// </summary>
            private int _resolutionY;

            /// <summary>
            /// Sets the video codec to use.
            /// </summary>
            /// <param name="codec">The video codec to use.</param>
            /// <returns>The builder.</returns>
            public Builder SetVideoCodec(string codec)
            {
                this._videoCodec = codec;
                return this;
            }

            /// <summary>
            /// Sets the video bitrate to use.
            /// </summary>
            /// <param name="bitrate">The video bitrate to use.</param>
            /// <returns>The builder.</returns>
            public Builder SetVideoBitrate(int bitrate)
            {
                this._videoBitrate = bitrate;
                return this;
            }

            /// <summary>
            /// Sets the video resolution to use.
            /// </summary>
            /// <param name="resolutionX">The video resolution to use.</param>
            /// <param name="resolutionY">The video resolution to use.</param>
            /// <returns>The builder.</returns>
            public Builder SetResolution(int resolutionX, int resolutionY)
            {
                this.SetResolutionX(resolutionX);
                this.SetResolutionY(resolutionY);
                return this;
            }

            /// <summary>
            /// Sets the video resolution to use.
            /// </summary>
            /// <param name="resolutionX">The video resolution to use.</param>
            /// <returns>The builder.</returns>
            public Builder SetResolutionX(int resolutionX)
            {
                this._resolutionX = resolutionX;
                return this;
            }

            /// <summary>
            /// Sets the video resolution to use.
            /// </summary>
            /// <param name="resolutionY">The video resolution to use.</param>
            /// <returns>The builder.</returns>
            public Builder SetResolutionY(int resolutionY)
            {
                this._resolutionY = resolutionY;
                return this;
            }

            /// <summary>
            /// Builds the <see cref="VideoConversionOptions"/>.
            /// </summary>
            /// <returns>The <see cref="VideoConversionOptions"/>.</returns>
            public VideoConversionOptions Build()
            {
                return new VideoConversionOptions()
                {
                    VideoCodec = this._videoCodec,
                    VideoBitrate = this._videoBitrate,
                    ResolutionX = this._resolutionX,
                    ResolutionY = this._resolutionY
                };
            }
        }

        /// <summary>
        /// Gets the video codec options.
        /// </summary>
        /// <returns>The video codec options.</returns>
        public string GetVideoCodecOptions() {
            return $"vcodec={this.VideoCodec}";
        }

        /// <summary>
        /// Gets the video bitrate options.
        /// </summary>
        /// <returns>The video bitrate options.</returns>
        public string GetVideoBitrateOptions() {
            return $"vb={this.VideoBitrate}";
        }

        /// <summary>
        /// Gets the video resolution options.
        /// </summary>
        /// <returns>The video resolution options.</returns>
        public string GetResolutionOptions() {
            return $"width={this.ResolutionX},height={this.ResolutionY}";
        }

        /// <summary>
        /// Gets the options for video conversion.
        /// </summary>
        /// <returns>The options for video conversion.</returns>
        public string GetOptions()
        {
            var videoCodecOptions = this.GetVideoCodecOptions();
            var videoBitrateOptions = this.GetVideoBitrateOptions();
            var resolutionOptions = this.GetResolutionOptions();

            return $"#transcode{{{videoCodecOptions},{videoBitrateOptions},{resolutionOptions}}}:";
        }
    }
}