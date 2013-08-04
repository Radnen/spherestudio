using System;
using System.ComponentModel;
using System.Windows.Forms;
using Sphere.Core.Editor;
using MapEditorPlugin.Forms;

namespace MapEditorPlugin.Components
{
    public partial class LayerPanel : UserControl
    {
        private LayerControl layers = new LayerControl();
        public event EventHandler LayerAdded, LayerRemoved;

        public LayerPanel()
        {
            layers.Type = "MapLayer";
            layers.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            InitializeComponent();
            layers.Width = LayersPanel.Width;
            LayersPanel.Controls.Add(layers);
            layers.MouseUp += new MouseEventHandler(layers_MouseUp);
        }

        void layers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                LayerContextStrip.Show(this.layers, e.X, e.Y);
        }

        public LayerControl Layers
        {
            get { return layers; }
            set { layers = value; }
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
            if (layers.Items.Count == 1) RemoveLayerButton.Enabled = false;
            Refresh();
        }

        private void LayerContextStrip_Opening(object sender, CancelEventArgs e)
        {
            RemoveLayerMenuItem.Enabled = (layers.Items.Count != 1);
        }

        private void RenameLayerMenuItem_Click(object sender, EventArgs e)
        {
            using (StringInputForm form = new StringInputForm())
            {
                form.Input = layers.SelectedItem.Text;
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
    }
}
