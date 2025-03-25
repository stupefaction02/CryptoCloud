using CryptoCloud.Infrastructure;
using CryptoCloud.ViewModels;
using CryptoCloud.ViewModels.MainView;
using CryptoCloud.ViewModels.MainWindowViewModels;
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
        public MainViewModel MainViewModel => DependencyContainer.Resolve<MainViewModel>();
        public DiskFilesViewModel DiskFilesViewModel => DependencyContainer.Resolve<DiskFilesViewModel>();
        public FilesEncryptionProgressInfoViewModel FilesEncryptionProgressInfoViewModel => DependencyContainer.Resolve<FilesEncryptionProgressInfoViewModel>();

        //public OverviewViewModel OverviewViewModel => DependencyContainer.Resolve<OverviewViewModel>();

    }
}
