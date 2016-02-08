using Sphere.Core;
using Sphere.Plugins.EditShims;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace SphereStudio.Plugins.Forms
{
    partial class ZoneForm : Form
    {
        public Zone Zone { get; private set; }
        readonly ScriptEditShim _scriptBox = new ScriptEditShim();

        public ZoneForm()
        {
            InitializeComponent();
        }

        public ZoneForm(Zone zone)
        {
            Zone = zone;
            InitializeComponent();
            ScriptPanel.Controls.Add(_scriptBox);
            StepTextBox.Text = zone.NumSteps.ToString(CultureInfo.InvariantCulture);
            LayerComboBox.Text = $"Layer: {zone.Layer}";
            _scriptBox.Text = zone.Function;
            _scriptBox.Dock = DockStyle.Fill;
            PositionLabel.Text = $"(X: {zone.X}, Y: {zone.Y})";
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
            Zone.Function = _scriptBox.Text;
        }

        private void LayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zone.Layer = (short)LayerComboBox.SelectedIndex;
        }
      
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }
    }
}
