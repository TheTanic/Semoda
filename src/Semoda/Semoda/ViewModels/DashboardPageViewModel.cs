﻿using Semoda.Views.Pages;

namespace Semoda.ViewModels
{
    /// <summary>
    /// View model for the <see cref="DashboardPage"/>.
    /// </summary>
    public class DashboardPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Default constructor. <br/>
        /// Sets the <see cref="ViewModelBase.IsPage"/> to <see langword="true"/>
        /// </summary>
        public DashboardPageViewModel() : base(true)
        {
        }
    }
}