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

            _ = dataService.RegisterAsync(HandleNewData, Models.PerformanceDataType.TotalCPUUtilization).ContinueWith((t) =>
            {
                _ = dataService.StartAsync();
                _ = dataService.RegisterAsync(HandleNewData, Models.PerformanceDataType.TotalRAMAvailable);
            });
        }

        private void HandleNewData(object? sender, PerformanceDataEventArgs args)
        {
            switch (args.PerformanceDataType)
            {
                case Models.PerformanceDataType.TotalRAMAvailable:
                    Debug.WriteLine($"{args.PerformanceDataType}: {args.Value} {args.Unit} / {SystemInfoUtil.GetTotalPhysicalMemoryMB()} {args.Unit}");
                    break;

                default:
                    Debug.WriteLine($"{args.PerformanceDataType}: {args.Value} {args.Unit}");
                    break;
            }
        }
    }
}