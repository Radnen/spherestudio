using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins
{
    /// <summary>
    /// Specifies the interface for a script editing component.
    /// </summary>
    public interface IScriptView : IDocumentView
    {
        /// <summary>
        /// Gets or sets the contents of the script view.
        /// </summary>
        string Text { get; set; }
    }
}
