using Semoda.Models;
using Semoda.Models.Events;
using System;
using System.Threading.Tasks;

namespace Semoda.Services.Interfaces
{
    /// <summary>
    /// Interface to define a service, which collects and publishes performance data.
    /// </summary>
    public interface IPerformanceDataService
    {
        /// <summary>
        /// Deregister at the service, to get norified about new events.
        /// </summary>
        /// <param name="eventHandler">Registered handler for the <see cref="PerformanceDataEventArgs"/></param>
        /// <returns><see langword="true"/> if the handler could be deregistered. <see langword="false"/> otherwise.</returns>
        Task<bool> DeregisterAsync(Action<object, PerformanceDataEventArgs> eventHandler);

        /// <summary>
        /// Register at the service, to get norified about new events.
        /// </summary>
        /// <param name="eventHandler">Handler for the <see cref="PerformanceDataEventArgs"/></param>
        /// <param name="dataType"></param>
        /// <returns><see langword="true"/> if the handler could be registered. <see langword="false"/> otherwise.</returns>
        Task<bool> RegisterAsync(EventHandler<PerformanceDataEventArgs> eventHandler, PerformanceDataType dataType);

        /// <summary>
        /// Start the collection of performance data.
        /// </summary>
        /// <returns></returns>
        Task StartAsync();

        /// <summary>
        /// Stop the collection of performance data.
        /// </summary>
        /// <returns></returns>
        Task StopAsync();
    }
}