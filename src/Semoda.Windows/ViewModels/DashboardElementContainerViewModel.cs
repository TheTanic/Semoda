using CommunityToolkit.Mvvm.ComponentModel;
using Semoda.Windows.Models;

namespace Semoda.Windows.ViewModels
{
    public partial class DashboardElementContainerViewModel : ObservableObject
    {
        [ObservableProperty]
        private DashboardElementContainerModel _model;

        public DashboardElementContainerViewModel(DashboardElementContainerModel model)
        {
            Model = model;
        }
    }
}