using Microsoft.Extensions.DependencyInjection;
using Semoda.Extensions;
using System;

namespace Semoda.Utils
{
    /// <summary>
    /// Hold the <see cref="IServiceCollection"/> of the Application. <br/>
    /// This class is a singleton.
    /// </summary>
    public class AppServiceProvider
    {
        private static object _singletonLock = new();
        private static AppServiceProvider? _instance = null;

        /// <summary>
        /// Private constructor to fulfill the singleton pattern.
        /// </summary>
        private AppServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddAppServices();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// Singleton instance of the <see cref="AppServiceProvider"/>
        /// </summary>
        public static AppServiceProvider Instance
        {
            get
            {
                if (_instance == null)
                    throw new InvalidOperationException("The AppServiceProvider is not initialized yet.");
                return _instance;
            }
        }

        /// <summary>
        /// Service provider, which holds all viewmodels
        /// </summary>
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Initializes the <see cref="AppServiceProvider"/>.
        /// If there is already an instance, the already created instance will be returned.
        /// </summary>
        /// <returns></returns>
        public static AppServiceProvider InitInstance()
        {
            if (_instance != null)
                return _instance;
            lock (_singletonLock)
            {
                if (_instance == null)
                    _instance = new AppServiceProvider();
                return _instance;
            }
        }
    }
}