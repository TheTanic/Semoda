using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Semoda.Models;
using Semoda.Services.Interfaces;
using Semoda.Views.Pages;

namespace Semoda.ViewModels
{
    /// <summary>
    /// View model for the <see cref="SettingsPage"/>
    /// </summary>
    public partial class SettingsPageViewModel : ViewModelBase
    {
        [ObservableProperty]
        private AppSettingsModel _appSettingsModel;

        private IConfigService _configService;

        /// <summary>
        /// Default constructor. <br/>
        /// Sets the <see cref="ViewModelBase.IsPage"/> to <see langword="true"/>
        /// </summary>
        public SettingsPageViewModel() : base(true)
        {
            _configService = ServiceProvider.GetRequiredService<IConfigService>();
            _configService.Register(HandleSettingsChanged);

            AppSettingsModel = _configService.GetAppSettings();
            
            AppSettingsModel.Language = "de";
            _configService.Update(AppSettingsModel);
        }

        private void HandleSettingsChanged(object? sender, EventArgs e)
        {
            AppSettingsModel = _configService.GetAppSettings();
        }
    }
}