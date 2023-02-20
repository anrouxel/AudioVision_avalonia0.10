using ReactiveUI;

namespace AudioVision.ViewModels;

public class SelectFilesViewModel : ViewModelBase
{
    private bool isFileSelected;
    private bool isDiscSelected;

    public bool IsFileSelected
    {
        get => isFileSelected;
        set => this.RaiseAndSetIfChanged(ref isFileSelected, value);
    }

    public bool IsDiscSelected
    {
        get => isDiscSelected;
        set => this.RaiseAndSetIfChanged(ref isDiscSelected, value);
    }
}
