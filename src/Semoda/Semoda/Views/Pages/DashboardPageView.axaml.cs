using Avalonia.Controls;
using System;

namespace Semoda.Views.Pages;

/// <summary>
/// Page to show a single dashboard.
/// </summary>
public partial class DashboardPageView : UserControl
{
    private static readonly double MIN_SIZE_GRID = 200d;

    /// <summary>
    /// Default constructor
    /// </summary>
    public DashboardPageView()
    {
        InitializeComponent();
    }

    /// <inheritdoc/>
    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        base.OnSizeChanged(e);
        double size = Math.Max(Math.Min(e.NewSize.Width, e.NewSize.Height), MIN_SIZE_GRID);
        DashboardGrid.Width = size;
        DashboardGrid.Height = size;
    }
}