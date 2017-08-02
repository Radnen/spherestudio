using System;
using System.Windows.Forms;

namespace SphereStudio.Plugins.Forms
{
    partial class NewMapDialogue : Form
    {
        public NewMapDialogue()
        {
            InitializeComponent();
        }

        public string Tileset
        {
            get { return TilesetTextBox.Text; }
            set { TilesetTextBox.Text = value; }
        }

        public short MapWidth
        {
            get
            {
                if (string.IsNullOrWhiteSpace(WidthTextBox.Text)) return 0;
                else return short.Parse(WidthTextBox.Text);
            }
            set { TilesetTextBox.Text = value.ToString(); }
        }

        public short MapHeight
        {
            get
            {
                if (string.IsNullOrWhiteSpace(HeightTextBox.Text)) return 0;
                else return short.Parse(HeightTextBox.Text);
            }
            set { HeightTextBox.Text = value.ToString(); }
        }

        public short TileWidth
        {
            get
            {
                if (string.IsNullOrWhiteSpace(TileWidthTextBox.Text)) return 0;
                else return short.Parse(TileWidthTextBox.Text);
            }
            set { TileWidthTextBox.Text = value.ToString(); }
        }

        public short TileHeight
        {
            get
            {
                if (string.IsNullOrWhiteSpace(TileHeightTextBox.Text)) return 0;
                else return short.Parse(TileHeightTextBox.Text);
            }
            set { TileHeightTextBox.Text = value.ToString(); }
        }

        private void TilesetButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                diag.Filter = "Tileset Files (.rts)|*.rts";
                diag.InitialDirectory = PluginManager.Core.Project.RootPath + "\\maps";
                if (diag.ShowDialog() == DialogResult.OK) Tileset = diag.FileName;
            }
        }

        private void UseExistingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TilesetButton.Enabled = UseExistingCheckBox.Checked;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            OkayButton.Enabled = MapWidth > 0 & MapHeight > 0 & TileHeight > 0 & TileWidth > 0;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }
    }
}
