using CommunityToolkit.Mvvm.Input;
using CryptoCloud.Services;
using CryptoCloud.ViewModels.MainView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CryptoCloud.ViewModels
{
    public class LinkDiskViewModel : BaseViewModel
    {
        private readonly Navigator navigator;

        public ICommand LinkDiskCommand { get; set; }

        public LinkDiskViewModel(MainWindowNavigator navigator)
        {
            LinkDiskCommand = new RelayCommand(LinkDiskCommandHandler);
            this.navigator = navigator;
        }

        private void LinkDiskCommandHandler()
        {
            navigator.NavigateToView<MainViewModel>();
        }
    }
}
