using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.IO;
using Avalonia.Controls;
using System.Linq;

namespace AudioVision.ViewModels
{
    public class SelectFilesViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }
        public string UrlPathSegment { get; } = "SelectFiles";
        private bool _isFileSelected;
        private bool _isDiscSelected;
        private ObservableCollection<FileInfo> _selectedFiles;
        private ObservableCollection<FileInfo> _selectedItems;

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

        public ObservableCollection<FileInfo> SelectedItems
        {
            get => _selectedItems;
            set => this.RaiseAndSetIfChanged(ref _selectedItems, value);
        }

        public ReactiveCommand<Unit, Unit> AddFilesCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteFilesCommand { get; }

        public ObservableCollection<DriveInfo> AvailableDrives { get; }

        public SelectFilesViewModel(IScreen screen)
        {
            HostScreen = screen;

            _selectedFiles = new ObservableCollection<FileInfo>();
            _selectedItems = new ObservableCollection<FileInfo>();
            _isFileSelected = true;
            IsDiscSelected = true;
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
            DeleteFilesCommand = ReactiveCommand.Create(() =>
            {
                foreach (var item in SelectedItems)
                {
                    SelectedFiles.Remove(item);
                }
            });
            AvailableDrives = new ObservableCollection<DriveInfo>(DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.CDRom));
        }
    }
}