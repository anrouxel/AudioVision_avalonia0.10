using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.IO;
using Avalonia.Controls;
using System.Linq;
using LibVLCSharp.Shared;

namespace AudioVision.ViewModels
{
    public class TranscodeProgressViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = "TranscodeProgress";

        public LibVLC libVLC;

        private string _text;

        public string Text
        {
            get => _text;
            set => this.RaiseAndSetIfChanged(ref _text, value);
        }

        private ObservableCollection<FileInfo> _medias;

        public ObservableCollection<FileInfo> Medias
        {
            get => _medias;
            set => this.RaiseAndSetIfChanged(ref _medias, value);
        }
        
        public TranscodeProgressViewModel(IScreen screen, ObservableCollection<FileInfo> files)
        {
            HostScreen = screen;
            _medias = new ObservableCollection<FileInfo>();
            Medias = files;

            libVLC = new LibVLC();

            _text = "";
            Text = Medias.First().Name.ToString();
            Transcode(Medias.First(), "ogg");
        }

        public void Transcode(FileInfo input, string format) {
            FileInfo output = new FileInfo(Path.ChangeExtension(input.FullName, format));

        }
    }
}