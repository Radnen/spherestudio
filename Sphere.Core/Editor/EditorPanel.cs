using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    public class EditorPanel : Panel
    {
        private int _y_snap = 0;
        private int _x_snap = 0;

        public EditorPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override Point ScrollToControl(Control activeControl)
        {
            return DisplayRectangle.Location;
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            if (_x_snap == 0 && _y_snap == 0) base.OnScroll(se);
            else
            {
                if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    HorizontalScroll.Value = se.NewValue / _x_snap * _x_snap;
                else
                    VerticalScroll.Value = se.NewValue / _y_snap * _y_snap;
            }
        }

        public int XSnap
        {
            get { return _x_snap; }
            set { _x_snap = value; }
        }

        public int YSnap
        {
            get { return _y_snap; }
            set { _y_snap = value; }
        }
    }
}
