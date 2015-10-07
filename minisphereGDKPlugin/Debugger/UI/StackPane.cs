using System;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Views;

namespace minisphere.GDK.Debugger.UI
{
    partial class StackPane : DebugPane
    {
        public StackPane() :
            base(Properties.Resources.CallStack)
        {
            InitializeComponent();
            Enabled = false;
        }

        public DebugSession CurrentSession { get; set; }

        public void Clear()
        {
            listStack.Items.Clear();
        }

        public void UpdateStack(Tuple<string, string, int>[] stack)
        {
            listStack.BeginUpdate();
            listStack.Items.Clear();
            foreach (var entry in stack)
            {
                ListViewItem item = new ListViewItem(entry.Item1 != ""
                    ? string.Format("{0}()", entry.Item1)
                    : "function()");
                item.SubItems.Add(entry.Item2);
                item.SubItems.Add(entry.Item3.ToString());
                listStack.Items.Add(item);
            }
            listStack.EndUpdate();
        }

        private void listStack_DoubleClick(object sender, EventArgs e)
        {
            if (listStack.SelectedItems.Count > 0)
            {
                ListViewItem item = listStack.SelectedItems[0];
                string filename = CurrentSession.ResolvePath(item.SubItems[1].Text);
                int lineNumber = int.Parse(item.SubItems[2].Text);
                ScriptView view = PluginManager.IDE.OpenDocument(filename) as ScriptView;
                if (view != null)
                {
                    view.GoToLine(lineNumber);
                }
                else
                {
                    SystemSounds.Asterisk.Play();
                }
            }
        }
    }
}
