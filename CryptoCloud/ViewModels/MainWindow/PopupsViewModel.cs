using CommunityToolkit.Mvvm.Input;
using CryptoCloud.Models;
using CryptoCloud.Services;
using CryptoCloud.ViewModels.MainWindowViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoCloud.ViewModels.MainWindowViewModels
{
    public class FilePopupViewModel : ViewModel
    {
        public ICommand CloseCommand { get; set; }
        private DiskFileItemModel fileInfoDataContext;
        private bool showFileInfoPopup;
        private readonly IPopupService popupService;

        public bool ShowFileInfoPopup
        {
            get => showFileInfoPopup;
            set
            {
                showFileInfoPopup = value;

                OnPropertyChanged(nameof(ShowFileInfoPopup));
            }
        }

        public DiskFileItemModel FileInfoDataContext
        {
            get => fileInfoDataContext;
            set
            {
                fileInfoDataContext = value;
                OnPropertyChanged(nameof(FileInfoDataContext));
            }
        }

        public FilePopupViewModel(IPopupService popupService)
        {
            CloseCommand = new RelayCommand(CloseCommandHandler);
            this.popupService = popupService;
        }

        private void CloseCommandHandler()
        {
            this.popupService.HideAllPopups();
        }
    }
}

namespace CryptoCloud.ViewModels
{
    public class PopupsViewModel : ViewModel
    {
        public bool showAnyPopup { get; set; }

        public bool ShowAnyPopup
        {
            get => showAnyPopup;
            set
            {
                showAnyPopup = value;
                OnPropertyChanged(nameof(ShowAnyPopup));
            }
        }

        public FilePopupViewModel flePopupViewModel { get; set; }

        public FilePopupViewModel FilePopupViewModel
        {
            get => flePopupViewModel;
            set
            {
                flePopupViewModel = value;
                OnPropertyChanged(nameof(FilePopupViewModel));
            }
        }
    }
}
