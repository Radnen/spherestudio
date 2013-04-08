using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sphere_Editor.SubEditors;
using Sphere.Core.SphereObjects;

namespace Sphere_Editor.Forms
{
    public partial class MapPropertiesForm : Form
    {
        private ScriptEditor ScriptBox = new ScriptEditor();
        public Map Map { get; private set; }
        private int last = 3;
        private List<string> scripts = new List<string>();

        public MapPropertiesForm(Map map)
        {
            Map = map;
            this.scripts.AddRange(map.Scripts);
            InitializeComponent();
            ScriptBox.Dock = DockStyle.Fill;
            ScriptPanel.Controls.Add(ScriptBox);
            TilesetTextbox.Text = this.scripts[0];
            //BgMusicTextbox.Text = this.scripts[1];
            ScriptBox.Text = this.scripts[3];
            TileWidthBox.Text = "" + map.Tileset.TileWidth;
            TileHeightBox.Text = "" + map.Tileset.TileHeight;
            LayerWidthBox.Text = "" + map.Layers[0].Width;
            LayerHeightBox.Text = "" + map.Layers[0].Height;
            EntityNumLabel.Text = "# of Entities: (" + map.Entities.Count + ")";
            ZoneNumLabel.Text = "# of Zones: (" + map.Zones.Count + ")";
            LayerNumLabel.Text = "# of Layers: (" + map.Layers.Count + ")";
            CheckCustomSize();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }

        private void CheckCustomSize()
        {
            int tw = 0, th = 0;
            int lw = 0, lh = 0;
            if (TileWidthBox.Text != String.Empty) tw = int.Parse(TileWidthBox.Text);
            if (TileHeightBox.Text != String.Empty) th = int.Parse(TileHeightBox.Text);
            if (LayerWidthBox.Text != String.Empty) lw = int.Parse(LayerWidthBox.Text);
            if (LayerHeightBox.Text != String.Empty) lh = int.Parse(LayerHeightBox.Text);
            OkayButton.Enabled = (tw != 0 && th != 0 && lw != 0 && lh != 0);
            if (tw != th) TileSizeComboBox.Text = "Custom";
            else
            {
                switch (tw)
                {
                    case 8: TileSizeComboBox.Text = "8 x 8"; break;
                    case 16: TileSizeComboBox.Text = "16 x 16"; break;
                    case 24: TileSizeComboBox.Text = "24 x 24"; break;
                    case 32: TileSizeComboBox.Text = "32 x 32"; break;
                    default: TileSizeComboBox.Text = "Custom"; break;
                }
            }
        }

        private void ScriptTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            scripts[last] = ScriptBox.Text;
            ScriptBox.Text = scripts[ScriptTabControl.SelectedIndex + 3];
            last = ScriptTabControl.SelectedIndex + 3;
        }

        private void TileSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TileSizeComboBox.SelectedIndex)
            {
                case 0: TileWidthBox.Text = TileHeightBox.Text = "8"; break;
                case 1: TileWidthBox.Text = TileHeightBox.Text = "16"; break;
                case 2: TileWidthBox.Text = TileHeightBox.Text = "24"; break;
                case 3: TileWidthBox.Text = TileHeightBox.Text = "32"; break;
            }
            TileSizeComboBox.Text = (string)(TileSizeComboBox.SelectedItem);
            TileSizeComboBox.SelectionLength = 0;
        }

        private void TileWidthBox_TextChanged(object sender, EventArgs e)
        {
            CheckCustomSize();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            short tw = 0, th = 0;
            short lw = 0, lh = 0;
            if (TileWidthBox.Text != String.Empty) tw = short.Parse(TileWidthBox.Text);
            if (TileHeightBox.Text != String.Empty) th = short.Parse(TileHeightBox.Text);
            if (LayerWidthBox.Text != String.Empty) lw = short.Parse(LayerWidthBox.Text);
            if (LayerHeightBox.Text != String.Empty) lh = short.Parse(LayerHeightBox.Text);

            if (tw != Map.Tileset.TileWidth || th != Map.Tileset.TileHeight)
            {
                Map.Tileset.ResizeTiles(tw, th, RescaleCheckBox.Checked);
            }

            if (lw != Map.Layers[0].Width || lh != Map.Layers[0].Height)
            {
                Map.ResizeAllLayers(lw, lh);
            }

            scripts[last] = ScriptBox.Text;
            Map.Scripts.Clear();
            Map.Scripts.AddRange(scripts);
        }
    }
}
