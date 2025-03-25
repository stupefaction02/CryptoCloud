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

        public PopupService()
        {
        }

        public void ShowFileInfoPopup(DiskModel fileInfo)
        {
            
        }
    }
}
