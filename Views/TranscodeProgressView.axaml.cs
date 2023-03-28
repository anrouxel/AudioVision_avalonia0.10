using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AudioVision.ViewModels;
using ReactiveUI;

namespace AudioVision.Views
{
    public partial class TranscodeProgressView : ReactiveUserControl<TranscodeProgressViewModel>
    {
        public TranscodeProgressView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}