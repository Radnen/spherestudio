using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Views;

namespace minisphere.Remote.Components
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
                    : "anonymous");
                item.SubItems.Add(string.Format("{0}:{1}", entry.Item2, entry.Item3));
                listStack.Items.Add(item);
            }
            listStack.EndUpdate();
        }

        private void listStack_DoubleClick(object sender, EventArgs e)
        {
            if (listStack.SelectedItems.Count > 0)
            {
                ListViewItem item = listStack.SelectedItems[0];
                Match match = new Regex("^(.*):(.*)$").Match(item.SubItems[1].Text);
                string filename = session.ResolvePath(match.Groups[1].Value);
                int lineNumber = int.Parse(match.Groups[2].Value);
                ScriptView view = PluginManager.IDE.OpenDocument(filename) as ScriptView;
                if (view != null)
                {
                    view.GoToLine(lineNumber);
                }
            }
        }
    }
}
