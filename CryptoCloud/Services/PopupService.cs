using CryptoCloud.Infrastructure;
using CryptoCloud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.Services
{
    public class PopupService : IPopupService
    {
        private MainWindowViewModel mainWindowViewModel;

        private MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return mainWindowViewModel ?? (mainWindowViewModel = DependencyContainer.Resolve<MainWindowViewModel>());
            }
        }

        public PopupService()
        {
        }

        public void ShowFileInfoPopup(DiskFileItemModel fileInfo)
        {
            
        }
    }
}
