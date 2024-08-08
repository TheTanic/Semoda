using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Semoda.Models
{
    /// <summary>
    /// Model for the settings in the application.
    /// All settings have default values - if no settings file is loaded, these are applied.
    /// A settings file is first created when the settings are saved from the settings view.
    /// Next time the app launches, those new settings will be loaded at startup.
    /// </summary>
    public class AppSettingsModel : INotifyPropertyChanged
    {
        private string language = "en";

        /// <summary>
        /// The current Language selected in the app.
        /// </summary>
        public string Language
        {
            get => language;
            set
            {
                if(language != value)
                {
                    language = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Add event handlers here to be notified of changed settingss
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Called when a property is changed, triggers event handlers
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Save current settings to appsettings.json.
        /// </summary>
        public void Save()
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("appsettings.json", json);
        }
    }
}
