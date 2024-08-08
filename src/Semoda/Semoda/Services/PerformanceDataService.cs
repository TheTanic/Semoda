using Semoda.Extensions;
using Semoda.Models;
using Semoda.Models.Events;
using Semoda.PerformanceDataCollector;
using Semoda.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Semoda.Services
{
    /// <summary>
    /// Concrete implementation of the <see cref="IPerformanceDataService"/>
    /// </summary>
    public class PerformanceDataService : IPerformanceDataService
    {
        private CancellationTokenSource _cts;
        private ConcurrentDictionary<PerformanceDataType, (int count, IPerformanceDataCollector performanceDataCollector)> _performanceDataCollectors;

        /// <summary>
        /// Stanard constructor.
        /// </summary>
        public PerformanceDataService()
        {
            _cts = new CancellationTokenSource();
            _performanceDataCollectors = new ConcurrentDictionary<PerformanceDataType, (int count, IPerformanceDataCollector performanceDataCollector)>();
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
            IPerformanceDataCollector? performanceDataCollector = dataType.ToPerformanceDataCollector();
            if (performanceDataCollector == null)
                return false;

            _performanceDataCollectors.AddOrUpdate(dataType, (1, performanceDataCollector), (k, v) => v = (v.count++, v.performanceDataCollector));
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
                    List<PerformanceDataType> keys = _performanceDataCollectors.Keys.ToList();
                    foreach (var key in keys)
                    {
                        if (_performanceDataCollectors.TryGetValue(key, out var value))
                        {
                            NewPerformanceDataEvent?.Invoke(this, new PerformanceDataEventArgs()
                            {
                                PerformanceDataType = key,
                                Value = await value.performanceDataCollector.CollectAsync(),
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
}