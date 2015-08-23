using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Plugins
{
    /// <summary>
    /// Represents a dockable control in a generic way.
    /// </summary>
    public class DockDescription
    {
        public event EventHandler OnActivate;
        public event EventHandler OnShow;
        public event EventHandler OnHide;
        public event EventHandler OnToggle;

        /// <summary>
        /// The root form control that takes the space of this plugin.
        /// </summary>
        public Control Control { get; set; }

        /// <summary>
        /// The icon to associate to this editor.
        /// </summary>
        public Icon Icon { get; set; }

        /// <summary>
        /// The text to associate to this editor.
        /// </summary>
        public String TabText { get; set; }

        /// <summary>
        /// The dock state of this editor, either a document or a sidebar widget.
        /// </summary>
        public DockDescStyle DockState { get; set; }

        /// <summary>
        /// Dictates where you are allowed to put the docked form.
        /// </summary>
        public DockDescAreas DockAreas { get; set; }

        /// <summary>
        /// Optionally choose to hide the control on close rather than destroy it.
        /// </summary>
        public Boolean HideOnClose { get; set; }

        public DockDescription()
        {
            DockState = DockDescStyle.Document;
            DockAreas = DockDescAreas.Document;
        }

        /// <summary>
        /// Shows the control without stealing focus.
        /// </summary>
        public void Activate()
        {
            if (OnActivate != null)
                OnActivate(this, EventArgs.Empty);
        }

        /// <summary>
        /// Shows and activates the control.
        /// </summary>
        public void Show()
        {
            if (OnShow != null)
                OnShow(this, EventArgs.Empty);
        }

        /// <summary>
        /// Hides the dockable control.
        /// </summary>
        public void Hide()
        {
            if (OnHide != null)
                OnHide(this, EventArgs.Empty);
        }

        public void Toggle()
        {
            if (OnToggle != null)
                OnToggle(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Specifies the preferred docking location for a dockable control.
    /// </summary>
    public enum DockDescStyle
    {
        Document,
        LeftSide,
        RightSide,
        Top,
        Bottom,
    }

    /// <summary>
    /// Specifies valid docking positions for a dockable control.
    /// </summary>
    [Flags]
    public enum DockDescAreas
    {
        None = 0,
        Document = 1,
        Sides = 2,
        Both = 3,
    }
}
