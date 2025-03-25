using CryptoCloud.Infrastructure;
using CryptoCloud.ViewModels;
using CryptoCloud.ViewModels.MainViewViewModels;
using CryptoCloud.ViewModels.MainWindowViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.Services
{
    /// <summary>
    /// View model which content may be changed.
    /// </summary>
    public interface IHaveContentViewModel
    {
        public ViewModel CurrentContent { get; set; }
    }

    public class Navigator
    {
        ILogger logger;
        public Navigator(ILogger logger)
        {
            this.logger = logger;
        }

        public virtual IHaveContentViewModel? ViewModel { get; }

        public void NavigateToView<T>() where T : ViewModel
        {
            var currentView = loadViewDataContext<T>();

            if (currentView != null)
            {
                ViewModel.CurrentContent = currentView;

                logger.LogInformation($"Changed view to {ViewModel.CurrentContent.NavigationId}");
            }
        }

        private Dictionary<string, ViewModel> viewModels = new Dictionary<string, ViewModel>();
        private T? loadViewDataContext<T>() where T : ViewModel
        {
            // here we decide what view models we want to store and what we want to recreate every time navigation request was fired

            string typeName = typeof(T).Name;

            // create if none and store for future use
            ViewModel vm = null;
            if (!viewModels.TryGetValue(typeName, out vm))
            {
                vm = DependencyContainer.Resolve<T>();
                vm.NavigationId = typeName;
                viewModels.Add(typeName, vm);
            }

            return vm as T;
        }
    }

    /// <summary>
    /// To navigate between views in MainWindow area
    /// </summary>
    public class MainWindowNavigator : Navigator
    {
        MainWindowContentViewModel contentViewModel;

        public MainWindowNavigator(ILoggerFactory loggerFactory) 
            : base(loggerFactory.CreateLogger<MainWindowNavigator>())
        {
        }

        public MainWindowContentViewModel MainWindowViewModel
        {
            get
            {
                return contentViewModel = contentViewModel ?? DependencyContainer.Resolve<MainWindowContentViewModel>();
            }
        }

        public override IHaveContentViewModel ViewModel => MainWindowViewModel;
    }

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

        public override IHaveContentViewModel ViewModel => MainWindowViewModel;
    }
}
