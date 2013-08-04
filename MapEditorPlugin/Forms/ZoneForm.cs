using System;
using System.Globalization;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Core.Editor;
using MapEditorPlugin.Components;

namespace MapEditorPlugin.Forms
{
    public partial class ZoneForm : Form
    {
        public Zone Zone { get; private set; }
        readonly ScriptEditor _scriptBox = new ScriptEditor();

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
            LayerComboBox.Text = @"Layer: " + zone.Layer;
            _scriptBox.Text = zone.Function;
            _scriptBox.Dock = DockStyle.Fill;
            PositionLabel.Text = string.Format(@"(X: {0}, Y: {1})", zone.X, zone.Y);
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
            e.Handled = (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }
    }
}
