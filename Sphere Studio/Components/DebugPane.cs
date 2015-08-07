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
        IReadOnlyDictionary<string, string> _variables;

        public DebugPane()
        {
            InitializeComponent();

            textValue.Text = "Select a variable to see its value.";
        }

        public void Clear()
        {
            listVariables.Items.Clear();
        }

        public void SetVariables(IReadOnlyDictionary<string, string> variables)
        {
            _variables = variables;
            listVariables.Items.Clear();
            foreach (var k in _variables.Keys)
            {
                var item = listVariables.Items.Add(k, 0);
                item.SubItems.Add(_variables[k]);
            }
        }

        private void listVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listVariables.SelectedItems.Count > 0) {
                string name = listVariables.SelectedItems[0].Text;
                string value = PluginManager.IDE.Debugger.Evaluate(name)
                    .Replace("\n", "\r\n");
                string sep = value.Contains("\r\n") ? "\r\n" : " ";
                textValue.Text = string.Format("var {0} ={1}{2};", name, sep, value);
            }
            else
            {
                textValue.Text = "Select a variable to see its value.";
            }
        }
    }
}
