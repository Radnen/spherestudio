using System;
using System.Drawing;
using System.Windows.Forms;

using SphereStudio.UI;
using SphereStudio.Vanilla;

namespace SphereStudio.Plugins.Components
{
    internal partial class DirectionLayout : UserControl
    {
        private int _zoom = 1;
        private Spriteset _sprite;
        private Direction _direction;
        private bool _drag;
        private Point _drag_start;
        private SpritesetEditView _parent_editor;
        private bool _showDelay;

        public event EventHandler OnFrameClick;
        public event EventHandler Modified;

        private FramePanel _hovered_frame = null;
        private FramePanel _panel_to_add = null;
        public FramePanel SelectedFrame { get; set; }

        public DirectionLayout(Spriteset sprite, Direction direction, SpritesetEditView parent)
        {
            InitializeComponent();
            NameTextBox.Text = direction.Name;
            NameLabel.Text = direction.Name;
            _sprite = sprite;
            _direction = direction;
            _parent_editor = parent;
            _showDelay = _parent_editor.Settings.GetBoolean("spriteset-showdelay", false);

            foreach (Frame f in direction.Frames) { AddImage(f); }
        }

        public void AddImage(Frame frame)
        {
            FramePanel panel = new FramePanel(frame, _sprite, _parent_editor.Settings);
            panel.Zoom = _zoom;
            ImagesPanel.Controls.Add(panel);
            panel.BringToFront();
            panel.MouseClick += new MouseEventHandler(Panel_MouseClick);
            panel.MouseEnter += new System.EventHandler(Panel_MouseEnter);
            Invalidate(true);
            if (Modified != null) Modified(this, new EventArgs());
        }

        public void Select(int index)
        {
            index = ImagesPanel.Controls.Count - 1 - index;
            if (ImagesPanel.Controls[index] is FramePanel)
            {
                if (SelectedFrame != null) SelectedFrame.Selected = false;
                SelectedFrame = (FramePanel)ImagesPanel.Controls[index];
                SelectedFrame.Selected = true;
            }
        }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            _hovered_frame = (FramePanel)sender;
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectedFrame != null) SelectedFrame.Selected = false;
            SelectedFrame = (FramePanel)sender;
            SelectedFrame.Selected = true;
            if (OnFrameClick != null) OnFrameClick(this, new EventArgs());
        }

        public int Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                foreach (Control p in ImagesPanel.Controls) { if (p is FramePanel) ((FramePanel)p).Zoom = value; }
                AddPanel.Height = _sprite.SpriteHeight * _zoom;
                MinimumSize = new System.Drawing.Size(_sprite.SpriteWidth*_zoom, _sprite.SpriteHeight * _zoom);
                Invalidate(true);
            }
        }

        public Direction Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        private void AddFrameButton_Click(object sender, System.EventArgs e)
        {
            Frame f = new Frame();
            AddImage(f);
            _direction.Frames.Add(f);
        }

        private void RemoveFrameButton_Click(object sender, EventArgs e)
        {
            if (ImagesPanel.Controls.Count > 0)
            {
                ImagesPanel.Controls.RemoveAt(0);
                _direction.Frames.RemoveAt(_direction.Frames.Count-1);
                if (Modified != null) Modified(this, new EventArgs());
            }
        }

        private void DirectionLayout_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

            if (e.Data.GetDataPresent("Frame"))
                _panel_to_add = (FramePanel)e.Data.GetData("Frame");
            else if (e.Data.GetDataPresent("ImageFrame"))
            {
                Frame frame = (Frame)e.Data.GetData("ImageFrame");
                FramePanel panel = new FramePanel(frame, _sprite, _parent_editor.Settings);
                panel.Zoom = _zoom;
                panel.MouseClick += new MouseEventHandler(Panel_MouseClick);
                panel.MouseEnter += new System.EventHandler(Panel_MouseEnter);
                _panel_to_add = panel;
            }
            else
                _panel_to_add = null;
        }

        private void DirectionLayout_DragDrop(object sender, DragEventArgs e)
        {
            if (_panel_to_add == null) return;
            if (e.Data.GetDataPresent("Frame") || e.Data.GetDataPresent("ImageFrame"))
            {
                // commit to the removal of the frame from the dragged_from direction:
                if (_panel_to_add.Parent != null)
                {
                    DirectionLayout last_dir = ((DirectionLayout)_panel_to_add.Parent.Parent);
                    last_dir._direction.Frames.RemoveAt(last_dir._direction.Frames.IndexOf(_panel_to_add.Frame));
                }

                ImagesPanel.Controls.Add(_panel_to_add);

                Point Location = ImagesPanel.PointToClient(new Point(e.X, e.Y));
                FramePanel place_panel = (FramePanel)ImagesPanel.GetChildAtPoint(Location);
                ImagesPanel.Controls.SetChildIndex(_panel_to_add, ImagesPanel.Controls.IndexOf(place_panel));

                // and add the frame to the dragged_to direction:
                int pos = _direction.Frames.Count - (ImagesPanel.Controls.IndexOf(_panel_to_add));
                _direction.Frames.Insert(pos, _panel_to_add.Frame);

                _panel_to_add = null;
                Invalidate(true);
                Modified?.Invoke(this, new EventArgs());
            }
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            AddImage(new Frame());
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (SelectedFrame == null) return;

            int index = SelectedFrame.Parent.Controls.IndexOf(SelectedFrame);
            SelectedFrame.Parent.Controls.Remove(SelectedFrame);
            _direction.Frames.RemoveAt(_direction.Frames.Count - 1 - index);

            if (index < ImagesPanel.Controls.Count && ImagesPanel.Controls[index] is FramePanel)
                SelectedFrame = (FramePanel)ImagesPanel.Controls[index];
            else
                SelectedFrame = null;
            Modified?.Invoke(this, new EventArgs());
        }

        private void ToggleItem_Click(object sender, EventArgs e)
        {
            _showDelay = !_showDelay;
            _parent_editor.Settings.SetValue("spriteset-showdelay", _showDelay);
            Parent.Invalidate(true);
        }

        private void DirectionStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Point loc = ImagesPanel.PointToClient(Cursor.Position);
            Control ctrl = ImagesPanel.GetChildAtPoint(loc);
            if (ctrl is FramePanel) {
                if (SelectedFrame != null)
                    SelectedFrame.Selected = false;
                SelectedFrame = (FramePanel)ctrl;
                SelectedFrame.Selected = true;
            }
            else {
                SelectedFrame = null;
            }

            ToggleItem.Checked = _showDelay;

            RemoveItem.Enabled = SelectedFrame != null;
            SetDelayItem.Enabled = SelectedFrame != null;
        }

        private void NameLabel_MouseDown(object sender, MouseEventArgs e)
        {
            _drag = true;
            _drag_start = e.Location;
        }

        private void NameLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_drag) return;

            int xx = _drag_start.X - e.X;
            int yy = _drag_start.Y - e.Y;
            if (Math.Sqrt(xx * xx + yy * yy) > 4)
            {
                DoDragDrop(this, DragDropEffects.All);
                _drag = false;
            }
        }

        private void DirectionLayout_Paint(object sender, PaintEventArgs e)
        {
            if (_panel_to_add == null) return;
            Bitmap panel_img = new Bitmap(_panel_to_add.ClientRectangle.Width, _panel_to_add.ClientRectangle.Height);

            Point loc = PointToClient(Cursor.Position);
            e.Graphics.DrawImage(panel_img, loc.X, loc.Y);
        }

        private void DirectionLayout_DragOver(object sender, DragEventArgs e)
        {
            Refresh();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_direction != null) _direction.Name = NameTextBox.Text;
            NameLabel.Text = NameTextBox.Text;
            if (Modified != null) Modified(this, new EventArgs());
        }

        private void ZoomInItem_Click(object sender, EventArgs e)
        {
            _parent_editor.ZoomIn();
            if (!_parent_editor.CanZoomIn) ZoomInItem.Enabled = false;
            ZoomOutItem.Enabled = true;
        }

        private void ZoomOutItem_Click(object sender, EventArgs e)
        {
            _parent_editor.ZoomOut();
            if (!_parent_editor.CanZoomOut) ZoomOutItem.Enabled = false;
            ZoomInItem.Enabled = true;
        }

        private void AddDirectionItem_Click(object sender, EventArgs e)
        {
            _parent_editor.AddNewDirection();
            _parent_editor.UpdateControls();
        }

        private void RemoveDirectionItem_Click(object sender, EventArgs e)
        {
            _parent_editor.RemoveDirection(this);
        }

        private void SetDelayItem_Click(object sender, EventArgs e)
        {
            StringInputForm frm = new StringInputForm("Set Frame Delay");
            frm.Input = SelectedFrame.Delay.ToString();
            frm.NumbersOnly = true;
            if (frm.ShowDialog() == DialogResult.OK) {
                SelectedFrame.Delay = short.Parse(frm.Input);
            }
            SelectedFrame.Refresh();
        }
    }
}
