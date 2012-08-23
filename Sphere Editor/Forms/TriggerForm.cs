using System;
using System.Windows.Forms;
using Sphere_Editor.SphereObjects;
using Sphere_Editor.SubEditors;

namespace Sphere_Editor.Forms
{
    public partial class TriggerForm : Form
    {
        public Entity Trigger { get; private set; }
        ScriptEditor ScriptBox = new ScriptEditor();

        public TriggerForm()
        {
            InitializeComponent();
            Trigger = new Entity();
            Trigger.Type = 2;
        }

        public TriggerForm(Entity trigger)
        {
            this.Trigger = trigger;
            InitializeComponent();
            LayerComboBox.Text = "Layer: " + trigger.Layer;
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
            ScriptBox.Dock = DockStyle.Fill;
            FunctionPanel.Controls.Add(ScriptBox);
            ScriptBox.Text = Trigger.Function;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Trigger.Function = ScriptBox.Text;
        }

        private void LayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Trigger.Layer = (short)LayerComboBox.SelectedIndex;
        }
    }
}
