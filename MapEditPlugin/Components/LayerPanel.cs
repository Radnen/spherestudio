using System;
using System.ComponentModel;
using System.Windows.Forms;
using Sphere.Core.Editor;
using SphereStudio.Plugins.Forms;

namespace SphereStudio.Plugins.Components
{
    partial class LayerPanel : UserControl
    {
        public LayerControl Layers { get; set; } = new LayerControl();
        public event EventHandler LayerAdded, LayerRemoved;

        public LayerPanel()
        {
            Layers.Type = "MapLayer";
            Layers.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            InitializeComponent();
            Layers.Width = LayersPanel.Width;
            LayersPanel.Controls.Add(Layers);
            Layers.MouseUp += new MouseEventHandler(layers_MouseUp);
        }

        void layers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                LayerContextStrip.Show(Layers, e.X, e.Y);
        }

        private void AddLayerButton_Click(object sender, EventArgs e)
        {
            if (LayerAdded != null) LayerAdded(this, EventArgs.Empty);
            RemoveLayerButton.Enabled = true;
            Refresh();
        }

        private void RemoveLayerButton_Click(object sender, EventArgs e)
        {
            if (LayerRemoved != null) LayerRemoved(this, EventArgs.Empty);
            if (Layers.Items.Count == 1) RemoveLayerButton.Enabled = false;
            Refresh();
        }

        private void LayerContextStrip_Opening(object sender, CancelEventArgs e)
        {
            RemoveLayerMenuItem.Enabled = (Layers.Items.Count != 1);
        }

        private void RenameLayerMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new StringInputForm())
            {
                form.Input = Layers.SelectedItem.Text;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Layers.SelectedItem.Text = form.Input;
                }
                Refresh();
            }
        }

        private void LayerPanel_Resize(object sender, EventArgs e)
        {
            Layers.Width = LayersPanel.Width;
        }

        private void layerPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new LayerForm(Layers.SelectedItem.Layer))
            {
                form.ShowDialog();
                Refresh();
            }
        }
    }
}
