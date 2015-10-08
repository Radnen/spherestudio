using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Specifies the docking position of a panel.
    /// </summary>
    public enum DockHint
    {
        Float,
        Left,
        Right,
        Top,
        Bottom,
    }

    /// <summary>
    /// Specifies the interface for an IDE dock panel.
    /// </summary>
    public interface IDockPane : IPlugin
    {
        /// <summary>
        /// Gets the physical Control providing functionality for the panel.
        /// </summary>
        Control Control { get; }

        /// <summary>
        /// Gets the panel's preferred docking position.
        /// </summary>
        DockHint DockHint { get; }

        /// <summary>
        /// Gets the icon bitmap associated with the panel.
        /// </summary>
        Bitmap DockIcon { get; }

        /// <summary>
        /// Gets whether the panel should be shown in the View menu.
        /// </summary>
        bool ShowInViewMenu { get; }
    }
}
