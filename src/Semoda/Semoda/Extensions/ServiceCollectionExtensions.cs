using Microsoft.Extensions.DependencyInjection;
using Semoda.Services;
using Semoda.Services.Interfaces;
using Semoda.ViewModels;

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
            //Services
            collection.AddSingleton<IPerformanceDataService, PerformanceDataService>();

            //ViewModels
            collection.AddSingleton<MainWindowViewModel>();
            collection.AddSingleton<DashboardPageViewModel>();
            collection.AddSingleton<SettingsPageViewModel>();
        }
    }
}