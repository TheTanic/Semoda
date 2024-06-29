using Semoda.Models.Events;
using Semoda.Services.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Semoda.Services
{
#pragma warning disable CA1416 // Validate platform compatibility

    /// <summary>
    /// Concrete implementation of the <see cref="IPerformanceDataService"/>
    /// </summary>
    public class PerformanceDataService : IPerformanceDataService
    {
        private CancellationTokenSource _cts;

        /// <summary>
        /// Stanard constructor.
        /// </summary>
        public PerformanceDataService()
        {
            _cts = new CancellationTokenSource();
        }

        private event EventHandler<PerformanceDataEventArgs>? NewPerformanceDataEvent = null;

        /// <inheritdoc/>
        public Task<bool> DeregisterAsync(Action<object, PerformanceDataEventArgs> eventHandler)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<bool> RegisterAsync(EventHandler<PerformanceDataEventArgs> eventHandler)
        {
            NewPerformanceDataEvent += eventHandler;
            return Task.FromResult(true);
        }

        /// <inheritdoc/>
        public async Task StartAsync()
        {
            _ = Task.Run(async () =>
            {
                PerformanceCounter cpuPerformance = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                while (!_cts.IsCancellationRequested)
                {
                    await Task.Delay(1000);
                    NewPerformanceDataEvent?.Invoke(this, new PerformanceDataEventArgs()
                    {
                        Unit = "%",
                        Value = cpuPerformance.NextValue()
                    });
                }
            }, _cts.Token);
        }

        /// <inheritdoc/>
        public async Task StopAsync()
        {
            await _cts.CancelAsync();
        }
    }

#pragma warning restore CA1416 // Validate platform compatibility
}