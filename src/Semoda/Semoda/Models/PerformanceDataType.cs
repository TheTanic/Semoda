namespace Semoda.Models
{
    /// <summary>
    /// Enum to hold the difference type of perfomance data
    /// </summary>
    public enum PerformanceDataType
    {
        /// <summary>
        /// Total percentage of cpu utilization
        /// </summary>
        TotalCPUUtilization,

        /// <summary>
        /// Temperature of the cpu
        /// </summary>
        CPUTemperature,

        /// <summary>
        /// Total available memory
        /// </summary>
        TotalRAMAvailable,
    }
}