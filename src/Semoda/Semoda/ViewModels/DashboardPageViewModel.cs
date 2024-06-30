using Microsoft.Extensions.DependencyInjection;
using Semoda.Models.Events;
using Semoda.Services.Interfaces;
using Semoda.Utils;
using Semoda.Views.Pages;
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

            _ = dataService.RegisterAsync(HandleCPUUtilization, Models.PerformanceDataType.TotalCPUUtilization).ContinueWith((t) =>
            {
                _ = dataService.StartAsync();
                _ = dataService.RegisterAsync(HandleRAMAvailable, Models.PerformanceDataType.TotalRAMAvailable);
                _ = dataService.RegisterAsync(HandleCPUTemp, Models.PerformanceDataType.CPUTemperature);
            });
        }

        private void HandleCPUTemp(object? sender, PerformanceDataEventArgs args)
        {
            if (args.PerformanceDataType == Models.PerformanceDataType.CPUTemperature)
                Debug.WriteLine($"{args.PerformanceDataType}: {args.Value} {args.Unit}");
        }

        private void HandleCPUUtilization(object? sender, PerformanceDataEventArgs args)
        {
            if (args.PerformanceDataType == Models.PerformanceDataType.TotalCPUUtilization)
                Debug.WriteLine($"{args.PerformanceDataType}: {args.Value} {args.Unit}");
        }

        private void HandleRAMAvailable(object? sender, PerformanceDataEventArgs args)
        {
            if (args.PerformanceDataType == Models.PerformanceDataType.TotalRAMAvailable)
                Debug.WriteLine($"{args.PerformanceDataType}: {args.Value} {args.Unit} / {SystemInfoUtil.GetTotalPhysicalMemoryMB()} {args.Unit}");
        }
    }
}