using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    public partial class ColorBox : UserControl
    {
        Point[] ULpoints = new Point[3];
        Point[] URpoints = new Point[3];
        Point[] LRpoints = new Point[3];
        Point[] LLpoints = new Point[3];

        Color _color = Color.White;
        bool _selected = false;
        Pen _outline = new Pen(Color.CadetBlue);
        Pen _selection = new Pen(Color.Orange, 2);
        SolidBrush _fill_brush = new SolidBrush(Color.White);
        TextureBrush _bg_brush = new TextureBrush(Properties.Resources.editbg2);

        public event EventHandler ColorChanged;
        public event EventHandler ColorChanging;

        public ColorBox()
        {
            InitializeComponent();
            UpdatePoints();
        }

        public Color SelectedColor
        {
            get { return _color; }
            set { _color = value; _fill_brush.Color = value; Invalidate(); }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; Invalidate(); }
        }

        private void ColorBox_Paint(object sender, PaintEventArgs e)
        {
            int RW = Width - 10;
            int BH = Height - 10;
            if (_selected) e.Graphics.DrawRectangle(_selection, 3, 3, RW + 3, BH + 3);
            e.Graphics.DrawCurve(_outline, ULpoints);
            e.Graphics.DrawCurve(_outline, URpoints);
            e.Graphics.DrawCurve(_outline, LRpoints);
            e.Graphics.DrawCurve(_outline, LLpoints);
            e.Graphics.DrawLine(_outline, 8, 1, RW, 1);
            e.Graphics.DrawLine(_outline, 1, 8, 1, BH);
            e.Graphics.DrawLine(_outline, 8, Height - 3, RW, Height - 3);
            e.Graphics.DrawLine(_outline, Width - 3, 8, Width - 3, BH);
            e.Graphics.FillRectangle(_bg_brush, 4, 4, RW, BH);
            e.Graphics.DrawRectangle(_outline, 4, 4, RW, BH);
            e.Graphics.FillRectangle(_fill_brush, 5, 5, RW - 1, BH - 1);
        }

        private void UpdatePoints()
        {
            ULpoints[0] = new Point(1, 8);
            ULpoints[1] = new Point(2, 2);
            ULpoints[2] = new Point(8, 1);
            URpoints[0] = new Point(Width - 10, 1);
            URpoints[1] = new Point(Width - 4, 2);
            URpoints[2] = new Point(Width - 3, 8);
            LRpoints[0] = new Point(Width - 3, Height - 10);
            LRpoints[1] = new Point(Width - 4, Height - 4);
            LRpoints[2] = new Point(Width - 10, Height - 3);
            LLpoints[0] = new Point(1, Height - 10);
            LLpoints[1] = new Point(2, Height - 4);
            LLpoints[2] = new Point(8, Height - 3);
        }

        private void ColorBox_Resize(object sender, EventArgs e)
        {
            UpdatePoints();
        }

        private void ColorBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (ColorDialog diag = new ColorDialog())
            {
                diag.FullOpen = true;
                diag.Color = SelectedColor;
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    if (ColorChanging != null) ColorChanging(this, EventArgs.Empty);
                    SelectedColor = diag.Color;
                    Invalidate();
                    if (ColorChanged != null) ColorChanged(this, EventArgs.Empty);
                }
            }
        }
    }
}
