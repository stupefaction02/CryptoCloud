using CryptoCloud.Infrastructure;
using CryptoCloud.ViewModels;
using CryptoCloud.ViewModels.MainViewViewModels;
using CryptoCloud.ViewModels.MainWindowViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.Services
{
    /// <summary>
    /// View model which content may be changed.
    /// </summary>
    public interface IHaveContentViewModel
    {
        public BaseViewModel CurrentContent { get; set; }
    }

    public class Navigator
    {
        public virtual IHaveContentViewModel? ViewModel { get; }

        public void NavigateToView<T>() where T : BaseViewModel
        {
            var currentView = loadViewDataContext<T>();

            ViewModel.CurrentContent = currentView;
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

    /// <summary>
    /// To navigate between views in MainWindow area
    /// </summary>
    public class MainWindowNavigator : Navigator
    {
        MainWindowContentViewModel contentViewModel;
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
