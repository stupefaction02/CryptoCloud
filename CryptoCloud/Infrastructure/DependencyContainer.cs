using CryptoCloud.Services;
using CryptoCloud.Validators;
using CryptoCloud.ViewModels;
using CryptoCloud.ViewModels.MainView;
using CryptoCloud.ViewModels.MainWindowViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CryptoCloud.Infrastructure
{
    public class DependencyContainer
    {
        private static readonly ServiceCollection services = new ServiceCollection();

        static DependencyContainer()
        {
            services.ConfigureLoggerFactory();

            services.AddSingleton<ApplicationInfoManager>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LinkDiskViewModel>();
            services.AddSingleton<LinkDiskHeaderViewModel>();
            services.AddSingleton<SideMenuViewModel>();
            services.AddSingleton<MyDisksViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<DiskFilesViewModel>();
            services.AddSingleton<FilesEncryptionProgressInfoViewModel>();
            services.AddSingleton<MainWindowNavigator>();
            services.AddSingleton<PopupsViewModel>();
            services.AddSingleton<NavigationViewModel>();

            services.AddSingleton<IPopupService, PopupService>();
            services.AddSingleton<UserModelValidator>();

            serviceProvider = new Lazy<IServiceProvider>(services.BuildServiceProvider());
        }

        private static readonly Lazy<IServiceProvider> serviceProvider;

        public static T Resolve<T>() => serviceProvider.Value.GetRequiredService<T>();
    }

    public static class ServicesExtrensions
    {
        public static void ConfigureLoggerFactory(this IServiceCollection services)
        {
            var lf = LoggerFactory.Create((builder) =>
            {
                builder.AddDebug().SetMinimumLevel(LogLevel.Trace);
            });

            services.AddSingleton(lf);
        }
    }
}
