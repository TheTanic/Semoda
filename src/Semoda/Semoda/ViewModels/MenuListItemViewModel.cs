using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Semoda.Views;
using System;

namespace Semoda.ViewModels
{
    /// <summary>
    /// View model for the menu entries of the <see cref="MainWindow"/> splitview pane.
    /// </summary>
    public class MenuListItemViewModel
    {
        /// <summary>
        /// Constructor to initialize the view model
        /// </summary>
        /// <param name="type">Type of the viewmodel, which is linked to the menu</param>
        /// <param name="iconKey">Key of the icon, which should be presented</param>
        /// <param name="label">Value of the label that should be displayed</param>
        public MenuListItemViewModel(Type type, string iconKey, string label)
        {
            ModelType = type;
            Label = label;
            Application.Current!.TryFindResource(iconKey, out var res);
            if (res != null && res is StreamGeometry)
                Icon = (StreamGeometry)res;
        }

        /// <summary>
        /// Icon of the menu entry
        /// </summary>
        public StreamGeometry? Icon { get; } = null;

        /// <summary>
        /// Label of the menu entry
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Linked type of the menu entry
        /// </summary>
        public Type ModelType { get; }
    }
}