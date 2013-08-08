using System;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Plugins.EditShims;
using Sphere_Editor.SubEditors;

namespace Sphere_Editor.Forms
{
    public partial class TriggerForm : Form
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

        public void AddString(string text)
        {
            LayerComboBox.Items.Add(LayerComboBox.Items.Count + ". " + text);
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
