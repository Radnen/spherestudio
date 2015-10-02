using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using SphereStudio.UI;

namespace SphereStudio.UI
{
    public partial class SettingsCenter : Form
    {
        private List<ISettingsPage> _applyList = new List<ISettingsPage>();
        private Control _currentPage = null;

        public SettingsCenter()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            string[] pageNames = PluginManager.GetPluginNames<ISettingsPage>();
            foreach (string name in pageNames)
            {
                var page = PluginManager.GetPlugin<ISettingsPage>(name);
                TreeNode node = new TreeNode(name) { Tag = page };
                PageTree.Nodes.Add(node);
            }
            base.OnLoad(e);
        }

        private void PageTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ISettingsPage page = e.Node.Tag as ISettingsPage;
            if (!_applyList.Contains(page))
                _applyList.Add(page);
            page.Control.Dock = DockStyle.Fill;
            SplitBox.Panel2.Controls.Add(page.Control);
            if (_currentPage != null)
                _currentPage.Hide();
            page.Control.Show();
            _currentPage = page.Control;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            foreach (ISettingsPage page in _applyList)
                page.Apply();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool canClose = true;
            foreach (ISettingsPage page in _applyList)
                canClose &= page.Apply();
            if (!canClose)
                DialogResult = DialogResult.None;
        }
    }
}
