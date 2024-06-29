using Semoda.Services.Interfaces;
using System;

namespace Semoda.Models.Events
{
    /// <summary>
    /// EventArgs for new peformance data. This event is fired by the <see cref="IPerformanceDataService"/>
    /// </summary>
    public class PerformanceDataEventArgs : EventArgs
    {
        /// <summary>
        /// Unit of the performance data
        /// </summary>
        public string Unit { get; init; } = "";

        /// <summary>
        /// Value of the performance data
        /// </summary>
        public double Value { get; init; }
    }
}