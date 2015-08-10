using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;

namespace SphereStudio.Components
{
    public partial class DebugPane : UserControl
    {
        private const string ValueBoxHint = "Select a variable from the list above to see what it contains.";

        string _lastVar = null;
        IReadOnlyDictionary<string, string> _variables;

        public DebugPane()
        {
            InitializeComponent();

            textValue.Text = ValueBoxHint;
            textValue.WordWrap = true;
        }

        public void Clear()
        {
            listVariables.Items.Clear();
            textEvalBox.Text = "";
            textValue.Text = ValueBoxHint;
            textValue.WordWrap = true;
        }

        public void SetVariables(IReadOnlyDictionary<string, string> variables)
        {
            _variables = variables;
            Clear();
            foreach (var k in _variables.Keys)
            {
                var item = listVariables.Items.Add(k, 0);
                item.SubItems.Add(_variables[k]);
            }
            if (_lastVar != null)
            {
                var toSelect = listVariables.FindItemWithText(_lastVar);
                if (toSelect != null)
                    toSelect.Selected = true;
            }
        }

        private async void listVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lastVar = listVariables.SelectedItems.Count > 0
                ? listVariables.SelectedItems[0].Text : null;
            if (listVariables.SelectedItems.Count > 0) {
                string name = listVariables.SelectedItems[0].Text;
                string value = (await PluginManager.IDE.Debugger.Evaluate(name)).Replace("\n", "\r\n");
                string sep = value.Contains("\r\n") ? "\r\n" : " ";
                textValue.WordWrap = false;
                textValue.Text = string.Format("var {0} ={1}{2};", name, sep, value);
                textEvalBox.Text = "";
            }
            else
            {
                textEvalBox.Text = "";
                textValue.Text = ValueBoxHint;
                textValue.WordWrap = true;
            }
        }

        private async void buttonEval_Click(object sender, EventArgs e)
        {
            buttonEval.Enabled = false;
            textValue.Text = "Evaluating...";
            var debug = PluginManager.IDE.Debugger;
            var expression = textEvalBox.Text;
            listVariables.SelectedItems.Clear();
            textEvalBox.Text = "";
            textValue.WordWrap = false;
            textValue.Text = string.Format("Expression:\r\n{0}\r\n\r\nResult:\r\n{1}",
                expression,
                (await debug.Evaluate(expression)).Replace("\n", "\r\n"));
            buttonEval.Enabled = true;
        }

        private void textEvalBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.None)
            {
                buttonEval.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textEvalBox_TextChanged(object sender, EventArgs e)
        {
            buttonEval.Enabled = !string.IsNullOrWhiteSpace(textEvalBox.Text);
        }
    }
}
