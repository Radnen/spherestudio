using System;
using System.Drawing;
using System.Windows.Forms;

using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Plugins
{
    partial class FontEditView : DocumentView
    {
        private FontSet _fontLayout;
        Font _selected;

        public FontEditView()
        {
            InitializeComponent();
            InitializeFontLayout();

            Icon = Icon.FromHandle(Properties.Resources.style.GetHicon());
            
            CompilePreview();
        }

        public override string[] FileExtensions { get { return new[] { "rfn" }; } }

        public override void Load(string filepath)
        {
            _fontLayout.LoadFromFile(filepath);
            CompilePreview();
        }

        public override void Save(string filepath)
        {
            _fontLayout.SaveToFile(filepath);
            IsDirty = false;
        }

        public override void Paste()
        {
            IDataObject data = Clipboard.GetDataObject();
            if (data != null && data.GetDataPresent(DataFormats.Text)) PreviewTextBox.Text = (string)data.GetData(DataFormats.Text);
        }

        public override void ZoomIn()
        {
            _fontLayout.ZoomIn();
        }

        public override void ZoomOut()
        {
            _fontLayout.ZoomOut();
        }

        private void InitializeFontLayout()
        {
            _fontLayout = new FontSet();
            _fontLayout.Dock = DockStyle.Left;
            _fontLayout.CharSelected += FontLayout_CharSelected;
            _fontLayout.LayoutZoomed += FontLayout_LayoutZoomed;
            _fontLayout.Selection = 65;
            FontPanel.Controls.Add(_fontLayout);
        }

        private void CompilePreview()
        {
            string str = PreviewTextBox.Text;
            Bitmap img = new Bitmap(PreviewImageBox.Width, PreviewImageBox.Height);
            Graphics g = Graphics.FromImage(img);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            int x = 0;
            int zoom = _fontLayout.Zoom;
            foreach (char ch in str)
            {
                Bitmap charImg = _fontLayout.Characters[ch].Image;
                g.DrawImage(charImg, 4 + x, 4, charImg.Width * zoom, charImg.Height * zoom);
                x += charImg.Width * zoom;
            }
            g.Dispose();
            PreviewImageBox.Image = img;
        }

        private void FontPanel_Scroll(object sender, ScrollEventArgs e)
        {
            _fontLayout.Refresh();
        }

        private void FontLayout_CharSelected(object sender, EventArgs e)
        {
            Character ch = _fontLayout.Characters[_fontLayout.Selection];
            FontSizeLabel.Text = @"Size: " + ch.Width + @" x " + ch.Height;
            FontSizeLabel.Refresh();
        }


        private void PreviewTextBox_TextChanged(object sender, EventArgs e)
        {
            CompilePreview();
            IsDirty = true;
        }

        private void FontLayout_LayoutZoomed(object sender, EventArgs e)
        {
            CompilePreview();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            using (FontDialog diag = new FontDialog())
            {
                if (_selected != null) diag.Font = _selected;
                try
                {
                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        _selected = diag.Font;
                        _fontLayout.GenerateFont(
                            diag.Font, GradientCheckBox.Checked,
                            GradientTop.SelectedColor, GradientBottom.SelectedColor,
                            StrokeCheck.Checked, StrokeColor.SelectedColor
                         );
                        CompilePreview();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(@"GDI+ only supports TrueType fonts.", @"Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
