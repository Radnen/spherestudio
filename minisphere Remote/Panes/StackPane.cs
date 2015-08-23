using System;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Views;

namespace minisphere.Remote.Panes
{
    partial class StackPane : DebugPane
    {
        private DebugSession session;

        public StackPane(DebugSession session):
            base("Call Stack", Properties.Resources.CallStack)
        {
            InitializeComponent();
            this.session = session;
        }

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
                    : "(anonymous)");
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
                string filename = session.ResolvePath(item.SubItems[1].Text);
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
