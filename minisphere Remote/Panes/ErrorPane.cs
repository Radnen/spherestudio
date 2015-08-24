using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins.Interfaces;

namespace minisphere.Remote.Panes
{
    partial class ErrorPane : DebugPane
    {
        public ErrorPane(DebugSession session)
            : base("Errors", null, DockHint.Bottom)
        {
            InitializeComponent();
        }

        public void Add(string value, bool isFatal, string func, string filename, int line)
        {
            if (listErrors.Items.Count > 0)
            {
                listErrors.Items[0].BackColor = listErrors.BackColor;
                listErrors.Items[0].ForeColor = listErrors.ForeColor;
            }
            ListViewItem item = listErrors.Items.Insert(0, value, isFatal ? 1 : 0);
            item.SubItems.Add(string.Format("{0}()", func != "" ? func : "function"));
            item.SubItems.Add(filename);
            item.SubItems.Add(line.ToString());
            if (isFatal)
            {
                item.BackColor = Color.DarkRed;
                item.ForeColor = Color.Yellow;
            }
        }

        public void ClearHighlight()
        {
            if (listErrors.Items.Count > 0)
            {
                listErrors.Items[0].BackColor = listErrors.BackColor;
                listErrors.Items[0].ForeColor = listErrors.ForeColor;
            }
        }
    }
}
