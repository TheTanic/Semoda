using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Semoda.Views
{

    /// <summary>
    /// Main window of the application
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <inheritdoc/>
        protected override void OnLoaded(RoutedEventArgs e)
        {
            base.OnLoaded(e);
            MinWidth = 600;
            MinHeight = 600;
        }
    }
}