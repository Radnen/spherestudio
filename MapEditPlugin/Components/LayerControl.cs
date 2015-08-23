using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Sphere.Core;
using SphereStudio.Plugins.Forms;

namespace SphereStudio.Plugins.Components
{
    public partial class LayerControl : UserControl
    {
        #region attributes
        private LayerItem hovered_item;
        private int drag_x, drag_y;
        private short _start_layer;
        private bool do_drag, draw_drag;
        private Point DragStart = Point.Empty;

        public List<LayerItem> Items { get; private set; }
        public LayerItem SelectedItem { get; private set; }
        public int MovedIndex { get; private set; }
        public int HomeIndex { get; private set; }

        /// <summary>
        /// The type of layer the control holds. Helps to distinguish between image and map layers.
        /// </summary>
        public string Type { get; set; }

        public DragDropEffects drag;
        #endregion

        public delegate void LayerEvent(LayerControl sender, LayerItem layer);

        public event LayerEvent LayerSelected;
        public event LayerEvent LayerVisibilityChanged;
        public event LayerEvent LayerChanged;

        public LayerControl()
        {
            InitializeComponent();
            Items = new List<LayerItem>();
            Type = "MapLayer";
            Height = 1;
        }

        public short StartLayer
        {
            get { return _start_layer; }
            set
            {
                if (Items.Count > 0)
                {
                    Items[_start_layer].Start = false;
                    Items[value].Start = true;
                    _start_layer = value;
                }
            }
        }

        public void AddItem(string name, bool visible)
        {
            LayerItem item = new LayerItem();
            item.Bounds = new Rectangle(0, 0, Width, 19);
            item.Visible = visible;
            item.Text = name;
            item.Index = Items.Count;
            Items.Add(item);
            Height += 20;
        }

        public void ClearItems()
        {
            Items.Clear();
            Height = 1;
        }

        public void AddItem(LayerItem item)
        {
            item.Bounds = new Rectangle(0, 0, Width, 19);
            item.Index = Items.Count;
            Items.Add(item);
            Height += 20;
        }

        public void InsertItem(int index, LayerItem item)
        {
            item.Bounds = new Rectangle(0, 0, Width, 19);
            Items.Insert(index, item);

            for (int i = 0; i < Items.Count; ++i) Items[i].Index = i;
            Height += 20;
        }

        public void RemoveItem(int index)
        {
            Items.RemoveAt(index);

            if (index < Items.Count - 1) SelectItem(index);
            else SelectItem(Items.Count - 1);

            for (int i = 0; i < Items.Count; ++i) Items[i].Index = i;
            Height -= 20;
        }

        public void SelectItem(int index)
        {
            foreach (LayerItem li in Items) li.State = ListViewItemStates.Default;
            Items[index].State = ListViewItemStates.Selected;
            SelectedItem = Items[index];
            if (LayerSelected != null) LayerSelected(this, SelectedItem);
        }

        // Gets index of item:
        public short SelectedIndex
        {
            get { return (short)Items.IndexOf(SelectedItem); }
        }

        private void LayerControl_Paint(object sender, PaintEventArgs e)
        {
            for (int i = Items.Count - 1; i >= 0; --i)
                Items[Items.Count - 1 - i].PaintItem(e.Graphics, Location.X, Location.Y + i * 20, ClientRectangle.Width);

            if (draw_drag && SelectedItem != null)
            {
                Point loc = PointToClient(Cursor.Position);
                SelectedItem.PaintItem(e.Graphics, loc.X, loc.Y, ClientRectangle.Width);
            }
        }

        private void LayerControl_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (LayerItem li in Items)
            {
                li.Hover = (e.X > li.Bounds.X && e.Y > li.Bounds.Y &&
                    e.X < li.Bounds.X + li.Bounds.Width && e.Y < li.Bounds.Y + li.Bounds.Height);
            }

            Invalidate();

            if (do_drag) // check if the users moves far enough to really drag:
            {
                int xx = DragStart.X - e.X;
                int yy = DragStart.Y - e.Y;
                if (Math.Sqrt(xx * xx + yy * yy) > 4) // 4 pixels is optimum distance
                {
                    draw_drag = true;
                    SelectedItem.CanUpdate = false;
                    drag = DoDragDrop(new DataObject(Type, SelectedItem), DragDropEffects.Move);
                    SelectedItem.CanUpdate = true;
                    do_drag = draw_drag = false;
                }
            }
        }

        private void LayerControl_MouseLeave(object sender, EventArgs e)
        {
            foreach (LayerItem li in Items) li.Hover = false;
            Invalidate();
        }

        private void LayerControl_Load(object sender, EventArgs e)
        {
            if (Items == null) return;
            Height = (Items.Count * 20) + 1;
        }

        private void LayerControl_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void LayerControl_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (LayerItem li in Items)
            {
                // if mouse is in eye location, toggle it, else select layer.
                if (e.X > li.Bounds.X && e.Y > li.Bounds.Y && e.X < li.Bounds.Width && e.Y < li.Bounds.Y + li.Bounds.Height)
                {
                    if (e.X <= 18)
                    {
                        if (li.IsInEye(e.Location))
                        {
                            li.Visible = !li.Visible;
                            if (LayerVisibilityChanged != null) LayerVisibilityChanged(this, li);
                        }
                    }
                    else if (li.Hover)
                    {
                        if (SelectedItem != null) SelectedItem.State = ListViewItemStates.Default;
                        li.State = ListViewItemStates.Selected;
                        SelectedItem = li;

                        if (LayerSelected != null) LayerSelected(this, li);
                        do_drag = true;
                        DragStart = e.Location;
                    }
                    else li.State = ListViewItemStates.Default;
                }
            }
            Refresh();
        }

        private void LayerControl_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(Type))
            {
                SelectedItem.CanUpdate = true;
                LayerItem li = (LayerItem)e.Data.GetData(Type);
                HomeIndex = Items.IndexOf(li);
                MovedIndex = Items.IndexOf(hovered_item);
                if (MovedIndex == -1) return;
                Items.Remove(li);
                Height -= 20;
                InsertItem(MovedIndex, li);
                if (LayerChanged != null) LayerChanged(this, li);
            }
        }

        private void LayerControl_DragOver(object sender, DragEventArgs e)
        {
            Point m = PointToClient(new Point(e.X, e.Y));
            drag_x = m.X;
            drag_y = m.Y;
            foreach (LayerItem li in Items)
            {
                li.Hover = (m.X > li.Bounds.X && m.Y > li.Bounds.Y &&
                    m.X < li.Bounds.X + li.Bounds.Width && m.Y < li.Bounds.Y + li.Bounds.Height);
                if (li.Hover) hovered_item = li; e.Effect = DragDropEffects.Move;
            }
            Refresh();
        }

        private void LayerControl_MouseUp(object sender, MouseEventArgs e) { do_drag = draw_drag = false; }

        private void LayerControl_DragLeave(object sender, EventArgs e)
        {
            draw_drag = false;
            Invalidate();
        }

        private void LayerControl_DragEnter(object sender, DragEventArgs e)
        {
            draw_drag = true;
            Invalidate();
        }

        private void LayerControl_DoubleClick(object sender, EventArgs e)
        {
            var localMouseX = PointToClient(MousePosition).X;
            if (this.SelectedItem != null && localMouseX > 18)
                new LayerForm(this.SelectedItem.Layer).ShowDialog();
            Refresh();
        }
    }

    public class LayerItem : IDisposable
    {
        private Rectangle bounds = new Rectangle(0, 0, 128, 128);
        private bool hover, can_update = true;
        private Font font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public ListViewItemStates State { get; set; }

        public bool Visible
        {
            get { return Layer.Visible; }
            set { Layer.Visible = value; }
        }

        public string Text
        {
            get { return Layer.Name; }
            set { Layer.Name = value; }
        }

        public int Index { get; set; }
        public bool Start { get; set; }

        public Rectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }

        public Layer Layer { get; set; }

        public bool CanUpdate
        {
            get { return can_update; }
            set { can_update = value; if (!value) hover = false; }
        }

        public bool Hover
        {
            get { return hover; }
            set { if (CanUpdate) hover = value; }
        }

        public LayerItem() { Layer = new Layer(); Visible = true; }
        public LayerItem(Layer lay) { Layer = lay; }

        public bool IsInEye(Point p)
        {
            return (p.X > bounds.X + 2 && p.Y > bounds.Y + 2 && p.X < bounds.X + 18 && p.Y < bounds.Y + 18);
        }

        public void PaintItem(Graphics g, int x, int y, int width)
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            bounds.Width = width - 1;
            bounds.X = x;
            bounds.Y = y;
            LinearGradientBrush brush = null;

            if (State == ListViewItemStates.Selected)
            {
                if (Hover)
                    brush = new LinearGradientBrush(Point.Empty, new Point(bounds.Width, 0), Color.White, Color.LimeGreen);
                else
                    brush = new LinearGradientBrush(Point.Empty, new Point(bounds.Width, 0), Color.White, Color.LightBlue);
                g.FillRectangle(brush, bounds);
            }
            else if (Hover)
            {
                brush = new LinearGradientBrush(Point.Empty, new Point(bounds.Width, 0), Color.White, Color.Yellow);
                g.FillRectangle(brush, bounds);
            }

            if (Visible)
                g.DrawImage(Properties.Resources.eye, bounds.X + 2, bounds.Y + 2, 16, 16);
            else
                g.DrawImage(Properties.Resources.eye_shut, bounds.X + 2, bounds.Y + 2, 16, 16);

            g.DrawString(Text, font, Brushes.Black, bounds.X + 20, bounds.Y + 3);

            if (Start)
            {
                g.DrawRectangle(Pens.DarkGray, bounds.X + bounds.Width - 16, bounds.Y, 16, bounds.Height - 1);
                g.DrawString("S", font, Brushes.Black, bounds.X + bounds.Width - 14, bounds.Y + 4);
            }

            g.DrawRectangle(Pens.DarkGray, bounds.X, bounds.Y, bounds.Width, bounds.Height - 1);

            if (brush != null) { brush.Dispose(); brush = null; }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private bool _disposed;
        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (font != null) font.Dispose();
                }

                font = null;
            }
            _disposed = true;
        }
    }
}
