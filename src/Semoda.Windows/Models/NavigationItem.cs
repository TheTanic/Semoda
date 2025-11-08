using Microsoft.UI.Xaml.Controls;
using System;

namespace Semoda.Windows.Models
{
    /// <summary>
    /// Class representing a navigation item in the application's navigation view.
    /// </summary>
    public class NavigationItem
    {
        /// <summary>
        /// Icon to be displayed for the navigation item.
        /// </summary>
        public required FontIcon Icon { get; set; }

        /// <summary>
        /// Label for the navigation item.
        /// </summary>
        public required string Label { get; set; }

        /// <summary>
        /// Page type to navigate to when the item is selected.
        /// </summary>
        public required Type PageType { get; set; }
    }
}