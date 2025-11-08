using Microsoft.UI.Xaml.Controls;
using Semoda.Windows.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Semoda.Windows.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();

            DashboardGrid.Children.Add(new Controls.DashboardElementContainer(new DashboardElementContainerViewModel(new Models.DashboardElementContainerModel
            {
                Title = "Element 1",
                Column = 0,
                ColumnSpan = 1,
                Row = 0,
                RowSpan = 1
            })));
        }
    }
}