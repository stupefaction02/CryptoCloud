using CryptoCloud.Infrastructure;
using CryptoCloud.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCloud.Infrastructure
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => DependencyContainer.Resolve<MainWindowViewModel>();
        public LoginViewModel LoginViewModel => DependencyContainer.Resolve<LoginViewModel>();
        public SideMenuViewModel SideMenuViewModel => DependencyContainer.Resolve<SideMenuViewModel>();
        public MyDisksViewModel MyDiskViewModel => DependencyContainer.Resolve<MyDisksViewModel>();

        //public OverviewViewModel OverviewViewModel => DependencyContainer.Resolve<OverviewViewModel>();

    }
}
