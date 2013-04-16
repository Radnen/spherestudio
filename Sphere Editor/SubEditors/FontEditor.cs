using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere_Editor.EditorComponents;
using Sphere_Editor.Forms.ColorPicker;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace Sphere_Editor.SubEditors
{
    public partial class FontEditor : EditorObject
    {
        FontSet FontLayout = new FontSet();
        Font selected = null;

        public FontEditor() { Setup(); }

        public FontEditor(string filename)
        {
            FileName = filename;
            FontLayout.LoadFromFile(filename);
            Setup();
        }

        private void Setup()
        {
            InitializeComponent();
            InitializeFontLayout();
            CompilePreview();
            Disposed += new EventHandler(FontEditor_Disposed);
        }

        void FontEditor_Disposed(object sender, EventArgs e)
        {
            Destroy();
            Disposed -= FontEditor_Disposed;
        }

        private void InitializeFontLayout()
        {
            FontLayout.Dock = DockStyle.Left;
            //FontLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom);
            FontLayout.CharSelected += new FontSet.EventHandler(FontLayout_CharSelected);
            FontLayout.LayoutZoomed += new FontSet.EventHandler(FontLayout_LayoutZoomed);
            FontLayout.Selection = 65;
            FontPanel.Controls.Add(FontLayout);
        }

        private void FontPanel_Scroll(object sender, ScrollEventArgs e)
        {
            FontLayout.Refresh();
        }

        private void FontLayout_CharSelected(object sender, EventArgs e)
        {
            Character ch = FontLayout.Characters[FontLayout.Selection];
            FontSizeLabel.Text = "Size: " + ch.Width + " x " + ch.Height;
            FontSizeLabel.Refresh();
        }


        private void PreviewTextBox_TextChanged(object sender, EventArgs e)
        {
            CompilePreview();
        }

        private void CompilePreview()
        {
            string str = PreviewTextBox.Text;
            Bitmap img = new Bitmap(PreviewImageBox.Width, PreviewImageBox.Height);
            Graphics g = Graphics.FromImage(img);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            int x = 0;
            int zoom = FontLayout.Zoom;
            for (int i = 0; i < str.Length; ++i)
            {
                Bitmap charImg = FontLayout.Characters[(int)str[i]].Image;
                g.DrawImage(charImg, 4+x, 4, charImg.Width*zoom, charImg.Height*zoom);
                x += charImg.Width*zoom;
            }
            g.Dispose();
            PreviewImageBox.Image = img;
        }

        private void FontLayout_LayoutZoomed(object sender, EventArgs e)
        {
            CompilePreview();
        }

        public override void Save()
        {
            if (!IsSaved()) SaveAs();
            else
            {
                Parent.Text = Path.GetFileName(FileName);
                FontLayout.SaveToFile(FileName);
            }
        }

        public override void SaveAs()
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "Font Files (.rfn)|*.rfn";

            if (Global.CurrentProject.RootPath != null)
                diag.InitialDirectory = Global.CurrentProject.RootPath + "\\fonts";

            if (diag.ShowDialog() == DialogResult.OK)
            {
                FileName = diag.FileName;
                Save();
            }
        }

        public override void Paste()
        {
            IDataObject Data = Clipboard.GetDataObject();
            if (Data.GetDataPresent(DataFormats.Text)) PreviewTextBox.Text = (string)Data.GetData(DataFormats.Text);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            FontDialog diag = new FontDialog();
            if (selected != null) diag.Font = selected;
            if (diag.ShowDialog() == DialogResult.OK)
            {
                selected = diag.Font;
                FontLayout.GenerateFont(
                    diag.Font, GradientCheckBox.Checked,
                    GradientTop.SelectedColor, GradientBottom.SelectedColor,
                    StrokeCheck.Checked, StrokeColor.SelectedColor
                 );
                CompilePreview();
            }
        }

        private void PreviewImageBox_Resize(object sender, EventArgs e)
        {
            //CompilePreview();
        }

        private void GradientTop_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog diag = new ColorDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                ((ColorBox)sender).SelectedColor = diag.Color;
                ((ColorBox)sender).Refresh();
            }
        }
    }
}
