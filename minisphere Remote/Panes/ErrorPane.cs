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

        public void Add(string value, bool isFatal, string filename, int line)
        {
            ListViewItem item = listErrors.Items.Insert(0, value, isFatal ? 1 : 0);
            item.SubItems.Add(filename);
            item.SubItems.Add(line.ToString());
        }
    }
}
