using CryptoCloud.Models;
using CryptoCloud.ViewModels;
using CryptoCloud.ViewModels.MainWindowViewModels;

namespace CryptoCloud.Services
{
    public class PopupService : IPopupService
    {
        // causes dependency loop :)
        //private MainWindowViewModel mainWindowViewModel;

        //private MainWindowViewModel MainWindowViewModel
        //{
        //    get
        //    {
        //        return mainWindowViewModel ?? (mainWindowViewModel = DependencyContainer.Resolve<MainWindowViewModel>());
        //    }
        //}

        // thus, we created another viewmodel that is subservient to mainWindowViewModel, let's call it PopupViewModel

        public PopupService(PopupsViewModel popupsViewModel)
        {
            PopupsViewModel = popupsViewModel;
        }

        public PopupsViewModel PopupsViewModel { get; }

        public void HideAllPopups()
        {
            PopupsViewModel.ShowAnyPopup = false;
            PopupsViewModel.FilePopupViewModel.ShowFileInfoPopup = false;
        }

        public void ShowFileInfoPopup(DiskFileItemModel fileInfo)
        {
            PopupsViewModel.ShowAnyPopup = true;

            PopupsViewModel.FilePopupViewModel = new FilePopupViewModel(this)
            {
                ShowFileInfoPopup = true,
                FileInfoDataContext = fileInfo
            };
        }
    }
}
