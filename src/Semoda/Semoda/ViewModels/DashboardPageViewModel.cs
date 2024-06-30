using Microsoft.Extensions.DependencyInjection;
using Semoda.Models.Events;
using Semoda.Services.Interfaces;
using Semoda.Views.Pages;
using System;
using System.Diagnostics;

namespace Semoda.ViewModels
{
    /// <summary>
    /// View model for the <see cref="DashboardPage"/>.
    /// </summary>
    public class DashboardPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Default constructor. <br/>
        /// Sets the <see cref="ViewModelBase.IsPage"/> to <see langword="true"/>
        /// </summary>
        public DashboardPageViewModel() : base(true)
        {

            IPerformanceDataService dataService = ServiceProvider.GetRequiredService<IPerformanceDataService>();

            _ = dataService.RegisterAsync(HandleNewPerformanceData, Models.PerformanceDataType.TotalCPUUtilization).ContinueWith((t) =>
            {
                _ = dataService.StartAsync();
            });
        }

        private void HandleNewPerformanceData(object? sender, PerformanceDataEventArgs args)
        {
            Debug.WriteLine($"{args.Value} {args.Unit}");
        }
    }
}