using Semoda.Models;
using System.Diagnostics;

namespace Semoda.Extensions
{
#pragma warning disable CA1416 // Validate platform compatibility

    /// <summary>
    /// Extensions for the <see cref="PerformanceDataType"/>
    /// </summary>
    public static class PerformanceDataTypeExtensions
    {
        /// <summary>
        /// Convert the data type to a <see cref="PerformanceCounter"/>
        /// </summary>
        /// <param name="dataType">Type to convert</param>
        /// <returns>The corresponding <see cref="PerformanceCounter"/> of the dataType.
        /// <see langword="null"/> if there is no linked <see cref="PerformanceCounter"/>.</returns>
        public static PerformanceCounter? ToPerformanceCounter(this PerformanceDataType dataType)
        {
            switch (dataType)
            {
                case PerformanceDataType.TotalCPUUtilization:
                    return new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");

                default:
                    return null;
            }
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

                default:
                    return "";
            }
        }
    }

#pragma warning restore CA1416
}