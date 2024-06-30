using Semoda.Models;
using Semoda.PerformanceDataCollector;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Semoda.Extensions
{
    /// <summary>
    /// Extensions for the <see cref="PerformanceDataType"/>
    /// </summary>
    public static class PerformanceDataTypeExtensions
    {
        /// <summary>
        /// Convert the data type to a <see cref="IPerformanceDataCollector"/>
        /// </summary>
        /// <param name="dataType">Type to convert</param>
        /// <returns>The corresponding <see cref="IPerformanceDataCollector"/> of the dataType.
        /// <see langword="null"/> if there is no linked <see cref="IPerformanceDataCollector"/>.</returns>
        public static IPerformanceDataCollector? ToPerformanceDataCollector(this PerformanceDataType dataType)
        {
            switch (dataType)
            {
                case PerformanceDataType.TotalCPUUtilization:
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        return new PerformanceDataCollectorWindows(new PerformanceCounter("Processor Information", "% Processor Utility", "_Total"));
                    break;

                case PerformanceDataType.TotalRAMAvailable:
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        return new PerformanceDataCollectorWindows(new PerformanceCounter("Memory", "Available MBytes"));
                    break;

                case PerformanceDataType.CPUTemperature:
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        return new PerformanceDataCollectorWindows(new PerformanceCounter("Thermal Zone Information", "Temperature", "_TZ.THRM"));
                    break;

                default:
                    return null;
            }
            return null;
        }

        /// <summary>
        /// Get the default unit for the <see cref="PerformanceDataType"/>
        /// </summary>
        /// <param name="dataType">Type of which the unit should be gathered.</param>
        /// <returns>The default unit of the dataType. An empty string if there is no default unit.</returns>
        public static string GetDefaultUnit(this PerformanceDataType dataType)
        {
            switch (dataType)
            {
                case PerformanceDataType.TotalCPUUtilization:
                    return "%";

                case PerformanceDataType.TotalRAMAvailable:
                    return "MB";

                case PerformanceDataType.CPUTemperature:
                    return "°C";

                default:
                    return "";
            }
        }
    }
}