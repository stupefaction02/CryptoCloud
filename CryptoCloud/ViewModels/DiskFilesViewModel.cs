using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCloud.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CryptoCloud.ViewModels
{
    public class DiskFileItemModel
    {
        public string Name { get; set; }

        public string ModificationDate { get; set; }
    }

    public class DiskFolderModel : DiskFileItemModel
    {

    }

    public class DiskFileModel : DiskFileItemModel
    {

    }

    public class DiskItemViewModel : ObservableObject
    {
        public string Type { get; set; }

        public DiskFileItemModel Model { get; set; }
    }

    public class DiskFilesViewModel : BaseViewModel
    {
        private readonly IPopupService popupService;

        public ObservableCollection<DiskItemViewModel> AllFiles { get; set; }

        public ObservableCollection<DiskItemViewModel> RecentFiles { get; set; }

        public string DiskOwner { get; set; }

        public ICommand DownloadFilesCommand { get; set; }
        public ICommand FileClickedCommand { get; set; }

        public DiskFilesViewModel(IPopupService popupService)
        {
            AllFiles = new ObservableCollection<DiskItemViewModel>
            {
                new DiskItemViewModel { Type = "folder", Model = new DiskFolderModel { Name = "Папка 1", ModificationDate = "24.03.2025 9:32" } },
                new DiskItemViewModel { Type = "folder", Model = new DiskFolderModel { Name = "Папка 123", ModificationDate = "14.02.2015 13:32" } },
                new DiskItemViewModel { Type = "folder", Model = new DiskFolderModel { Name = "Папка - copy (123)", ModificationDate = "8.03.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "file.png", ModificationDate = "8.03.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "x-file.png", ModificationDate = "8.03.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "ABOBA.png", ModificationDate = "28.13.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "x-file (1).png", ModificationDate = "89.01.2123 29:32" } },
                new DiskItemViewModel { Type = "addFile" },
            };

            RecentFiles = new ObservableCollection<DiskItemViewModel>
            {
                new DiskItemViewModel { Type = "folder", Model = new DiskFolderModel { Name = "Папка 1", ModificationDate = "24.03.2025 9:32" } },
                new DiskItemViewModel { Type = "folder", Model = new DiskFolderModel { Name = "Папка 123", ModificationDate = "14.02.2015 13:32" } },
                new DiskItemViewModel { Type = "folder", Model = new DiskFolderModel { Name = "Папка - copy (123)", ModificationDate = "8.03.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "file.png", ModificationDate = "8.03.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "x-file.png", ModificationDate = "8.03.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "ABOBA.png", ModificationDate = "28.13.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "x-file (1).png", ModificationDate = "89.01.2123 29:32" } },
                new DiskItemViewModel { Type = "addFile" },
            };

            DownloadFilesCommand = new RelayCommand(DownloadFilesCommandHandler);
            FileClickedCommand = new RelayCommand<object>(FileClickedCommandHandler);
            this.popupService = popupService;
        }

        private void FileClickedCommandHandler(object parameter)
        {
            if (parameter is DiskItemViewModel vm)
            {
                if (vm.Model != null)
                {
                    popupService.ShowFileInfoPopup(vm.Model);
                }
            }
        }

        private void DownloadFilesCommandHandler()
        {
            
        }
    }
}
