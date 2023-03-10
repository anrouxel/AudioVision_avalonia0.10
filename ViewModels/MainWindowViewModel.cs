using ReactiveUI;

namespace AudioVision.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        public RoutingState Router { get; } = new RoutingState();

        public MainWindowViewModel()
        {
            Router.Navigate.Execute(new SelectFilesViewModel(this));
        }
    }
}

/*
using System;
using System.Threading;
using LibVLCSharp.Shared;

class Program
{
    static void Main(string[] arg)
    {
        concat();
    }

    public static void transcode()
    {
        var inputFile = "./Musette.wav";
        var outputFile = "./Musette.ogg";

        var options = ":sout=#transcode{acodec=vorbis,ab=128,channels=2,samplerate=44100}:file{dst=" + outputFile + "}";

        var libvlc = new LibVLC();

        var media = new Media(libvlc, inputFile, FromType.FromPath);
        media.Parse();
        media.AddOption(options);

        var mediaPlayer = new MediaPlayer(media);

        mediaPlayer.Play();

        Console.WriteLine("Converting audio...");

        var transcodingFinished = false;

        mediaPlayer.EndReached += (sender, e) =>
        {
            Console.WriteLine("Transcoding finished.");
            transcodingFinished = true;
        };

        while (!transcodingFinished)
        {
            //Console.WriteLine(mediaPlayer.Position);
            //Thread.Sleep(1000);
            Console.Write("\rProgress: [{0}] {1}%", new string('#', (int)(mediaPlayer.Position * 20)), (int)(mediaPlayer.Position * 100));
            Thread.Sleep(100);
        }
    }

    public static void concat()
    {
        var inputFile1 = "./Musette.wav";
        var inputFile2 = "./Musette.ogg";
        var outputFile = "./Musette_Merged.ogg";

        var options = ":sout=#transcode{acodec=mp3,ab=128}:duplicate{dst=concat{dst=file{dst=" + outputFile + "},dst=file{dst=" + inputFile2 + "}}}";

        var libvlc = new LibVLC();

        var media = new Media(libvlc, inputFile1, FromType.FromPath);
        media.AddOption(options);

        var mediaPlayer = new MediaPlayer(media);

        mediaPlayer.Play();

        Console.WriteLine("Converting audio...");

        var transcodingFinished = false;

        mediaPlayer.EndReached += (sender, e) =>
        {
            Console.WriteLine("Transcoding finished.");
            transcodingFinished = true;
        };

        while (!transcodingFinished)
        {
            //Console.WriteLine(mediaPlayer.Position);
            //Thread.Sleep(1000);
            Console.Write("\rProgress: [{0}] {1}%", new string('#', (int)(mediaPlayer.Position * 20)), (int)(mediaPlayer.Position * 100));
            Thread.Sleep(100);
        }
    }
}
*/