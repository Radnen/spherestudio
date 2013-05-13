using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// A fast drawing panel for editing, without worrying about odd scroll-to behavior.
    /// </summary>
    public sealed class EditorPanel : Panel
    {
        /// <summary>
        /// Initializes a new instance of the EditorPanel.
        /// </summary>
        public EditorPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        /// <summary>
        /// For fixing the horrendous scroll-to behavior.
        /// </summary>
        /// <param name="activeControl">Doesn't matter.</param>
        /// <returns>The display location of where you wanted to be.</returns>
        protected override Point ScrollToControl(Control activeControl)
        {
            return DisplayRectangle.Location;
        }

        /// <summary>
        /// Overrides the default scroll behavior to add grid snapping.
        /// </summary>
        /// <param name="se">The scrolling properties.</param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            if (XSnap == 0 && YSnap == 0) base.OnScroll(se);
            else
            {
                if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    HorizontalScroll.Value = se.NewValue / XSnap * XSnap;
                else
                    VerticalScroll.Value = se.NewValue / YSnap * YSnap;
            }
        }

        /// <summary>
        /// Gets or sets the grid snap size of the x axis.
        /// </summary>
        public int XSnap { get; set; }

        /// <summary>
        /// Gets or sets the grid snap size of the y axis.
        /// </summary>
        public int YSnap { get; set; }
    }
}
