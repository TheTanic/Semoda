using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Semoda.ViewModels;
using System;

namespace Semoda
{
    /// <summary>
    /// Locator to create a view by its viewmodel. <br/>
    /// <b>Autogenerated</b>
    /// </summary>
    public class ViewLocator : IDataTemplate
    {
        /// <inheritdoc/>
        public Control? Build(object? data)
        {
            if (data is null)
                return null;

            string className = "";
            if (data is ViewModelBase && ((ViewModelBase)data).IsPage)
                className = data.GetType().FullName!.Replace("ViewModels.", "Views.Pages.", StringComparison.Ordinal);
            else
                className = data.GetType().FullName!;
            className = className.Replace("ViewModel", "", StringComparison.Ordinal);
            var type = Type.GetType(className);

            if (type != null)
            {
                var control = (Control)Activator.CreateInstance(type)!;
                control.DataContext = data;
                return control;
            }

            return new TextBlock { Text = "Not Found: " + className };
        }

        /// <inheritdoc/>
        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}