using CryptoCloud.Infrastructure;
using CryptoCloud.Models;
using CryptoCloud.ViewModels.MainViewViewModels;
using CryptoCloud.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels.MainView
{
    public class MainViewModel : BaseViewModel
    {
        public ViewNavigationModel ViewNavigationModel { get; set; }
        public MainViewContentViewModel NavigationViewModel { get; set; }

        public MainViewModel()
        {
            ViewNavigationModel = new ViewNavigationModel { DataContext = DependencyContainer.Resolve<DiskFilesViewModel>(), ViewKey = "DiskFiles" };
        }
    }
}
