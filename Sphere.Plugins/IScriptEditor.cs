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
    public interface IScriptEditor
    {
        /// <summary>
        /// Gets or sets the contents of the script editor.
        /// </summary>
        string Text { get; set; }
    }
}
