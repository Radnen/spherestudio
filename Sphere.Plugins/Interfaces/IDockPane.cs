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
    /// Specifies the position of a dock pane.
    /// </summary>
    public enum DockHint
    {
        /// <summary>
        /// Detaches the pane, making it floating.
        /// </summary>
        Float,

        /// <summary>
        /// Docks the pane to the left side.
        /// </summary>
        Left,
        
        /// <summary>
        /// Docks the pane to the right side.
        /// </summary>
        Right,

        /// <summary>
        /// Docks the pane to the top.
        /// </summary>
        Top,

        /// <summary>
        /// Docks the pane to the bottom.
        /// </summary>
        Bottom,
    }

    /// <summary>
    /// Specifies the interface for an IDE dock pane.
    /// </summary>
    public interface IDockPane : IPlugin
    {
        /// <summary>
        /// Gets the physical Control providing functionality for this dock pane.
        /// </summary>
        Control Control { get; }

        /// <summary>
        /// Gets the dock pane's preferred docking position.
        /// </summary>
        DockHint DockHint { get; }

        /// <summary>
        /// Gets the icon associated with this dock pane.
        /// </summary>
        Bitmap DockIcon { get; }

        /// <summary>
        /// Gets whether this dock pane should be shown in the View menu.
        /// </summary>
        bool ShowInViewMenu { get; }
    }
}
