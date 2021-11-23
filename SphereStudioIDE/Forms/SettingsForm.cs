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
    partial class SettingsForm : Form, IStyleAware
    {
        private List<ISettingsPage> _applyList = new List<ISettingsPage>();
        private Control _currentPage = null;

        public SettingsForm()
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsHeading(header);
            style.AsHeading(footer);
            style.AsAccent(tabControl);
            style.AsAccent(okButton);
            style.AsAccent(cancelButton);
            style.AsAccent(applyButton);
        }

        protected override void OnLoad(EventArgs e)
        {
            string[] pageNames = PluginManager.GetNames<ISettingsPage>();
            foreach (string name in pageNames)
            {
                var plugin = PluginManager.Get<ISettingsPage>(name);
                var page = new TabPage(name) { Tag = plugin };
                tabControl.TabPages.Add(page);
            }
            loadSettingsPage();
            base.OnLoad(e);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool canClose = true;
            foreach (ISettingsPage page in _applyList)
                canClose &= page.Apply();
            if (!canClose)
                DialogResult = DialogResult.None;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            foreach (ISettingsPage page in _applyList)
                page.Apply();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSettingsPage();
        }

        private void loadSettingsPage()
        {
            var plugin = tabControl.SelectedTab.Tag as ISettingsPage;
            if (!_applyList.Contains(plugin))
                _applyList.Add(plugin);
            plugin.Control.Dock = DockStyle.Fill;
            tabControl.SelectedTab.Controls.Add(plugin.Control);
            if (_currentPage != null)
                _currentPage.Hide();
            plugin.Control.Show();
            _currentPage = plugin.Control;
        }
    }
}
