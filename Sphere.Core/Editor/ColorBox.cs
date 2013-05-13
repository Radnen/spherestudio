using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// A visual color box component.
    /// </summary>
    public partial class ColorBox : UserControl
    {
        readonly Point[] _uLpoints = new Point[3];
        readonly Point[] _uRpoints = new Point[3];
        readonly Point[] _lRpoints = new Point[3];
        readonly Point[] _lLpoints = new Point[3];

        Color _color = Color.White;
        bool _selected;
        readonly Pen _outline = new Pen(Color.CadetBlue);
        readonly Pen _selection = new Pen(Color.Orange, 2);
        readonly SolidBrush _fillBrush = new SolidBrush(Color.White);
        readonly TextureBrush _bgBrush = new TextureBrush(Properties.Resources.editbg2);

        /// <summary>
        /// Event handler; triggered after the color has been changed.
        /// </summary>
        public event EventHandler ColorChanged;

        /// <summary>
        /// Event handler; triggered when a color is going to change.
        /// </summary>
        public event EventHandler ColorChanging;

        /// <summary>
        /// Initializes a new instance of a ColorBox
        /// </summary>
        public ColorBox()
        {
            InitializeComponent();
            UpdatePoints();
        }

        /// <summary>
        /// The color that is present in this color box.
        /// </summary>
        public Color SelectedColor
        {
            get { return _color; }
            set { _color = value; _fillBrush.Color = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets whether or not it's in a selected state.
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; Invalidate(); }
        }

        private void ColorBox_Paint(object sender, PaintEventArgs e)
        {
            int rw = Width - 10;
            int bh = Height - 10;
            if (_selected) e.Graphics.DrawRectangle(_selection, 3, 3, rw + 3, bh + 3);
            e.Graphics.DrawCurve(_outline, _uLpoints);
            e.Graphics.DrawCurve(_outline, _uRpoints);
            e.Graphics.DrawCurve(_outline, _lRpoints);
            e.Graphics.DrawCurve(_outline, _lLpoints);
            e.Graphics.DrawLine(_outline, 8, 1, rw, 1);
            e.Graphics.DrawLine(_outline, 1, 8, 1, bh);
            e.Graphics.DrawLine(_outline, 8, Height - 3, rw, Height - 3);
            e.Graphics.DrawLine(_outline, Width - 3, 8, Width - 3, bh);
            e.Graphics.FillRectangle(_bgBrush, 4, 4, rw, bh);
            e.Graphics.DrawRectangle(_outline, 4, 4, rw, bh);
            e.Graphics.FillRectangle(_fillBrush, 5, 5, rw - 1, bh - 1);
        }

        private void UpdatePoints()
        {
            _uLpoints[0] = new Point(1, 8);
            _uLpoints[1] = new Point(2, 2);
            _uLpoints[2] = new Point(8, 1);
            _uRpoints[0] = new Point(Width - 10, 1);
            _uRpoints[1] = new Point(Width - 4, 2);
            _uRpoints[2] = new Point(Width - 3, 8);
            _lRpoints[0] = new Point(Width - 3, Height - 10);
            _lRpoints[1] = new Point(Width - 4, Height - 4);
            _lRpoints[2] = new Point(Width - 10, Height - 3);
            _lLpoints[0] = new Point(1, Height - 10);
            _lLpoints[1] = new Point(2, Height - 4);
            _lLpoints[2] = new Point(8, Height - 3);
        }

        private void ColorBox_Resize(object sender, EventArgs e)
        {
            UpdatePoints();
        }

        private void ColorBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (var diag = new ColorDialog())
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
