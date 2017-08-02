using System.Drawing;
using System.Windows.Forms;

namespace SphereStudio.UI
{
    /// <summary>
    /// A fast drawing panel for editing with support for snap-to-grid.
    /// </summary>
    public class SnapPanel : Panel
    {
        /// <summary>
        /// Constructs a SnapPanel.
        /// </summary>
        public SnapPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        /// <summary>
        /// Gets or sets the grid snap size on the X axis.
        /// </summary>
        public int XSnap { get; set; }

        /// <summary>
        /// Gets or sets the grid snap size of the Y axis.
        /// </summary>
        public int YSnap { get; set; }
   
        /// <summary>
        /// Overrides ScrollToControl to prevent the panel from auto-scrolling.
        /// </summary>
        /// <param name="activeControl">Some control or other, we just ignore it.</param>
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
            if (XSnap == 0 && YSnap == 0) {
                base.OnScroll(se);
            }
            else {
                if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    HorizontalScroll.Value = se.NewValue / XSnap * XSnap;
                else
                    VerticalScroll.Value = se.NewValue / YSnap * YSnap;
            }
        }
    }
}
