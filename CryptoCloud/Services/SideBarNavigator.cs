using CryptoCloud.Infrastructure;
using CryptoCloud.ViewModels;
using CryptoCloud.ViewModels.MainViewViewModels;
using Microsoft.Extensions.Logging;
using System.Security.Policy;

namespace CryptoCloud.Services
{
    /// <summary>
    /// Navigates to sidebar views associated with sidebar
    /// </summary>
    public class SideBarNavigator : Navigator
    {
        private readonly SideMenuViewModel sideMenuViewModel;
        MainViewContentViewModel contentViewModel;

        public SideBarNavigator(SideMenuViewModel sideMenuViewModel, ILoggerFactory loggerFactory)
            : base(loggerFactory.CreateLogger<SideBarNavigator>())
        {
            this.sideMenuViewModel = sideMenuViewModel;
        }

        public MainViewContentViewModel MainWindowViewModel
        {
            get
            {
                return contentViewModel = contentViewModel ?? DependencyContainer.Resolve<MainViewContentViewModel>();
            }
        }

        public override INavigationHostViewModel ViewModel => MainWindowViewModel;

        public void NavigateToItem(string name, object parameter)
        {
            var sideItem = sideMenuViewModel.MenuItems.SingleOrDefault(x => x.Name == name);
            var selectedItem = sideMenuViewModel.MenuItems.SingleOrDefault(x => x.IsSelected);

            if (sideItem != null)
            {
                if (selectedItem != null) 
                {
                    selectedItem.IsSelected = false;
                }

                switch (name)
                {
                    default:
                        break;
                }
            }
        }
    }
}
