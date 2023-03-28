namespace AudioVision.Models
{
    public class VideoConversionOptions : IMediaConversionOptions
    {
        public string VideoCodec { get; private set; } = default!;
        public int VideoBitrate { get; private set; }
        public int ResolutionX { get; private set; }
        public int ResolutionY { get; private set; }

        private VideoConversionOptions() { }

        public class Builder
        {
            private string _videoCodec = default!;
            private int _videoBitrate;
            private int _resolutionX;
            private int _resolutionY;

            public Builder SetVideoCodec(string codec)
            {
                this._videoCodec = codec;
                return this;
            }

            public Builder SetVideoBitrate(int bitrate)
            {
                this._videoBitrate = bitrate;
                return this;
            }

            public Builder SetResolution(int resolutionX, int resolutionY)
            {
                this.SetResolutionX(resolutionX);
                this.SetResolutionY(resolutionY);
                return this;
            }

            public Builder SetResolutionX(int resolutionX)
            {
                this._resolutionX = resolutionX;
                return this;
            }

            public Builder SetResolutionY(int resolutionY)
            {
                this._resolutionY = resolutionY;
                return this;
            }

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

        public string GetOptions()
        {
            return $"#transcode{{vcodec={this.VideoCodec},vb={this.VideoBitrate},width={this.ResolutionX},height={this.ResolutionY}}}:";
        }
    }
}