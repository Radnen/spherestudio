﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SphereStudio.Ide;
using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Ide.BuiltIns
{
    [ToolboxItem(false)]
    partial class IdeSettingsPage : UserControl, ISettingsPage, IStyleAware
    {
        public IdeSettingsPage()
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);
        }

        public Control Control { get => this; }

        public bool Apply()
        {
            string[] paths = new string[PathList.Items.Count];
            PathList.Items.CopyTo(paths, 0);

            Core.Settings.StyleName = StylePicker.Text;
            Core.Settings.UseStartPage = UseStartPage.Checked;
            Core.Settings.AutoOpenLastProject = OpenLastProject.Checked;
            Core.Settings.UseScriptHeaders = UseScriptHeader.Checked;
            Core.Settings.ProjectPaths = paths;
            Core.Settings.Apply();
            return true;
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(tabPage1);
            style.AsUIElement(tabPage2);
            style.AsUIElement(tabPage3);
            style.AsTextView(StylePicker);
            style.AsTextView(ScriptHeader);
            style.AsTextView(PathList);
            style.AsUIElement(UseStartPage);
            style.AsUIElement(OpenLastProject);
            style.AsUIElement(UseScriptHeader);
            style.AsAccent(AddPathButton);
            style.AsAccent(RemovePathButton);
            style.AsAccent(UpButton);
            style.AsAccent(DownButton);
        }

        protected override void OnLoad(EventArgs e)
        {
            StylePicker.Items.Clear();
            PathList.Items.Clear();

            // populate lists, combo boxes, etc.
            var styleNames = from pluginName in PluginManager.GetNames<IStyleProvider>()
                             let plugin = PluginManager.Get<IStyleProvider>(pluginName)
                             from style in plugin.Styles
                             orderby pluginName
                             select pluginName + ": " + style.Name;
            foreach (var name in styleNames)
                StylePicker.Items.Add(name);
            StylePicker.SelectedIndex = 0;

            // fill in current settings
            StylePicker.Text = Core.Settings.StyleName;
            UseStartPage.Checked = Core.Settings.UseStartPage;
            OpenLastProject.Checked = Core.Settings.AutoOpenLastProject;
            UseScriptHeader.Checked = Core.Settings.UseScriptHeaders;
            PathList.Items.AddRange(Core.Settings.ProjectPaths);

            RemovePathButton.Enabled = PathList.Items.Count > 0 && PathList.SelectedIndex >= 0;
            UpButton.Enabled = DownButton.Enabled = RemovePathButton.Enabled;
            base.OnLoad(e);
        }

        private void PathList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemovePathButton.Enabled = PathList.Items.Count > 0 && PathList.SelectedIndex >= 0;
            UpButton.Enabled = DownButton.Enabled = RemovePathButton.Enabled;
        }

        private void AddPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Select where you want Sphere Studio to search for projects.";
            browser.ShowNewFolderButton = true;
            if (browser.ShowDialog() == DialogResult.OK)
            {
                int idx = PathList.Items.Add(browser.SelectedPath);
                PathList.SelectedIndex = idx;
            }
        }

        private void RemovePathButton_Click(object sender, EventArgs e)
        {
            PathList.Items.RemoveAt(PathList.SelectedIndex);
            RemovePathButton.Enabled = PathList.Items.Count > 0 && PathList.SelectedIndex >= 0;
            UpButton.Enabled = DownButton.Enabled = RemovePathButton.Enabled;
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            var idx = PathList.SelectedIndex;
            if (idx - 1 >= 0)
            {
                var item = PathList.Items[idx];
                PathList.Items.RemoveAt(idx);
                PathList.Items.Insert(idx - 1, item);
                PathList.SelectedIndex = idx - 1;
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            var idx = PathList.SelectedIndex;
            if (idx + 1 < PathList.Items.Count)
            {
                var item = PathList.Items[idx];
                PathList.Items.RemoveAt(idx);
                PathList.Items.Insert(idx + 1, item);
                PathList.SelectedIndex = idx + 1;
            }
        }
    }
}
