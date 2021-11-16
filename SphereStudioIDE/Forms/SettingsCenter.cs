﻿using System;
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
    partial class SettingsCenter : Form, IStyleAware
    {
        private List<ISettingsPage> _applyList = new List<ISettingsPage>();
        private Control _currentPage = null;

        public SettingsCenter()
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsUIElement(SplitBox);
            style.AsUIElement(ButtonBar);
            style.AsTextView(PageTree);
            style.AsAccent(OKButton);
            style.AsAccent(CloseButton);
            style.AsAccent(ApplyButton);
        }

        protected override void OnLoad(EventArgs e)
        {
            string[] pageNames = PluginManager.GetNames<ISettingsPage>();
            foreach (string name in pageNames)
            {
                var page = PluginManager.Get<ISettingsPage>(name);
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

        private void PageTree_MouseMove(object sender, MouseEventArgs e)
        {
            var ht = PageTree.HitTest(e.Location);
            PageTree.Cursor = ht.Node != null && ht.Node.Bounds.Contains(e.Location)
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
