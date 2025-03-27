using CommunityToolkit.Mvvm.Input;
using CryptoCloud.ViewModels.MainWindowViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CryptoCloud.ViewModels
{
    public class PopupsViewModel : ViewModel
    {
        public ICommand PopupsRootClickCommand { get; set; }

        public bool showAnyPopup { get; set; }

        /// <summary>
        /// Attach veil to the screen to block all other clicks instead of click on popups
        /// </summary>
        public bool ShowAnyPopup
        {
            get => showAnyPopup;
            set
            {
                showAnyPopup = value;
                OnPropertyChanged(nameof(ShowAnyPopup));
            }
        }

        private bool makeScreenDark { get; set; }

        /// <summary>
        /// Make the veil dark
        /// </summary>
        public bool MakeScreenDark
        {
            get => makeScreenDark;
            set
            {
                makeScreenDark = value;
                OnPropertyChanged(nameof(MakeScreenDark));
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

        private FilesEncryptionProgressInfoViewModel filesEncryptionProgressInfoViewModel { get; set; }

        public FilesEncryptionProgressInfoViewModel FilesEncryptionProgressInfoViewModel
        {
            get => filesEncryptionProgressInfoViewModel;
            set
            {
                filesEncryptionProgressInfoViewModel = value;
                OnPropertyChanged(nameof(FilesEncryptionProgressInfoViewModel));
            }
        }

        public PopupsViewModel()
        {
            PopupsRootClickCommand = new RelayCommand(() => HideAll());
        }

        private void HideAll()
        {
            ShowAnyPopup = false;

            if (flePopupViewModel != null)
            {
                flePopupViewModel.ShowFileInfoPopup = false;
            }

            if (filesEncryptionProgressInfoViewModel != null)
            {
                filesEncryptionProgressInfoViewModel.IsPopupShown = false;
            }
        }
    }
}
