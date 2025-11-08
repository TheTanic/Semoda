using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Semoda.Windows.Models;
using Semoda.Windows.Views.Pages;
using Semoda.Windows.Views.Windows;
using System;
using System.Collections.ObjectModel;

namespace Semoda.Windows.ViewModels
{
    /// <summary>
    /// ViewModel for <see cref="MainWindow"/>
    /// </summary>
    public partial class MainWindowViewModel : ObservableObject
    {
        /// <summary>
        /// List of available navigation items.
        /// </summary>
        public ObservableCollection<NavigationItem> MenuItems { get; } = new()
        {
            new NavigationItem { Label = "Dashboard", Icon = new FontIcon(){ Glyph = "\uF246" }, PageType = typeof(DashboardPage) },
        };

        /// <summary>
        /// Currently selected navigation item.
        /// </summary>
        [ObservableProperty]
        private NavigationItem? _selectedItem;

        /// <summary>
        /// Constructor of the MainViewModel. Sets the default selected item to the first item of the MenuItems collection.
        /// </summary>
        public MainWindowViewModel()
        {
            SelectedItem = MenuItems[0];
        }

        /// <summary>
        /// Event to request navigation to a different page.
        /// </summary>
        public event EventHandler<Type>? NavigationRequested;

        [RelayCommand]
        private void InvokeSettings()
        {
            SelectedItem = null;
            NavigationRequested?.Invoke(this, typeof(SettingsPage));
        }

        [RelayCommand]
        private void ItemInvoked(NavigationItem item)
        {
            if (item == SelectedItem)
                return;
            NavigationRequested?.Invoke(this, item.PageType);
        }
    }
}