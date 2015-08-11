using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;

namespace SphereStudio.Components
{
    public partial class DebugPane : UserControl
    {
        private const string ValueBoxHint = "Select a variable from the list above to see what it contains.";

        private bool _is_evaluating = false;
        private string _last_var = null;
        private IReadOnlyDictionary<string, string> _variables;

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
            if (_last_var != null)
            {
                var toSelect = listVariables.FindItemWithText(_last_var);
                if (toSelect != null)
                    toSelect.Selected = true;
            }
        }

        private async Task DoEvaluate(string expression)
        {
            _is_evaluating = true;
            textEvalBox.Text = expression;
            textEvalBox.Enabled = false;
            buttonEval.Enabled = false;
            textValue.Text = "Evaluating...";
            var debug = PluginManager.IDE.Debugger;
            textValue.WordWrap = false;
            string value = await debug.Evaluate(expression);
            textValue.Text = string.Format("Expression:\r\n{0}\r\n\r\nValue:\r\n{1}",
                expression, value.Replace("\n", "\r\n"));
            textEvalBox.Text = "";
            textEvalBox.Enabled = true;
            buttonEval.Enabled = true;
            _is_evaluating = false;
        }

        private async void buttonEval_Click(object sender, EventArgs e)
        {
            await DoEvaluate(textEvalBox.Text);
        }

        private async void listVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            _last_var = listVariables.SelectedItems.Count > 0
                ? listVariables.SelectedItems[0].Text : null;
            if (listVariables.SelectedItems.Count > 0)
                await DoEvaluate(listVariables.SelectedItems[0].Text);
            else
            {
                textEvalBox.Text = "";
                textValue.Text = ValueBoxHint;
                textValue.WordWrap = true;
            }
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
            if (_is_evaluating) return;

            listVariables.SelectedItems.Clear();
            buttonEval.Enabled = !string.IsNullOrWhiteSpace(textEvalBox.Text);
        }
    }
}
