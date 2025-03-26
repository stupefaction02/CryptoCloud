using CryptoCloud.Infrastructure;
using CryptoCloud.ViewModels.MainViewViewModels;
using Microsoft.Extensions.Logging;
using System.Security.Policy;

namespace CryptoCloud.Services
{

    /// <summary>
    /// Navigates to sidebar views associated with sidebar
    /// </summary>
    public class MainViewNavigator : Navigator
    {
        MainViewContentViewModel contentViewModel;

        public MainViewNavigator(ILoggerFactory loggerFactory)
            : base(loggerFactory.CreateLogger<MainViewNavigator>())
        {
        }

        public MainViewContentViewModel MainWindowViewModel
        {
            get
            {
                return contentViewModel = contentViewModel ?? DependencyContainer.Resolve<MainViewContentViewModel>();
            }
        }

        public override INavigationHostViewModel ViewModel => MainWindowViewModel;
    }
}
