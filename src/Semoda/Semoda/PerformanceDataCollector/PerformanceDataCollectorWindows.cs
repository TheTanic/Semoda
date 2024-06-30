using System.Diagnostics;
using System.Threading.Tasks;

namespace Semoda.PerformanceDataCollector
{
    /// <summary>
    /// Concrete implementation of the <see cref="IPerformanceDataCollector"/> for windows.
    /// </summary>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class PerformanceDataCollectorWindows : IPerformanceDataCollector
    {
        private PerformanceCounter _performanceCounter;

        /// <summary>
        /// Default constructor. Sets the <see cref="PerformanceCounter"/>
        /// </summary>
        /// <param name="performanceCounter">The underlying performance counter</param>
        public PerformanceDataCollectorWindows(PerformanceCounter performanceCounter)
        {
            _performanceCounter = performanceCounter;
        }

        /// <inheritdoc/>
        public async Task<float?> CollectAsync()
        {
            return await Task.FromResult(_performanceCounter.NextValue());
        }
    }
}