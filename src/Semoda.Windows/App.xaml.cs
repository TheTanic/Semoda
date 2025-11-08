using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Semoda.Windows.ViewModels;
using Semoda.Windows.Views.Pages;
using Semoda.Windows.Views.Windows;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Semoda.Windows
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Provides access to the service provider.
        /// </summary>
        public static IServiceProvider Services { get; private set; } = default!;

        private Window? _window;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();

            Services = ConfigureServices();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            _window = Services.GetRequiredService<MainWindow>();
            _window.Activate();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //ViewModels
            services.AddSingleton<MainWindowViewModel>();

            //Views
            services.AddSingleton<MainWindow>();
            services.AddTransient<DashboardPage>();

            return services.BuildServiceProvider();
        }
    }
}