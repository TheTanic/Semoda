using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Semoda.Models;
using Semoda.ViewModels;
using System.IO;

namespace Semoda.Extensions
{
    /// <summary>
    /// Extensions for the <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the common appservice to the <see cref="IServiceCollection"/>
        /// </summary>
        /// <param name="collection">Collection, where the services should be added.</param>
        public static void AddAppServices(this IServiceCollection collection)
        {
            //ViewModels
            collection.AddSingleton<MainWindowViewModel>();
            collection.AddSingleton<DashboardPageViewModel>();
            collection.AddSingleton<SettingsPageViewModel>();

            {
                // Load settings from JSON and add for dependency injection
                var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .Build();

                var appSettings = new AppSettingsModel();
                configuration.Bind(appSettings);
                collection.AddSingleton(appSettings);
            }
        }
    }
}