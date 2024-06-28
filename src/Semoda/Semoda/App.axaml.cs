using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Semoda.Utils;
using Semoda.ViewModels;
using Semoda.Views;
using System.Globalization;

namespace Semoda
{
    /// <summary>
    /// AvaloniaUI Application. Entry point for the UI.
    /// </summary>
    public partial class App : Application
    {
        /// <inheritdoc/>
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <inheritdoc/>
        public override void OnFrameworkInitializationCompleted()
        {
            Assets.Languages.Resources.Culture = new CultureInfo("");
            AppServiceProvider appServiceProvider = AppServiceProvider.InitInstance();
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = new MainWindow
                {
                    DataContext = appServiceProvider.ServiceProvider.GetRequiredService<MainWindowViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}