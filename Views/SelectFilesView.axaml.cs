using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AudioVision.ViewModels;
using ReactiveUI;

namespace AudioVision.Views
{
    public partial class SelectFilesView : ReactiveUserControl<SelectFilesViewModel>
    {
        public SelectFilesView()
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