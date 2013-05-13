using System;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Core;

namespace Sphere_Editor.SpritesetComponents
{
    public partial class BaseEditor : UserControl
    {
        private int _zoom = 0;
        private Spriteset _sprite = null;
        private Frame _frame = null;
        private bool _draw = false;

        public event EventHandler Modified;

        public BaseEditor()
        {
            InitializeComponent();
        }

        public Frame Frame
        {
            set
            {
                this._frame = value;
                XYLabel.Text = "X, Y = (" + _sprite.SpriteBase.X1 + ", " + _sprite.SpriteBase.Y1 + ")";
                WHLabel.Text = "W, H = (" + _sprite.SpriteBase.Width + ", " + _sprite.SpriteBase.Height + ")";
                UpdateCenterFrame();
            }
        }

        public Spriteset Sprite
        {
            set
            {
                _sprite = value;
                UpdateCenterFrame();
            }
        }

        public void UpdateCenterFrame()
        {
            if (_sprite != null)
            {
                _zoom = BasePanel.Width / _sprite.SpriteWidth;
                _zoom = Math.Min(BasePanel.Height / _sprite.SpriteHeight, _zoom);
                FrameImage.Width = _sprite.SpriteWidth * _zoom;
                FrameImage.Height = _sprite.SpriteHeight * _zoom;
            }
            int x = (BasePanel.Width >> 1) - (FrameImage.Width >> 1);
            int y = (BasePanel.Height >> 1) - (FrameImage.Height >> 1);
            FrameImage.Location = new Point(x, y);
            FrameImage.Refresh();
        }

        private void BaseEditor_Resize(object sender, EventArgs e)
        {
            UpdateCenterFrame();
        }

        private void FrameImage_Paint(object sender, PaintEventArgs e)
        {
            if (_sprite == null || _frame == null) return;

           Image bmap = _sprite.GetImage(_frame.Index);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.DrawImage(bmap, FrameImage.ClientRectangle);

            using (Bitmap bg = new Bitmap(bmap.Width, bmap.Height))
            {
                using (Graphics g = Graphics.FromImage(bg))
                {
                    g.DrawRectangle(Pens.Magenta, _sprite.SpriteBase.Rectangle);
                    e.Graphics.DrawImage(bg, FrameImage.ClientRectangle);
                }
            }
        }

        private void FrameImage_MouseDown(object sender, MouseEventArgs e)
        {
            _sprite.SpriteBase.X1 = (short)(e.X / _zoom);
            _sprite.SpriteBase.Y1 = (short)(e.Y / _zoom);
            XYLabel.Text = "X, Y = (" + (_sprite.SpriteBase.X1 + 1) + ", " + (_sprite.SpriteBase.Y1 + 1) + ")";
            _draw = true;
        }

        private void FrameImage_MouseUp(object sender, MouseEventArgs e)
        {
            _draw = false;
            _sprite.SpriteBase.X2 = Math.Max((short)(_sprite.SpriteBase.X1 + 1), _sprite.SpriteBase.X2);
            _sprite.SpriteBase.Y2 = Math.Max((short)(_sprite.SpriteBase.Y1 + 1), _sprite.SpriteBase.Y2);
            if (Modified != null) Modified(this, new EventArgs());
            FrameImage.Refresh();
        }

        private void FrameImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (_draw)
            {
                _sprite.SpriteBase.X2 = (short)(e.X / _zoom);
                _sprite.SpriteBase.Y2 = (short)(e.Y / _zoom);
                WHLabel.Text = "W, H = (" + (_sprite.SpriteBase.Width + 1) + ", " + (_sprite.SpriteBase.Height + 1) + ")";
                FrameImage.Refresh();
            }
        }
    }
}
