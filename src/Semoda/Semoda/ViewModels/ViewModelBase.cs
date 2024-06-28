using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Semoda.Utils;
using System;

namespace Semoda.ViewModels
{
    /// <summary>
    /// Base of all view models. <br/>
    /// </summary>
    public class ViewModelBase : ObservableObject
    {
        /// <summary>
        /// Default constructor. Gets the <see cref="IServiceProvider"/> from the <see cref="AppServiceProvider"/>
        /// </summary>
        /// <param name="isPage">Indicates if the viewmodel belongs to a page.</param>
        public ViewModelBase(bool isPage)
        {
            IsPage = isPage;
            ServiceProvider = AppServiceProvider.Instance.ServiceProvider;
        }

        /// <summary>
        /// ServiceProvider to get all required services.
        /// </summary>
        public IServiceProvider ServiceProvider { get; init; }

        /// <summary>
        /// Flag to indicate if the view is a page. <br/>
        /// This is needed to adjust the namespace in the <see cref="ViewLocator"/>
        /// </summary>
        public bool IsPage { get; init; }
    }
}