using System;
using System.Windows.Forms;
using Sphere_Editor.EditorComponents;
using Sphere.Core.SphereObjects;
using Sphere_Editor.SubEditors;

namespace Sphere_Editor.Forms
{
    public partial class ZoneForm : Form
    {
        public Zone Zone { get; private set; }
        ScriptEditor ScriptBox = new ScriptEditor();

        public ZoneForm()
        {
            InitializeComponent();
        }

        public ZoneForm(Zone zone)
        {
            Zone = zone;
            InitializeComponent();
            ScriptPanel.Controls.Add(ScriptBox);
            StepTextBox.Text = zone.NumSteps.ToString();
            LayerComboBox.Text = "Layer: " + zone.Layer;
            ScriptBox.Text = zone.Function;
            ScriptBox.Dock = DockStyle.Fill;
            PositionLabel.Text = "(X: " + zone.X + ", Y: " + zone.Y + ")";
        }

        public void AddString(string text)
        {
            LayerComboBox.Items.Add(LayerComboBox.Items.Count + ". " + text);
        }

        public int SelectedIndex
        {
            set { LayerComboBox.SelectedIndex = value; }
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            Zone.NumSteps = Convert.ToInt16(StepTextBox.Text);
            Zone.Function = ScriptBox.Text;
        }

        private void LayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zone.Layer = (short)LayerComboBox.SelectedIndex;
        }
      
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }
    }
}
