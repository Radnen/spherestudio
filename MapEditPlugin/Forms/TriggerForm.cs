using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Plugins.EditShims;
using SphereStudio.Plugins.Components;

namespace SphereStudio.Plugins.Forms
{
    partial class TriggerForm : Form
    {
        public Entity Trigger { get; private set; }
        readonly ScriptEditShim _scriptBox = new ScriptEditShim();

        public TriggerForm()
        {
            InitializeComponent();
            Trigger = new Entity(Entity.EntityType.Trigger);
        }

        public TriggerForm(Entity trigger)
        {
            Trigger = trigger;
            InitializeComponent();
            LayerComboBox.Text = @"Layer: " + trigger.Layer;
        }

        public int SelectedIndex
        {
            set { LayerComboBox.SelectedIndex = value; Trigger.Layer = (short)value; }
        }

        public void AddLayers(List<Layer> layers)
        {
            LayerComboBox.BeginUpdate();
            foreach (Layer layer in layers)
            {
                LayerComboBox.Items.Add(LayerComboBox.Items.Count + ": " + layer.Name);
            }
            LayerComboBox.EndUpdate();
        }

        private void TriggerForm_Load(object sender, EventArgs e)
        {
            _scriptBox.Dock = DockStyle.Fill;
            FunctionPanel.Controls.Add(_scriptBox);
            _scriptBox.Text = Trigger.Function;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Trigger.Function = _scriptBox.Text;
        }

        private void LayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Trigger.Layer = (short)LayerComboBox.SelectedIndex;
        }
    }
}
