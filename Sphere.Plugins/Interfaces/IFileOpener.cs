using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Plugins.Views;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Specifies the interface for a file opener.
    /// </summary>
    public interface IFileOpener : IPlugin
    {
        /// <summary>
        /// Creates a new, untitled file using this opener.
        /// </summary>
        /// <returns>The DocumentView for the new file, or null to cancel document creation.</returns>
        DocumentView New();

        /// <summary>
        /// Opens an existing file.
        /// </summary>
        /// <param name="fileName">The filename of the asset to edit.</param>
        /// <returns>The DocumentView used for editing the file, or null if no document view is needed.</returns>
        DocumentView Open(string fileName);
    }
}
