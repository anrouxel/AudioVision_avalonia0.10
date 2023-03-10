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