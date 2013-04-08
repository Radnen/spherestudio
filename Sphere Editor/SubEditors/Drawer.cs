using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Sphere_Editor.EditorComponents;
using Sphere_Editor.Forms.ColorPicker;
using Sphere.Core.SphereObjects;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere_Editor.SubEditors
{
    public partial class Drawer : EditorObject
    {
        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler ImageEdited;
        private string _filename;
        private bool _show_dirty = true;
        private bool _is_large = false;

        private DockContent DrawContent = new DockContent();
        private DockContent PaletteContent = new DockContent();
        private DockContent LayerContent = new DockContent();
        private DockPanel EditorDock = new DockPanel();
        private LayerControl ImageLayers = new LayerControl();

        public Drawer()
        {
            InitializeComponent();
            InitializeDocking();
            Init();
        }

        public Drawer(string filename)
        {
            InitializeComponent();
            InitializeDocking();
            this._filename = filename;
            Init();
        }

        private void InitializeDocking()
        {
            if (!Global.CurrentEditor.UseDockForm) return;
            EditorDock.DocumentStyle = DocumentStyle.DockingSdi;
            this.Controls.Add(EditorDock);

            EditorPanel.Dock = DrawerPanel.Dock = DockStyle.Fill;
            DrawContent.Controls.Add(DrawerPanel);

            PaletteContent.Controls.Add(EditorPanel);
            PaletteContent.DockAreas = DockAreas.DockLeft | DockAreas.DockRight;
            PaletteContent.Text = "Palette";
            PaletteContent.DockHandler.CloseButtonVisible = false;

            ImageLayerHolder.Dock = DockStyle.Fill;
            LayerContent.Controls.Add(ImageLayerHolder);
            LayerContent.DockAreas = DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Float;
            LayerContent.Text = "Layers";
            LayerContent.DockHandler.CloseButtonVisible = false;

            DrawContent.Show(EditorDock, DockState.Document);
            PaletteContent.Show(EditorDock, DockState.DockRight);
            //LayerContent.Show(EditorDock, DockState.DockLeft);
            EditorDock.Dock = DockStyle.Fill;
        }

        private void Init()
        {
            ColorBox1.Selected = true;
            ColorBox1.SelectedColor = Color.White;
            ColorBox2.SelectedColor = Color.Black;
            ImageEditor.DrawColor = Color.White;
            ImageEditor.DynaPalette = DynaPalette;
            ImageEditor.LocationLabel = this.LocationLabel;
            DynaPalette.ImageController = ImageEditor;

            ImageLayers.Type = "ImageLayer";
            ImageLayers.AddItem("Untitled", true);
            ImageLayers.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            ImageLayers.LayerVisibilityChanged += new LayerControl.LayerEvent(ImageLayers_LayerVisibilityChanged);
            LayersPanel.Controls.Add(ImageLayers);
        }

        private void ImageLayers_LayerVisibilityChanged(object sender, LayerItem li)
        {
            int index = ImageLayers.SelectedIndex;
            if (index == -1) return;
            ImageEditor.LayerVisibility[index] = !ImageEditor.LayerVisibility[index];
            ImageEditor.Refresh();
        }

        public override void CreateNew()
        {
            SetZoom(2);
        }

        public override void Destroy()
        {
            DrawContent.Dispose();
            LayerContent.Dispose();
            PaletteContent.Dispose();
            EditorDock.Dispose();
            ImageLayers.Dispose();
            ImageEditor.Destroy();
            DynaPalette.Dispose();
            Dispose();
        }

        public override void Save()
        {
            if (this._filename == null) SaveAs();
            else
            {
                using (Image img = ImageEditor.Image)
                {
                    img.Save(this._filename);
                }
                Parent.Text = System.IO.Path.GetFileName(this._filename);
            }
        }

        public override void SaveAs()
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "Image Files (.png, .gif, .bmp, .jpg)|*.png;*.gif;*.bmp;*.jpg";

            if (Global.CurrentProject.RootPath != null)
                diag.InitialDirectory = Global.CurrentProject.RootPath + "\\images";

            if (diag.ShowDialog() == DialogResult.OK)
            {
                _filename = diag.FileName;
                Save();
            }
        }

        public override void LoadFile(string filename)
        {
            Bitmap img = (Bitmap)Bitmap.FromFile(filename);
            SetImage(img);
            img.Dispose();
        }

        public override void Copy() { ImageEditor.Copy(); }
        public override void Paste() { ImageEditor.Paste(); }
        public override void Undo() { if (ImageEditor.Undoable) ImageEditor.UndoAction(); }
        public override void Redo() { if (ImageEditor.Redoable) ImageEditor.RedoAction(); }
        public override void ZoomIn() { ZoomInClick(null, EventArgs.Empty); }
        public override void ZoomOut() { ZoomOutClick(null, EventArgs.Empty); }

        public void SetImage(Bitmap image)
        {
            int size = image.Width * image.Height;
            _is_large = (size >= 1048576);
            ImageEditor.SetImage(image);
            UndoButton.Enabled = ImageEditor.Undoable;
            RedoButton.Enabled = ImageEditor.Redoable;
        }

        public void SetZoom(int zoom)
        {
            ImageEditor.SetZoom(zoom);
            ImageEditor.Refresh();
            ZoomLabel.Text = "Zoom: " + zoom + "x";
            if (zoom > 1) ZoomInButton.Enabled = true;
            if (zoom < 32) ZoomOutButton.Enabled = true;
        }

        /// <summary>
        /// Sets the new size of the Image.
        /// </summary>
        /// <param name="width">The new width parameter.</param>
        /// <param name="height">The new height parameter.</param>
        /// <param name="scale">The scale parameter; if true, it shall scale the image accordingly.</param>
        public void SetSize(int width, int height, bool scale, InterpolationMode mode)
        {
            ImageEditor.ResizeImage(width, height, scale, mode);
            ImageEditor.UpdateControl();
            ImageEditor.Refresh();
        }

        public void SetTileImageMap(Bitmap img, short[] indices)
        {
            ImageEditor.SetTileImageMap(img, indices);
            ImageEditor.SetZoom(ImageEditor.Zoom);
        }

        public int GetTileAmount()
        {
            return ImageEditor.ImageAmount;
        }

        public TileImage[] GetUncompiledTiles(int tile_width, int tile_height)
        {
            return ImageEditor.GetEditorImageTiles(tile_width, tile_height);
        }

        public void SetImageSize(int width, int height)
        {
            ImageEditor.SetSize(width, height);
        }

        public Bitmap Image
        {
            get { return ImageEditor.Image; }
        }

        public bool CanDirty
        {
            get { return _show_dirty; }
            set { _show_dirty = value; }
        }

        private void OutlineButton_Click(object sender, EventArgs e)
        {
            ImageEditor.Outline = !ImageEditor.Outline;
        }

        private void ShowGridButton_Click(object sender, EventArgs e)
        {
            ImageEditor.ToggleGrid();
        }

        private void ZoomInClick(object sender, EventArgs e)
        {
            int zoom = ImageEditor.Zoom;
            if (zoom < 32)
            {
                ImageEditor.SetZoom(zoom * 2);
                ZoomOutButton.Enabled = true;
            }
            if (ImageEditor.Zoom == 32) ZoomInButton.Enabled = false;
            ZoomLabel.Text = "Zoom: " + ImageEditor.Zoom + "x";
        }

        private void ZoomOutClick(object sender, EventArgs e)
        {
            int zoom = ImageEditor.Zoom;
            if (zoom > 1)
            {
                ImageEditor.SetZoom(zoom / 2);
                ZoomInButton.Enabled = true;
            }
            if (ImageEditor.Zoom == 1) ZoomOutButton.Enabled = false;
            ZoomLabel.Text = "Zoom: " + ImageEditor.Zoom + "x";
        }

        private void ImagePanel_Resize(object sender, EventArgs e)
        {
            ImageEditor.UpdateControl();
            ImageEditor.Refresh();
            ImagePanel.Refresh();
        }

        private void Color1_MouseClick(object sender, MouseEventArgs e)
        {
            ColorBox1.Selected = true;
            ColorBox2.Selected = false;
            ImageEditor.DrawColor = ColorBox1.SelectedColor;
            Refresh();
        }

        private void Color2_MouseClick(object sender, MouseEventArgs e)
        {
            ColorBox2.Selected = true;
            ColorBox1.Selected = false;
            ImageEditor.DrawColor = ColorBox2.SelectedColor;
            Refresh();
        }

        private void ColorUpdated(object sender, EventArgs e)
        {
            AlphaTracker.Value = 255;
            ImageEditor.DrawColor = ((ColorBox)sender).SelectedColor;
        }

        private void AlphaTracker_Scroll(object sender, EventArgs e)
        {
            AlphaLabel.Text = "Alpha: " + AlphaTracker.Value;
            if (ColorBox1.Selected)
            {
                ColorBox1.SelectedColor = Color.FromArgb(AlphaTracker.Value, ColorBox1.SelectedColor);
                ImageEditor.DrawColor = ColorBox1.SelectedColor;
            }
            else
            {
                ColorBox2.SelectedColor = Color.FromArgb(AlphaTracker.Value, ColorBox2.SelectedColor);
                ImageEditor.DrawColor = ColorBox2.SelectedColor;
            }
        }

        private void ImageEditor_ImageEdited(object sender, EventArgs e)
        {
            UndoButton.Enabled = ImageEditor.Undoable;
            RedoButton.Enabled = ImageEditor.Redoable;

            if (_show_dirty && !Parent.Text.Contains("*")) Parent.Text += "*";
            
            if (ImageEdited != null) ImageEdited(this, new EventArgs());
        }

        private void ImageEditor_ColorChanged(object sender, EventArgs e)
        {
            AlphaTracker.Value = ImageEditor.DrawColor.A;
            AlphaLabel.Text = "Alpha: " + AlphaTracker.Value;
            if (ColorBox1.Selected) ColorBox1.SelectedColor = ImageEditor.DrawColor;
            else ColorBox2.SelectedColor = ImageEditor.DrawColor;
            Refresh();
        }

        // sure there might be a better way, but this is more elegamt due to it's simplicity.
        private void UnselectButtons()
        {
            RectangleButton.Checked = false;
            LineButton.Checked = false;
            PencilButton.Checked = false;
            FillButton.Checked = false;
            PanButton.Checked = false;
        }

        #region tool buttons
        private void PencilButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            ImageEditor.ToolNum = 0;
            PencilButton.Checked = true;
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            ImageEditor.ToolNum = 1;
            LineButton.Checked = true;
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            ImageEditor.ToolNum = 2;
            RectangleButton.Checked = true;
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            ImageEditor.ToolNum = 3;
            FillButton.Checked = true;
        }

        // ellipse()

        private void PanButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            ImageEditor.ToolNum = 5;
            PanButton.Checked = true;
        }
        #endregion

        private void UndoButton_Click(object sender, EventArgs e)
        {
            ImageEditor.UndoAction();
            UndoButton.Enabled = ImageEditor.Undoable;
            RedoButton.Enabled = ImageEditor.Redoable;
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            ImageEditor.RedoAction();
            RedoButton.Enabled = ImageEditor.Redoable;
            UndoButton.Enabled = ImageEditor.Undoable;
        }

        private void DynaPalette_Resize(object sender, EventArgs e)
        {
            DynaPalette.OrganizePalette();
        }
    }
}
