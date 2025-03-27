using CommunityToolkit.Mvvm.Input;
using CryptoCloud.Models;
using CryptoCloud.Services;
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
