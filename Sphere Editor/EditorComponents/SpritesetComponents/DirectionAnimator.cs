using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sphere_Editor.SphereObjects;

namespace Sphere_Editor.SpritesetComponents
{
    public partial class DirectionAnimator : UserControl
    {
        private Spriteset _sprite = null;
        private Direction _dir = null;

        public DirectionAnimator()
        {
            InitializeComponent();
        }

        public Spriteset Sprite
        {
            get { return _sprite; }
            set
            {
                if (value == null) return;
                _sprite = value;
                UpdateAnimPanel();
            }
        }

        public Direction Direction
        {
            get { return this._dir; }
            set
            {
                if (value == null) return;
                _dir = value;
                FrameTracker.Minimum = 0;
                FrameTracker.Maximum = value.frames.Count - 1;
                FrameTracker.Value = value.frames.Count - 1;
                AnimTimer.Interval = value.frames[0].Delay * 10;
                UpdateLabels();
                PlayButton.Enabled = true;
            }
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            FrameTracker.Maximum = _dir.frames.Count - 1;
            if (FrameTracker.Maximum <= 0) StopButton_Click(null, EventArgs.Empty);
            else
            {
                if (FrameTracker.Value - 1 == -1) FrameTracker.Value = FrameTracker.Maximum;
                else FrameTracker.Value--;
                AnimPanel.Refresh();
                AnimTimer.Interval = _dir.frames[FrameTracker.Maximum - FrameTracker.Value].Delay * 10;
                UpdateLabels();
            }
        }

        private void UpdateLabels()
        {
            int pos = (FrameTracker.Maximum - FrameTracker.Value + 1);
            int max = (FrameTracker.Maximum + 1);
            AnimLabel.Text = "Frame: " + pos + "/" + max;
            DirLabel.Text = "Direction: " + _dir.Name;
        }

        private void UpdateAnimPanel()
        {
            if (_sprite == null) return;
            if (_sprite.Images.Count == 0) return;
            AnimPanel.Width = _sprite.Images[0].Width << 1;
            AnimPanel.Height = _sprite.Images[0].Height << 1;
            int x = (AnimPanel.Parent.Width >> 1) - (AnimPanel.Width >> 1);
            int y = (AnimPanel.Parent.Height >> 1) - (AnimPanel.Height >> 1);
            AnimPanel.Location = new Point(x, y);
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (_dir.frames.Count > 1)
            {
                AnimTimer.Start();
                PlayButton.Enabled = false;
                StopButton.Enabled = true;
                FrameTracker.Enabled = false;
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            AnimTimer.Stop();
            StopButton.Enabled = false;
            PlayButton.Enabled = true;
            UpdateLabels();
            FrameTracker.Enabled = true;
            AnimPanel.Invalidate();
        }

        private void AnimPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_sprite == null || _dir.frames.Count == 0)
            {
                Point ur = new Point(AnimPanel.Width, 0);
                Point lr = new Point(AnimPanel.Width, AnimPanel.Height);
                Point ll = new Point(0, AnimPanel.Height);
                e.Graphics.DrawLine(Pens.Red, Point.Empty, lr);
                e.Graphics.DrawLine(Pens.Red, ur, ll);
            }
            else
            {
                if (_dir == null) return;
                Image img = _sprite.GetImage(_dir.Name, FrameTracker.Maximum - FrameTracker.Value);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(img, 0, 0, AnimPanel.Width, AnimPanel.Height);
            }
        }

        private void DirectionAnimator_Resize(object sender, EventArgs e)
        {
            UpdateAnimPanel();
        }

        private void FrameTracker_Scroll(object sender, EventArgs e)
        {
            AnimPanel.Refresh();
        }
    }
}
