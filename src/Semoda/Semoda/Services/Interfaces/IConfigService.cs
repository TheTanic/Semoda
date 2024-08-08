using System;
using Semoda.Models;

namespace Semoda.Services.Interfaces {
	/// <summary>
	/// Interface for Service that manages application configuration data
	/// </summary>
	public interface IConfigService {
		/// <summary>
		/// Gives access to the application settings
		/// </summary>
		/// <returns>a copy of the application settings</returns>
		public AppSettingsModel GetAppSettings();

		/// <summary>
		/// Updates the application settings with the supplied version.
		/// Persists the new settings and triggers an event
		/// informing listeners of the change.
		/// </summary>
		/// <param name="newSettings">the new settings to save</param>
		/// <returns>true if the settings were saved successfully, false otherwise</returns>
		public bool Update(AppSettingsModel newSettings);

		/// <summary>
		/// Registers an event handler to be informed when any setting in the app is changed.
		/// </summary>
		/// <param name="eventHandler">the handler to register</param>
		/// <returns>true if the handler was registered successfully, false otherwise</returns>
		public bool Register(EventHandler<EventArgs> eventHandler);
	}
}