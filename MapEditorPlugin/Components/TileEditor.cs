using System;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Core.Utility;

namespace MapEditorPlugin.Components
{
    public partial class TileEditor : UserControl
    {
        private int _zoom = 4;
        private Tile _tile = null;
        private Bitmap _obstruction_layer = null;
        private TilesetControl2 _tileset = null;
        private bool _paint = false;
        private byte _tool = 0;
        private Point _start_loc = new Point(), _end_loc = new Point();

        public event EventHandler Modified;

        public TileEditor()
        {
            InitializeComponent();
        }

        public TilesetControl2 Tileset
        {
            set
            {
                _tileset = value;
                EditorLabel.Text = "Editing Tile #(" + value.Selected + ")";
            }
        }

        public Tile Tile
        {
            get { return this._tile; }
            set
            {
                if (_tile != null)
                {
                    _tile.Name = NameTextBox.Text;
                    _tile.Animated = AnimateCheckBox.Checked;
                    _tile.Delay = short.Parse(DelayTextBox.Text);
                    _tile.NextAnim = short.Parse(NextTileTextBox.Text);
                    if (Modified != null) Modified(this, new EventArgs());
                }

                _tile = value;
                if (value == null) return;
                if (_tileset != null) EditorLabel.Text = "Editing Tile #(" + _tileset.Selected + ")";

                TileImage.Width = value.Width * _zoom;
                TileImage.Height = value.Height * _zoom;
                NameTextBox.Text = value.Name;
                DelayTextBox.Text = value.Delay.ToString();
                NextTileTextBox.Text = value.NextAnim.ToString();
                AnimateCheckBox.Checked = value.Animated;
                _obstruction_layer = new Bitmap(value.Width, value.Height);
                TileImage.Refresh();
            }
        }

        public int Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                if (_tile == null) return;
                TileImage.Width = _tile.Width * value;
                TileImage.Height = _tile.Height * value;
                TileImage.Refresh();
            }
        }

        private void AnimateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NextTileTextBox.Enabled = DelayTextBox.Enabled = AnimateCheckBox.Checked;
        }

        private void UpdateTileImage()
        {
            int x = (ImageHolder.Width >> 1) - (TileImage.Width >> 1);
            int y = (ImageHolder.Height >> 1) - (TileImage.Height >> 1);
            TileImage.Location = new Point(x, y);
        }

        private void ImageHolder_Resize(object sender, EventArgs e)
        {
            UpdateTileImage();
        }

        private void TileImage_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            if (_tile == null)
            {
                e.Graphics.DrawLine(Pens.Red, 0, 0, TileImage.Width, TileImage.Height);
                e.Graphics.DrawLine(Pens.Red, 0, TileImage.Height, TileImage.Width, 0);
                return;
            }

            e.Graphics.DrawImage(_tile.Graphic, TileImage.ClientRectangle);

            // draw obstruction lines:
            Graphics g = Graphics.FromImage(_obstruction_layer);
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            g.FillRectangle(Brushes.Transparent, 0, 0, _obstruction_layer.Width, _obstruction_layer.Height);
            foreach (Line l in _tile.Obstructions) l.DrawLine(g, Pens.Magenta);

            if (_paint)
            {
                if (_tool == 0) g.DrawLine(Pens.Magenta, _start_loc, _end_loc);
                else if (_tool == 1)
                {
                    Line l = new Line(_start_loc, _end_loc);
                    Rectangle rect = Line.ToRectangle(l);
                    if (rect.Width == 0 || rect.Height == 0) l.DrawLine(g, Pens.Magenta);
                    else g.DrawRectangle(Pens.Magenta, rect);
                }
            }

            e.Graphics.DrawImage(_obstruction_layer, TileImage.ClientRectangle);
            g.Dispose();
        }

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            ZoomOutButton.Enabled = true;
            if (Zoom < 16) Zoom *= 2;
            if (Zoom == 16) ZoomInButton.Enabled = false;
            ZoomLabel.Text = "Zoom: " + _zoom + "x";
            UpdateTileImage();
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            ZoomInButton.Enabled = true;
            if (Zoom > 1) Zoom /= 2;
            if (Zoom == 1) ZoomOutButton.Enabled = false;
            ZoomLabel.Text = "Zoom: " + _zoom + "x";
            UpdateTileImage();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (_tileset.Selected[0] < _tileset.Tileset.Tiles.Count - 1) _tileset.Select(_tileset.Selected[0]);
            else if (_tileset.Selected[0] == _tileset.Tileset.Tiles.Count - 1) _tileset.Select(0);
            EditorLabel.Text = string.Format("Editing Tile #({0})", _tileset.Selected[0]);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (_tileset.Selected[0] > 0) _tileset.Select(_tileset.Selected[0]--);
            else if (_tileset.Selected[0] == 0) _tileset.Select((short)(_tileset.Tileset.Tiles.Count - 1));
            EditorLabel.Text = string.Format("Editing Tile #({0})", _tileset.Selected);
        }

        private void TileImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _paint = true;
                _start_loc = new Point(e.X / _zoom, e.Y / _zoom);
            }
            else ImageContextStrip.Show((Control)sender, e.Location);
        }

        private int last_x = 0, last_y = 0;
        private int cur_x = 0, cur_y = 0;
        private void TileImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (_paint)
            {
                last_x = cur_x;
                last_y = cur_y;
                cur_x = e.X / _zoom;
                cur_y = e.Y / _zoom;
                if (cur_x != last_x || cur_y != last_y)
                {
                    _end_loc.X = e.X / _zoom;
                    _end_loc.Y = e.Y / _zoom;
                    TileImage.Refresh();
                }
            }
        }

        private void TileImage_MouseUp(object sender, MouseEventArgs e)
        {
            _paint = false;
            if (_tool == 0) _tile.Obstructions.Add(new Line(_start_loc, _end_loc));
            else if (_tool == 1)
            {
                Rectangle rect = Line.ToRectangle(new Line(_start_loc, _end_loc));
                short x1 = (short)rect.X, y1 = (short)rect.Y;
                short x2 = (short)(rect.X + rect.Width);
                short y2 = (short)(rect.Y + rect.Height);
                if (rect.Width == 0)
                {
                    _tile.Obstructions.Add(new Line(x1, y1, x1, y2)); // horizontal
                }
                else if (rect.Height == 0)
                {
                    _tile.Obstructions.Add(new Line(x1, y1, x2, y1)); // vertical
                }
                else
                {
                    _tile.Obstructions.Add(new Line(x1, y1, x1, y2)); // top
                    _tile.Obstructions.Add(new Line(x1, y1, x2, y1)); // left
                    _tile.Obstructions.Add(new Line(x1, y2, x2, y2)); // bottom
                    _tile.Obstructions.Add(new Line(x2, y1, x2, y2)); // right
                }
            }
            else if (_tool == 2)
            {
                if (_tile.Obstructions.Count == 0) return;
                int index = 0;
                int cur = 0;
                int dist = _tile.Width;
                int c_x = e.X / _zoom;
                int c_y = e.Y / _zoom;
                foreach (Line l in _tile.Obstructions)
                {
                    int m_x = l.X1 + (l.X2 - l.X1) / 2;
                    int m_y = l.Y1 + (l.Y2 - l.Y1) / 2;
                    int d_x = m_x - c_x;
                    int d_y = m_y - c_y;
                    int l_dist = (int)Math.Sqrt(d_x * d_x + d_y * d_y);
                    if (l_dist < dist)
                    {
                        dist = l_dist;
                        cur = index;
                    }
                    index++;
                }
                _tile.Obstructions.RemoveAt(cur);
            }
            if (Modified != null) Modified(this, new EventArgs());
            TileImage.Refresh();
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            LineButton.Checked = ClearObstButton.Checked = false;
            _tool = 1;
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            RectangleButton.Checked = ClearObstButton.Checked = false;
            _tool = 0;
        }

        private void ClearObstButton_Click(object sender, EventArgs e)
        {
            RectangleButton.Checked = LineButton.Checked = false;
            _tool = 2;
        }

        private void ClearItem_Click(object sender, EventArgs e)
        {
            _tile.Obstructions.Clear();
            TileImage.Refresh();
        }

        private void FullItem_Click(object sender, EventArgs e)
        {
            Point ul = Point.Empty;
            Point ur = new Point(_tile.Width - 1, 0);
            Point lr = new Point(_tile.Width - 1, _tile.Height - 1);
            Point ll = new Point(0, _tile.Height - 1);
            _tile.Obstructions.Clear();
            _tile.Obstructions.Add(new Line(ul, ur));
            _tile.Obstructions.Add(new Line(ur, lr));
            _tile.Obstructions.Add(new Line(ll, lr));
            _tile.Obstructions.Add(new Line(ul, ll));
            TileImage.Refresh();
        }
    }
}
