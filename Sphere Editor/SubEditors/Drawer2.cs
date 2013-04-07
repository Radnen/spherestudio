using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Sphere_Editor.EditorComponents;
using Sphere_Editor.Forms.ColorPicker;
using Sphere_Editor.SphereObjects;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere_Editor.SubEditors
{
    public partial class Drawer2 : EditorObject
    {
        public event EventHandler ImageEdited;
        public bool CanDirty { get; set; }

        public bool FixedSize
        {
            get { return ImageEditor.FixedSize; }
            set { ImageEditor.FixedSize = value; }
        }

        public int ImageWidth { get { return ImageEditor.EditImage.Width; } }
        public int ImageHeight { get { return ImageEditor.EditImage.Height; } }

        private string _filename;
        private DockContent DrawContent = new DockContent();
        private DockContent PaletteContent = new DockContent();
        private DockPanel EditorDock = new DockPanel();

        private ColorBox _selected_box;

        public Drawer2()
        {
            InitializeComponent();
            InitializeDocking();

            for (int i = 0; i < 8; ++i)
            {
                ColorBox box = new ColorBox();
                box.SelectedColor = Color.White;
                box.ColorChanged += new EventHandler(ColorUpdated);
                box.MouseClick += new MouseEventHandler(box_MouseClick);
                ColorFlow.Controls.Add(box);
            }

            box_MouseClick(ColorFlow.Controls[0], null);
        }

        void box_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ColorBox box in ColorFlow.Controls)
                box.Selected = false;

            _selected_box = (ColorBox)sender;

            _selected_box.Selected = true;
            ImageEditor.DrawColor = _selected_box.SelectedColor;
            Invalidate();
        }

        private void InitializeDocking()
        {
            if (!Global.CurrentEditor.UseDockForm) return;

            EditorDock.DocumentStyle = DocumentStyle.DockingSdi;
            Controls.Add(EditorDock);

            EditorPanel.Dock = DrawerPanel.Dock = DockStyle.Fill;
            DrawContent.Controls.Add(DrawerPanel);

            PaletteContent.Controls.Add(EditorPanel);
            PaletteContent.DockAreas = DockAreas.DockLeft | DockAreas.DockRight;
            PaletteContent.Text = "Palette";
            PaletteContent.DockHandler.CloseButtonVisible = false;

            DrawContent.Show(EditorDock, DockState.Document);
            PaletteContent.Show(EditorDock, DockState.DockRight);
            EditorDock.Dock = DockStyle.Fill;
        }


        public override void CreateNew() { ImageEditor.MakeNew(80, 80); }
        public override void Copy() { ImageEditor.Copy(); }
        public override void Paste() { ImageEditor.Paste(); }

        public override void Save()
        {
            if (_filename == null) SaveAs();
            else
            {
                using (Image img = ImageEditor.GetImage())
                {
                    img.Save(_filename);
                }
                Parent.Text = System.IO.Path.GetFileName(_filename);
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
            _filename = filename;
            using (Bitmap img = (Bitmap)Bitmap.FromFile(filename))
            {
                ImageEditor.SetImage(img);
            }
        }

        public override void Undo()
        {
            if (ImageEditor.CanUndo) ImageEditor.Undo();
            UndoButton.Enabled = ImageEditor.CanUndo;
            RedoButton.Enabled = ImageEditor.CanRedo;
            if (ImageEdited != null) ImageEdited(this, EventArgs.Empty);
        }

        public override void Redo()
        {
            if (ImageEditor.CanRedo) ImageEditor.Redo();
            UndoButton.Enabled = ImageEditor.CanUndo;
            RedoButton.Enabled = ImageEditor.CanRedo;
            if (ImageEdited != null) ImageEdited(this, EventArgs.Empty);
        }

        public void SetImage(Bitmap image)
        {
            ImageEditor.SetImage(image);
            ImageEditor.Invalidate();
        }

        public void SetImage(Bitmap image, bool clear_history)
        {
            ImageEditor.SetImage(image);
            if (clear_history)
            {
                ImageEditor.ClearHistory();
                UndoButton.Enabled = RedoButton.Enabled = false;
            }
            ImageEditor.Invalidate();
        }

        /// <summary>
        /// Cuts up and returns a list of sub-images.
        /// </summary>
        /// <param name="tile_width">Width of sub-image.</param>
        /// <param name="tile_height">Height of sub-image.</param>
        /// <returns></returns>
        public List<Bitmap> GetImages(short tile_width,short tile_height)
        {
            List<Bitmap> images = new List<Bitmap>();
            Bitmap source = (Bitmap)ImageEditor.EditImage;
            Rectangle sourceRect = new Rectangle(0, 0, tile_width, tile_height);
            int w = ImageEditor.EditImage.Width;
            int h = ImageEditor.EditImage.Height;
            for (int y = 0; y < h; y += tile_height)
            {
                sourceRect.Y = y;
                for (int x = 0; x < w; x += tile_width)
                {
                    sourceRect.X = x;
                    images.Add(source.Clone(sourceRect, System.Drawing.Imaging.PixelFormat.Format32bppPArgb));
                }
            }
            return images;
        }

        public Bitmap GetImage()
        {
            return ImageEditor.GetImage();
        }

        /// <summary>
        /// Sets the new size of the image.
        /// </summary>
        public void SetSize(int width, int height)
        {
            ImageEditor.ResizeImage(width, height);
        }

        /// <summary>
        /// Sets the new scale of the image.
        /// </summary>
        public void SetScale(int width, int height, InterpolationMode mode)
        {
            ImageEditor.RescaleImage(width, height, mode);
        }

        public void SetTileImageMap(Bitmap img, short[] indices)
        {
        }

        private void OutlineButton_Click(object sender, EventArgs e)
        {
            ImageEditor.Outlined = !ImageEditor.Outlined;
        }

        private void ShowGridButton_Click(object sender, EventArgs e)
        {
            ImageEditor.UseGrid = !ImageEditor.UseGrid;
            ImageEditor.Invalidate(false);
        }

        private void ColorUpdated(object sender, EventArgs e)
        {
            AlphaTracker.Value = 255;
            ImageEditor.DrawColor = ((ColorBox)sender).SelectedColor;
        }

        private void AlphaTracker_Scroll(object sender, EventArgs e)
        {
            AlphaLabel.Text = "Alpha: " + AlphaTracker.Value;

            _selected_box.SelectedColor = Color.FromArgb(AlphaTracker.Value, _selected_box.SelectedColor);
            ImageEditor.DrawColor = _selected_box.SelectedColor;
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
            PencilButton.Checked = true;
            ImageEditor.Tool = ImageEditControl2.ImageTool.Pen;
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            LineButton.Checked = true;
            ImageEditor.Tool = ImageEditControl2.ImageTool.Line;
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            RectangleButton.Checked = true;
            ImageEditor.Tool = ImageEditControl2.ImageTool.Rectangle;
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            FillButton.Checked = true;
            ImageEditor.Tool = ImageEditControl2.ImageTool.Floodfill;
        }

        // ellipse()

        private void PanButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            PanButton.Checked = true;
            ImageEditor.Tool = ImageEditControl2.ImageTool.Pan;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            Redo();
        }
        #endregion

        private void ImagePanel_Resize(object sender, EventArgs e)
        {
            ImageEditor.ResizeToFit();
        }

        private void ImageEditor_ImageEdited(object sender, EventArgs e)
        {
            if (ImageEdited != null) ImageEdited(this, EventArgs.Empty);
            UndoButton.Enabled = ImageEditor.CanUndo;
            RedoButton.Enabled = ImageEditor.CanRedo;
            if (CanDirty && !Parent.Text.EndsWith("*")) Parent.Text += "*";
        }

        private void ImageEditor_Paint(object sender, PaintEventArgs e)
        {
            ZoomLabel.Text = "Zoom: " + ImageEditor.Zoom;
        }

        private void ImageEditor_ColorChanged(object sender, EventArgs e)
        {
            _selected_box.SelectedColor = ImageEditor.DrawColor;
            AlphaTracker.Value = ImageEditor.DrawColor.A;
            AlphaLabel.Text = "Alpha: " + AlphaTracker.Value;
        }
    }
}
