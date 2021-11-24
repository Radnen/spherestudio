using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using SphereStudio.Base;
using SphereStudio.Plugins.Components;
using SphereStudio.UI;

namespace SphereStudio.Plugins
{
    partial class ImageEditView : ImageView
    {
        private readonly DockContent _drawContent = new DockContent();
        private readonly DockContent _paletteContent = new DockContent();
        private readonly DockPanel _editorDock = new DockPanel();

        private ColorBox _selectedBox;

        public ImageEditView()
        {
            InitializeComponent();
            InitializeDocking();

            Icon = Icon.FromHandle(Properties.Resources.palette.GetHicon());

            for (int i = 0; i < 8; ++i)
            {
                ColorBox box = new ColorBox { SelectedColor = Color.White };
                box.ColorChanged += ColorUpdated;
                box.MouseClick += box_MouseClick;
                ColorFlow.Controls.Add(box);
            }

            box_MouseClick(ColorFlow.Controls[0], null);
        }

        public override Bitmap Content
        {
            get { return ImageEditor.EditImage; }
            set
            {
                ImageEditor.SetImage(value);
                ImageEditor.ClearHistory();
                UndoButton.Enabled = RedoButton.Enabled = false;
                ImageEditor.Invalidate();
            }
        }

        public override string[] FileExtensions
        {
            get { return new[] { "png", "jpg", "bmp", "gif" }; }
        }

        public override bool NewDocument()
        {
            ImageEditor.MakeNew(80, 80);
            return true;
        }

        public override void Load(string path)
        {
            using (Bitmap img = (Bitmap)Image.FromFile(path))
            {
                ImageEditor.SetImage(img);
            }
        }

        public override void Save(string path)
        {
            using (Image img = ImageEditor.GetImage())
            {
                img.Save(path);
            }
            IsDirty = false;
        }

        public override void Activate()
        {
            PluginMain.ShowMenus(true);
        }

        public override void Deactivate()
        {
            PluginMain.ShowMenus(false);
        }

        public override void Undo()
        {
            if (ImageEditor.CanUndo) ImageEditor.Undo();
            UndoButton.Enabled = ImageEditor.CanUndo;
            RedoButton.Enabled = ImageEditor.CanRedo;
            IsDirty = true;
        }

        public override void Redo()
        {
            if (ImageEditor.CanRedo) ImageEditor.Redo();
            UndoButton.Enabled = ImageEditor.CanUndo;
            RedoButton.Enabled = ImageEditor.CanRedo;
            IsDirty = true;
        }

        public void Rescale(int width, int height, InterpolationMode mode)
        {
            ImageEditor.RescaleImage(width, height, mode);
        }

        public new void Resize(int width, int height)
        {
            ImageEditor.ResizeImage(width, height);
        }

        void box_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ColorBox box in ColorFlow.Controls)
                box.Selected = false;

            _selectedBox = (ColorBox)sender;

            _selectedBox.Selected = true;
            ImageEditor.DrawColor = _selectedBox.SelectedColor;
            AlphaTracker.Value = _selectedBox.SelectedColor.A;
            Invalidate();
        }

        private void InitializeDocking()
        {
            _editorDock.DocumentStyle = DocumentStyle.DockingSdi;
            Controls.Add(_editorDock);

            EditorPanel.Dock = DrawerPanel.Dock = DockStyle.Fill;
            _drawContent.Controls.Add(DrawerPanel);

            _paletteContent.Controls.Add(EditorPanel);
            _paletteContent.DockAreas = DockAreas.DockLeft | DockAreas.DockRight;
            _paletteContent.Text = @"Palette";
            _paletteContent.DockHandler.CloseButtonVisible = false;

            _drawContent.Show(_editorDock, DockState.Document);
            _paletteContent.Show(_editorDock, DockState.DockRight);
            _editorDock.Dock = DockStyle.Fill;
        }


        public void SetImage(Bitmap image)
        {
            ImageEditor.SetImage(image);
            ImageEditor.Invalidate();
        }

        /// <summary>
        /// Cuts up and returns a list of sub-images.
        /// </summary>
        /// <param name="tileWidth">Width of sub-image.</param>
        /// <param name="tileHeight">Height of sub-image.</param>
        /// <returns></returns>
        public override Bitmap[] GetImages(short tileWidth, short tileHeight)
        {
            List<Bitmap> images = new List<Bitmap>();
            Bitmap source = (Bitmap)ImageEditor.EditImage;
            Rectangle sourceRect = new Rectangle(0, 0, tileWidth, tileHeight);
            int w = ImageEditor.EditImage.Width;
            int h = ImageEditor.EditImage.Height;
            for (int y = 0; y < h; y += tileHeight)
            {
                sourceRect.Y = y;
                for (int x = 0; x < w; x += tileWidth)
                {
                    sourceRect.X = x;
                    images.Add(source.Clone(sourceRect, System.Drawing.Imaging.PixelFormat.Format32bppPArgb));
                }
            }
            return images.ToArray();
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

        private void OutlineButton_Click(object sender, EventArgs e)
        {
            ImageEditor.Outlined = OutlineButton.Checked;
        }

        private void ShowGridButton_Click(object sender, EventArgs e)
        {
            ImageEditor.UseGrid = ShowGridButton.Checked;
            ImageEditor.Invalidate(false);
        }

        private void ColorUpdated(object sender, EventArgs e)
        {
            AlphaTracker.Value = 255;
            ImageEditor.DrawColor = ((ColorBox)sender).SelectedColor;
        }

        private void AlphaTracker_Scroll(object sender, EventArgs e)
        {
            AlphaLabel.Text = @"Alpha: " + AlphaTracker.Value;

            _selectedBox.SelectedColor = Color.FromArgb(AlphaTracker.Value, _selectedBox.SelectedColor);
            ImageEditor.DrawColor = _selectedBox.SelectedColor;
        }

        // sure there might be a better way, but this is more elegant due to it's simplicity.
        private void UnselectButtons()
        {
            RectangleButton.Checked = false;
            LineButton.Checked = false;
            PencilButton.Checked = false;
            FillButton.Checked = false;
            PanButton.Checked = false;
            MirrorButton.Enabled = MirrorHButton.Enabled = false;
        }

        #region tool buttons
        private void PencilButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            PencilButton.Checked = true;
            MirrorButton.Enabled = MirrorHButton.Enabled = true;
            ImageEditor.Tool = ImageEditControl.ImageTool.Pen;
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            LineButton.Checked = true;
            ImageEditor.Tool = ImageEditControl.ImageTool.Line;
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            RectangleButton.Checked = true;
            ImageEditor.Tool = ImageEditControl.ImageTool.Rectangle;
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            FillButton.Checked = true;
            ImageEditor.Tool = ImageEditControl.ImageTool.Floodfill;
        }

        // ellipse()

        private void PanButton_Click(object sender, EventArgs e)
        {
            UnselectButtons();
            PanButton.Checked = true;
            ImageEditor.Tool = ImageEditControl.ImageTool.Pan;
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

        private void ImageEditor_ColorChanged(object sender, EventArgs e)
        {
            _selectedBox.SelectedColor = ImageEditor.DrawColor;
            AlphaTracker.Value = ImageEditor.DrawColor.A;
            AlphaLabel.Text = @"Alpha: " + AlphaTracker.Value;
        }

        private void ImageEditor_ImageChanged(object sender, EventArgs e)
        {
            UndoButton.Enabled = ImageEditor.CanUndo;
            RedoButton.Enabled = ImageEditor.CanRedo;
            IsDirty = true;
        }

        private void ImageEditor_Paint(object sender, PaintEventArgs e)
        {
            ZoomLabel.Text = @"Zoom: " + ImageEditor.Zoom;
        }

        private void MirrorButton_Click(object sender, EventArgs e)
        {
            ImageEditor.MirrorV = MirrorButton.Checked;
        }

        private void AlphaTracker_ValueChanged(object sender, EventArgs e)
        {
            AlphaLabel.Text = @"Alpha: " + AlphaTracker.Value;
        }

        private void MirrorHButton_Click(object sender, EventArgs e)
        {
            ImageEditor.MirrorH = MirrorHButton.Checked;
        }
    }
}
