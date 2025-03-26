using CryptoCloud.Infrastructure;
using CryptoCloud.Models;
using CryptoCloud.Services;
using CryptoCloud.ViewModels.MainViewViewModels;
using CryptoCloud.ViewModels.MainWindowViewModels;
using CryptoCloud.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels.MainView
{
    public class MainViewModel : ViewModel
    {
        private readonly SideBarNavigator navigator;

        public MainViewContentViewModel ContentViewModel { get; set; }

        public MainViewModel(SideBarNavigator navigator)
        {
            ContentViewModel = DependencyContainer.Resolve<MainViewContentViewModel>();

            this.navigator = navigator;

            navigator.NavigateToView<DiskFilesViewModel>();
        }
    }
}
