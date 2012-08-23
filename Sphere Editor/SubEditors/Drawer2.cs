using System;
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

        public Drawer2()
        {
            InitializeComponent();
            InitializeDocking();
            ColorBox1.Selected = true;
            ColorBox1.SelectedColor = Color.White;
            ColorBox2.SelectedColor = Color.Black;
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

            if (Global.CurrentProject.Path != null)
                diag.InitialDirectory = Global.CurrentProject.Path + "\\images";

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
            if (ColorBox1.Selected) { ColorBox1.SelectedColor = ImageEditor.DrawColor; ColorBox1.Invalidate(); }
            if (ColorBox2.Selected) { ColorBox2.SelectedColor = ImageEditor.DrawColor; ColorBox2.Invalidate(); }
            AlphaTracker.Value = ImageEditor.DrawColor.A;
            AlphaLabel.Text = "Alpha: " + AlphaTracker.Value;
        }
    }
}
