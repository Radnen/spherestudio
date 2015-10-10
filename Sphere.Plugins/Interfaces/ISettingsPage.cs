using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Specifies the interface for a Settings Center page.
    /// </summary>
    public interface ISettingsPage : IPlugin
    {
        /// <summary>
        /// Gets the physical UserControl for this settings page.
        /// </summary>
        Control Control { get; }

        /// <summary>
        /// Applies the settings selected on this settings page.
        /// </summary>
        /// <returns>true if the settings were applied successfully.</returns>
        bool Apply();
    }
}
