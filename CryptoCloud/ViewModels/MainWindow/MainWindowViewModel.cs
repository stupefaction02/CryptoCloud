using CryptoCloud.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using CryptoCloud.Services;
using CryptoCloud.Views;
using CommunityToolkit.Mvvm.Input;
using CryptoCloud.Infrastructure;
using CryptoCloud.Models;
using System.Collections;
using CryptoCloud.ViewModels.MainWindowViewModels;
using CryptoCloud.ViewModels.MainViewViewModels;

namespace CryptoCloud.ViewModels.MainWindowViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Window Chrome

        /// <summary>
        /// The window itself
        /// </summary>
        private MainWindow mainWindow;

        /// <summary>
        /// The margin raound the window allow for a drop shadow
        /// </summary>
        private int outerMarginSize = 6;

        /// <summary>
        /// The radius of the edges around the window
        /// </summary>
        private int windowRadius = 6;

        /// <summary>
        /// Size of resize border at each corner of the window
        /// </summary>
        public int ResizeBorder { get; set; } = 4;

        public int WindowMinimumHeight { get; set; }

        public int WindowMinimumWidht { get; set; }

        public Thickness OuterMarginSizeThickness => new Thickness(outerMarginSize + ResizeBorder);

        public int OuterMarginSize
        {
            get => mainWindow.WindowState == WindowState.Maximized ? 0 : outerMarginSize;
            set => outerMarginSize = value;
        }

        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder);

        public int WindowRadius
        {
            get => mainWindow.WindowState == WindowState.Maximized ? 0 : windowRadius;
            set => windowRadius = value;
        }

        public CornerRadius WindowCornerRadius => new CornerRadius(windowRadius);

        public int TitleHeight { get; set; } = 28;

        public GridLength TitleHeightLength { get => new GridLength(TitleHeight + ResizeBorder); }

        #endregion

        #region Commands

        public ICommand Minimize { get; set; }

        public ICommand Close { get; set; }

        #endregion

        #region Representation

        private Page currentPage;

        public Page CurrentPage { get => currentPage; set { currentPage = value; OnPropertyChanged("CurrentPage"); } }

        public ViewNavigationModel ViewNavigationModel { get; set; }

        private bool runInfoBarAnimation = false;

        public bool RunInfoBarAnimation
        {
            get => runInfoBarAnimation;
            set
            {
                runInfoBarAnimation = value;
                OnPropertyChanged(nameof(RunInfoBarAnimation));
            }
        }

        private bool hideInfoBar;

        public bool HideInfoBar
        {
            get { return hideInfoBar; }
            set { hideInfoBar = value; OnPropertyChanged(nameof(HideInfoBar)); }
        }

        public ViewModel CurrentView { get; set; }

        #endregion

        public PopupsViewModel PopupsViewModel { get; set; }
        public MainWindowContentViewModel ContentViewModel { get; set; }

        public MainWindowViewModel()
        {
            mainWindow = Application.Current.MainWindow as MainWindow;

            mainWindow.StateChanged += MainWindowStateChanged;

            Minimize = new RelayCommand(() => mainWindow.WindowState ^= WindowState.Minimized);
            Close = new RelayCommand(() => mainWindow.Close());

            PopupsViewModel = DependencyContainer.Resolve<PopupsViewModel>();
            ContentViewModel = DependencyContainer.Resolve<MainWindowContentViewModel>();

            var navigator = DependencyContainer.Resolve<MainWindowNavigator>();

            navigator.NavigateToView<LoginViewModel>();
        }

        private void MainWindowStateChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }
    }
}
