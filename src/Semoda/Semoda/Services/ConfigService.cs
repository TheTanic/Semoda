using System;
using System.IO;
using System.Text.Json;
using Semoda.Models;
using Semoda.Services.Interfaces;

namespace Semoda.Services {
	/// <summary>
	/// Implementation of the configuration service that saves settings to
	/// and loads them from a json file.
	/// </summary>
    public class ConfigService : IConfigService
    {
		private event EventHandler<EventArgs>? SettingsChangedEvent = null;
		private AppSettingsModel _appSettings;

		/// <summary>
		/// Loads the settings json file from the file system, first creating
		/// it if it does not yet exist.
		/// </summary>
		public ConfigService()
		{
			if(!File.Exists("appsettings.json"))
			{
				File.WriteAllText("appsettings.json", JsonSerializer.Serialize(new AppSettingsModel(), new JsonSerializerOptions { WriteIndented = true }));
			}

			string fileContent = File.ReadAllText("appsettings.json");
			_appSettings = JsonSerializer.Deserialize<AppSettingsModel>(fileContent) ?? new AppSettingsModel();
		}

		/// <inheritdoc/>
        public AppSettingsModel GetAppSettings()
        {
			return _appSettings;
        }

		/// <summary>
		/// Updates the application settings with the supplied version.
		/// Saves the new settings to the file system and triggers an event
		/// informing listeners of the change.
		/// </summary>
		/// <param name="newSettings">the new settings to save</param>
		/// <returns>true if the settings were saved successfully, false otherwise</returns>
		public bool Update(AppSettingsModel newSettings)
		{
            var json = JsonSerializer.Serialize(newSettings, new JsonSerializerOptions { WriteIndented = true });
            try
			{
				File.WriteAllText("appsettings.json", json);
			}
			catch(Exception)
			{
				// TODO Log error
				return false;
			}

			_appSettings = newSettings;

			SettingsChangedEvent?.Invoke(this, new EventArgs());

			return true;
		}
	
		/// <inheritdoc/>
		public bool Register(EventHandler<EventArgs> eventHandler)
		{
			SettingsChangedEvent += eventHandler;
			return true;
		}
    }
}