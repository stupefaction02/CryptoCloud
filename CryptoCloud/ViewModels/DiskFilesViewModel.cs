using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoCloud.Infrastructure;
using CryptoCloud.Models;
using CryptoCloud.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CryptoCloud.ViewModels
{
    public class DiskFilesViewModel : ViewModel
    {
        private readonly IPopupService popupService;
        private readonly ILogger<DiskFilesViewModel> logger;

        public ObservableCollection<DiskFileItemModel> AllFiles { get; set; }

        public ObservableCollection<DiskFileItemModel> RecentFiles { get; set; }

        public string DiskOwner { get; set; }

        public ICommand DownloadFilesCommand { get; set; }
        public ICommand FileClickedCommand { get; set; }

        public DiskFilesViewModel(IPopupService popupService, ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<DiskFilesViewModel>();

            AllFiles = new ObservableCollection<DiskFileItemModel>
            {
                new DiskFolderModel { Name = "Папка 1", ModificationDate = "24.03.2025 9:32" },
                new DiskFolderModel { Name = "Папка 1", ModificationDate = "14.02.2015 13:32" },
                new DiskFolderModel { Name = "Папка", ModificationDate = "8.03.2023 11:32" },
                new DiskFileModel { Name = "xfile.png", ModificationDate = "89.01.2123 29:32" },
            };

            RecentFiles = new ObservableCollection<DiskFileItemModel>
            {
                new DiskFolderModel { Name = "Папка 1", ModificationDate = "24.03.2025 9:32" },
                new DiskFolderModel { Name = "Папка2", ModificationDate = "14.02.2015 13:32" },
                new DiskFolderModel { Name = "Папка", ModificationDate = "8.03.2023 11:32" },
                new DiskFileModel { Name = "file.png", ModificationDate = "8.03.2023 11:32" },
                new DiskFileModel { Name = "x-fil.png", ModificationDate = "8.03.2023 11:32" },
                new DiskFileModel { Name = "ABOBA", ModificationDate = "28.13.2023 11:32" },
                new DiskFileModel { Name = "x-fil.png", ModificationDate = "89.01.2123 29:32" },
            };

            DownloadFilesCommand = new RelayCommand(DownloadFilesCommandHandler);
            FileClickedCommand = new RelayCommand<object>(FileClickedCommandHandler);
            this.popupService = popupService;
        }

        FilesEncryptionProgressInfoViewModel encryptionProgressInfoViewModel;
        private void FileClickedCommandHandler(object parameter)
        {
            if (parameter is DiskFileItemModel vm)
            {
                logger.LogInformation($"File was clicked. file: {{ name = {vm.Name} }}");

                popupService.ShowFileInfoPopup(vm);
            }
        }

        private void DownloadFilesCommandHandler()
        {
            var vm = encryptionProgressInfoViewModel ?? (encryptionProgressInfoViewModel = DependencyContainer.Resolve<FilesEncryptionProgressInfoViewModel>());

            //vm.IsPopupShown = true;

            popupService.ShowEncryptionProgressInfoPopup(vm);

            logger.LogInformation($"DownloadFilesButton was clicked.");
        }
    }
}
