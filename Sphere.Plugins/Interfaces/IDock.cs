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
    /// Specifies the preferred location of a dock pane.
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
    /// Provides an interface for the IDE docking container.
    /// </summary>
    public interface IDock
    {
        /// <summary>
        /// Adds a new pane to the dock.
        /// </summary>
        /// <param name="control">The WinForms control implementing the pane.</param>
        /// <param name="title">The tab title.</param>
        /// <param name="icon">The icon to display on the tab.</param>
        /// <returns>An IDockPane allowing access to the new pane.</returns>
        IDockPane AddPane(Control control, string title, Icon icon, DockHint hint);

        /// <summary>
        /// Removes a dock pane created with AddPane.
        /// </summary>
        /// <param name="pane">The dock pane to remove.</param>
        void RemovePane(IDockPane pane);
    }

    /// <summary>
    /// Provides an interface for a dock pane.
    /// </summary>
    public interface IDockPane
    {
        /// <summary>
        /// Shows the pane.
        /// </summary>
        void Show();

        /// <summary>
        /// Hides the pane.
        /// </summary>
        void Hide();

        /// <summary>
        /// Hides the pane if it is visible, or shows it otherwise.
        /// </summary>
        void Toggle();
    }
}
