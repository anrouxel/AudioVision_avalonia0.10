using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.IO;
using Avalonia.Controls;
using System.Linq;

namespace AudioVision.ViewModels;

public class SelectFilesViewModel : ViewModelBase
{
    private bool _isFileSelected;
    private bool _isDiscSelected;
    private ObservableCollection<FileInfo> _selectedFiles;
    
    public bool IsFileSelected
    {
        get => _isFileSelected;
        set => this.RaiseAndSetIfChanged(ref _isFileSelected, value);
    }

    public bool IsDiscSelected
    {
        get => _isDiscSelected;
        set => this.RaiseAndSetIfChanged(ref _isDiscSelected, value);
    }

    public ObservableCollection<FileInfo> SelectedFiles
    {
        get => _selectedFiles;
        set => this.RaiseAndSetIfChanged(ref _selectedFiles, value);
    }

    public ReactiveCommand<Unit, Unit> AddFilesCommand { get; }
    public ReactiveCommand<FileInfo, Unit> DeleteFilesCommand { get; }

    public ObservableCollection<DriveInfo> AvailableDrives { get; }

    public SelectFilesViewModel()
    {
        _selectedFiles = new ObservableCollection<FileInfo>();
        _isFileSelected = true;
        IsDiscSelected = false;
        AddFilesCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var dialog = new OpenFileDialog();
            dialog.AllowMultiple = true;
            var window = new Window();
            var result = await dialog.ShowAsync(window);
            if (result != null)
            {
                foreach (var item in result)
                {
                    SelectedFiles.Add(new FileInfo(item));
                }
            }
        });
        DeleteFilesCommand = ReactiveCommand.Create<FileInfo>((file) =>
        {
            if (SelectedFiles.Contains(file))
            {
                SelectedFiles.Remove(file);
            }
        });
        AvailableDrives = new ObservableCollection<DriveInfo>(DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.CDRom));
    }
}
