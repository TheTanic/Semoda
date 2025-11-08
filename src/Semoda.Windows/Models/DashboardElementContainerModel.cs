namespace Semoda.Windows.Models
{
    public class DashboardElementContainerModel
    {
        public int Column { get; set; }
        public int ColumnSpan { get; set; } = 1;
        public int Row { get; set; }
        public int RowSpan { get; set; } = 1;
        public string Title { get; set; } = string.Empty;
    }
}