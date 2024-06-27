using Semoda.Views.Pages;

namespace Semoda.ViewModels
{
    /// <summary>
    /// View model for the <see cref="SettingsPage"/>
    /// </summary>
    public class SettingsPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Default constructor. <br/>
        /// Sets the <see cref="ViewModelBase.IsPage"/> to <see langword="true"/>
        /// </summary>
        public SettingsPageViewModel()
        {
            IsPage = true;
        }
    }
}