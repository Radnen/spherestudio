using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Plugins.Views;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Specifies the interface for an embedded editor.
    /// </summary>
    public interface IEditor<T> : IPlugin
        where T : DocumentView
    {
        /// <summary>
        /// Creates a new embeddable DocumentView for this editor.
        /// </summary>
        /// <returns></returns>
        T CreateEditView();
    }
}
