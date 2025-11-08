using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Semoda.Windows.Models;
using Semoda.Windows.ViewModels;
using Semoda.Windows.Views.Pages;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Semoda.Windows.Views.Windows
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        /// <summary>
        /// Corresponding <see cref="MainWindowViewModel"/>.
        /// </summary>
        public MainWindowViewModel ViewModel { get; }

        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            // Get the ViewModel from the service provider.
            ViewModel = viewModel;

            // Register for navigation requests from the ViewModel.
            ViewModel.NavigationRequested += NavigationRequested;

            // Navigate to the default page.
            NavigationRequested(this, ViewModel.SelectedItem?.PageType ?? typeof(DashboardPage));
        }

        /// <summary>
        /// Navigate to the requested page type.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Contentframe type</param>
        private void NavigationRequested(object? sender, Type e)
        {
            ContentFrame.Navigate(e);
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                if(ViewModel.InvokeSettingsCommand.CanExecute(null))
                    ViewModel.InvokeSettingsCommand.Execute(null);
                return;
            }

            if (args.SelectedItem is NavigationItem item)
            {
                if (ViewModel.ItemInvokedCommand.CanExecute(item))
                    ViewModel.ItemInvokedCommand.Execute(item);
                return;
            }
        }
    }
}