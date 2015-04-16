using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere.Core.Editor;
using Sphere.Plugins;

namespace SphereStudio.Plugins
{
    public partial class FontEditor : EditorObject
    {
        readonly FontSet _fontLayout;
        Font _selected;

        public FontEditor()
        {
            _fontLayout = new FontSet();
            InitializeComponent();
            InitializeFontLayout();
            CompilePreview();
        }

        private void InitializeFontLayout()
        {
            _fontLayout.Dock = DockStyle.Left;
            _fontLayout.CharSelected += FontLayout_CharSelected;
            _fontLayout.LayoutZoomed += FontLayout_LayoutZoomed;
            _fontLayout.Selection = 65;
            FontPanel.Controls.Add(_fontLayout);
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
            MakeDirty();
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
                SetTabText(Path.GetFileName(FileName));
                _fontLayout.SaveToFile(FileName);
            }
        }

        public override void SaveAs()
        {
            SaveFileDialog diag = new SaveFileDialog {Filter = @"Font Files (.rfn)|*.rfn"};

            if (PluginManager.IDE.CurrentGame != null)
                diag.InitialDirectory = PluginManager.IDE.CurrentGame.RootPath + "\\fonts";

            if (diag.ShowDialog() == DialogResult.OK)
            {
                FileName = diag.FileName;
                Save();
            }
        }

        public override void LoadFile(string filename)
        {
            if (!File.Exists(filename)) return;
            base.LoadFile(filename);
            _fontLayout.LoadFromFile(filename);
            CompilePreview();
            SetTabText(Path.GetFileName(filename));
        }

        public override void ZoomIn()
        {
            _fontLayout.ZoomIn();
        }

        public override void ZoomOut()
        {
            _fontLayout.ZoomOut();
        }

        public override void Paste()
        {
            IDataObject data = Clipboard.GetDataObject();
            if (data != null && data.GetDataPresent(DataFormats.Text)) PreviewTextBox.Text = (string)data.GetData(DataFormats.Text);
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
