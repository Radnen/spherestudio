using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Ide.Forms
{
    partial class PreferencesForm : Form, IStyleAware
    {
        private List<ISettingsPage> _applyList = new List<ISettingsPage>();
        private Control _currentPage = null;

        public PreferencesForm()
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsUIElement(splitterBox.Panel1);
            style.AsUIElement(splitterBox.Panel2);
            style.AsHeading(header);
            style.AsHeading(footer);
            style.AsTextView(pageList);
            style.AsAccent(okButton);
            style.AsAccent(cancelButton);
            style.AsAccent(applyButton);
        }

        protected override void OnLoad(EventArgs e)
        {
            string[] pageNames = PluginManager.GetNames<ISettingsPage>();
            foreach (string name in pageNames)
            {
                var page = PluginManager.Get<ISettingsPage>(name);
                TreeNode node = new TreeNode(name) { Tag = page };
                pageList.Nodes.Add(node);
            }
            base.OnLoad(e);
        }

        private void PageTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ISettingsPage page = e.Node.Tag as ISettingsPage;
            if (!_applyList.Contains(page))
                _applyList.Add(page);
            page.Control.Dock = DockStyle.Fill;
            splitterBox.Panel2.Controls.Add(page.Control);
            if (_currentPage != null)
                _currentPage.Hide();
            page.Control.Show();
            _currentPage = page.Control;
        }

        private void PageTree_MouseMove(object sender, MouseEventArgs e)
        {
            var ht = pageList.HitTest(e.Location);
            pageList.Cursor = ht.Node != null && ht.Node.Bounds.Contains(e.Location)
                ? Cursors.Hand : Cursors.Default;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool canClose = true;
            foreach (ISettingsPage page in _applyList)
                canClose &= page.Apply();
            if (!canClose)
                DialogResult = DialogResult.None;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            foreach (ISettingsPage page in _applyList)
                page.Apply();
        }
    }
}
