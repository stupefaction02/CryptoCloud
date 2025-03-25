using CryptoCloud.Infrastructure;
using CryptoCloud.ViewModels;
using CryptoCloud.ViewModels.MainWindowViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.Services
{
    /// <summary>
    /// To navigate between views in MainWindow area
    /// </summary>
    public class MainWindowNavigator
    {
        NavigationViewModel contentViewModel;
        public NavigationViewModel MainWindowViewModel 
        {
            get
            {
                return contentViewModel = contentViewModel ?? DependencyContainer.Resolve<NavigationViewModel>();
            }
        }

        public void NavigateToView<T>() where T : BaseViewModel
        {
            var currentView = loadViewDataContext<T>();

            MainWindowViewModel.Content = currentView;
        }

        private Dictionary<string, BaseViewModel> viewModels = new Dictionary<string, BaseViewModel>();
        private T? loadViewDataContext<T>() where T : BaseViewModel
        {
            // here we decide what view models we want to store and what we want to recreate every time navigation request was fired

            string typeName = typeof(T).Name;

            // create if none and store for future use
            BaseViewModel vm = null;
            if (!viewModels.TryGetValue(typeName, out vm))
            {
                vm = DependencyContainer.Resolve<T>();
                vm.NavigationId = typeName;
                viewModels.Add(typeName, vm);
            }

            return vm as T;
        }
    }

    public class MainViewNavigator
    {
        NavigationViewModel contentViewModel;
        public NavigationViewModel MainWindowViewModel
        {
            get
            {
                return contentViewModel = contentViewModel ?? DependencyContainer.Resolve<NavigationViewModel>();
            }
        }

        public void NavigateToView<T>() where T : BaseViewModel
        {
            var currentView = loadViewDataContext<T>();

            MainWindowViewModel.Content = currentView;
        }

        private Dictionary<string, BaseViewModel> viewModels = new Dictionary<string, BaseViewModel>();
        private T? loadViewDataContext<T>() where T : BaseViewModel
        {
            // here we decide what view models we want to store and what we want to recreate every time navigation request was fired

            string typeName = typeof(T).Name;

            // create if none and store for future use
            BaseViewModel vm = null;
            if (!viewModels.TryGetValue(typeName, out vm))
            {
                vm = DependencyContainer.Resolve<T>();
                vm.NavigationId = typeName;
                viewModels.Add(typeName, vm);
            }

            return vm as T;
        }
    }
}
