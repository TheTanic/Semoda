using Semoda.Extensions;
using Semoda.Models;
using Semoda.Models.Events;
using Semoda.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Semoda.Services
{
//#pragma warning disable CA1416 // Validate platform compatibility

    /// <summary>
    /// Concrete implementation of the <see cref="IPerformanceDataService"/>
    /// </summary>
    public class PerformanceDataService : IPerformanceDataService
    {
        private CancellationTokenSource _cts;
        private ConcurrentDictionary<PerformanceDataType, (int count, PerformanceCounter performanceCounter)> _performanceCounter;

        /// <summary>
        /// Stanard constructor.
        /// </summary>
        public PerformanceDataService()
        {
            _cts = new CancellationTokenSource();
            _performanceCounter = new ConcurrentDictionary<PerformanceDataType, (int count, PerformanceCounter performanceCounter)>();
        }

        private event EventHandler<PerformanceDataEventArgs>? NewPerformanceDataEvent = null;

        /// <inheritdoc/>
        public Task<bool> DeregisterAsync(Action<object, PerformanceDataEventArgs> eventHandler)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<bool> RegisterAsync(EventHandler<PerformanceDataEventArgs> eventHandler, PerformanceDataType dataType)
        {
            PerformanceCounter? performanceCounter = dataType.ToPerformanceCounter();
            if (performanceCounter == null)
                return false;

            _performanceCounter.AddOrUpdate(dataType, (1, performanceCounter), (k, v) => v = (v.count++, v.performanceCounter));
            NewPerformanceDataEvent += eventHandler;
            return await Task.FromResult(true);
        }

        /// <inheritdoc/>
        public Task StartAsync()
        {
            return Task.Run(async () =>
            {
                while (!_cts.IsCancellationRequested)
                {
                    await Task.Delay(1000);
                    List<PerformanceDataType> keys = _performanceCounter.Keys.ToList();
                    foreach (var key in keys)
                    {
                        if(_performanceCounter.TryGetValue(key, out var value))
                        {
                            NewPerformanceDataEvent?.Invoke(this, new PerformanceDataEventArgs()
                            {
                                PerformanceDataType = key,
                                Value = value.performanceCounter.NextValue(),
                                Unit = key.GetDefaultUnit()
                            });
                        }
                    }
                }
            }, _cts.Token);
        }

        /// <inheritdoc/>
        public async Task StopAsync()
        {
            await _cts.CancelAsync();
        }
    }

//#pragma warning restore CA1416
}