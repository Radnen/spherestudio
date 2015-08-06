using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SphereStudio.Components
{
    public partial class DebugPane : UserControl
    {
        public DebugPane()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            listVariables.Items.Clear();
        }

        public void SetVariables(IReadOnlyDictionary<string, string> variables)
        {
            listVariables.Items.Clear();
            foreach (var k in variables.Keys)
            {
                var item = listVariables.Items.Add(k);
                item.SubItems.Add(variables[k]);
            }
        }
    }
}
