using CommunityToolkit.Mvvm.ComponentModel;

namespace Semoda.ViewModels
{
    /// <summary>
    /// Base of all view models. <br/>
    /// </summary>
    public class ViewModelBase : ObservableObject
    {

        /// <summary>
        /// Flag to indicate if the view is a page. <br/>
        /// This is needed to adjust the namespace in the <see cref="ViewLocator"/>
        /// </summary>
        public bool IsPage { get; init; }
    }
}
