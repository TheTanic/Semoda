using System.Threading.Tasks;

namespace Semoda.PerformanceDataCollector
{
    /// <summary>
    /// Interface for performance data collector.
    /// </summary>
    public interface IPerformanceDataCollector
    {
        /// <summary>
        /// Collect a new value.
        /// </summary>
        /// <returns>The current value of the performance data. <see langword="null"/> if there is no data</returns>
        Task<float?> CollectAsync();
    }
}