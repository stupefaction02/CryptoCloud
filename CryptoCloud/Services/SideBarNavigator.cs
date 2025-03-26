using CryptoCloud.ViewModels;

namespace CryptoCloud.Services
{
    public class SideBarNavigator
    {
        private readonly SideMenuViewModel sideMenuViewModel;
        private readonly MainViewNavigator mainViewNavigator;

        public SideBarNavigator(SideMenuViewModel sideMenuViewModel, MainViewNavigator mainViewNavigator)
        {
            this.sideMenuViewModel = sideMenuViewModel;
            this.mainViewNavigator = mainViewNavigator;
        }

        public void NavigateToItem(string name, object parameter = null)
        {
            var clickedItem = sideMenuViewModel.MenuItems.SingleOrDefault(x => x.Name == name);
            var selectedItem = sideMenuViewModel.MenuItems.SingleOrDefault(x => x.IsSelected);

            if (clickedItem != null)
            {
                if (selectedItem != null)
                {
                    selectedItem.IsSelected = false;
                }

                clickedItem.IsSelected = true;

                switch (name)
                {
                    case "files":
                        mainViewNavigator.NavigateToView<DiskFilesViewModel>();
                        break;

                    case "myDisks":
                        mainViewNavigator.NavigateToView<MyDisksViewModel>();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
