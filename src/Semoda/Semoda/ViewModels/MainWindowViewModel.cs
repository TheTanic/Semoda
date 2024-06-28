using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Semoda.Assets.Languages;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Semoda.ViewModels
{
    /// <summary>
    /// View model for the <see cref="MainWindowViewModel"/>
    /// </summary>
    public partial class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Holds the current viewed page of the splitview.
        /// </summary>
        [ObservableProperty]
        private ViewModelBase? _currentPage;

        /// <summary>
        /// Flag to indicate if the splitview pane is open. <br/>
        /// The default is <see langword="false"/>
        /// </summary>
        [ObservableProperty]
        private bool _isPaneOpen = false;

        /// <summary>
        /// Marker to the currently selected menu item of the splitview pane.
        /// </summary>
        [ObservableProperty]
        private MenuListItemViewModel _selectedMenuItem;

        /// <summary>
        /// Default constructor. <br/>
        /// Sets the current selected menu item to the first.
        /// </summary>
        public MainWindowViewModel()
        {
            SelectedMenuItem = MenuItems.First();
        }

        /// <summary>
        ///Collection of all available <see cref="MenuListItemViewModel"/> of the splitview pane.
        /// </summary>
        public ObservableCollection<MenuListItemViewModel> MenuItems { get; } = new ObservableCollection<MenuListItemViewModel>()
        {
            new MenuListItemViewModel(typeof(DashboardPageViewModel), "Dashboard", Resources.MenuEntryDashboard),
            new MenuListItemViewModel(typeof(SettingsPageViewModel), "Settings", Resources.MenuEntrySettings)
        };

        /// <summary>
        /// Handler to react on a change of <see cref="SelectedMenuItem"/>.
        /// </summary>
        /// <param name="value">The new value of <see cref="SelectedMenuItem"/></param>
        partial void OnSelectedMenuItemChanged(MenuListItemViewModel value)
        {
            if (value == null)
                return;

            object? instance = Activator.CreateInstance(value.ModelType);
            if (instance == null || instance is not ViewModelBase)
                return;

            CurrentPage = (ViewModelBase)instance;
            IsPaneOpen = false;
        }

        /// <summary>
        /// Command to handle a click on the hamburger menu.
        /// </summary>
        [RelayCommand]
        private void TriggerHamburger()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }
}