using CryptoCloud.Services;
using CryptoCloud.ViewModels;
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
            services.AddSingleton<Navigation>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LinkDiskViewModel>();
            services.AddSingleton<LinkDiskHeaderViewModel>();
            services.AddSingleton<SideMenuViewModel>();
            services.AddSingleton<MyDisksViewModel>();
            services.AddSingleton<MainViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static ServiceProvider serviceProvider { get; }

        public static T Resolve<T>() => serviceProvider.GetRequiredService<T>();
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
