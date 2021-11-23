using System;
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
    partial class MainSettingsPage : UserControl, ISettingsPage, IStyleAware
    {
        public MainSettingsPage()
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);
        }

        public Control Control { get => this; }

        public bool Apply()
        {
            string[] paths = new string[dirsListBox.Items.Count];
            dirsListBox.Items.CopyTo(paths, 0);

            Core.Settings.StyleName = styleDropDown.Text;
            Core.Settings.UseStartPage = useStartPageButton.Checked;
            Core.Settings.AutoOpenLastProject = rememberProjectButton.Checked;
            Core.Settings.ProjectPaths = paths;
            Core.Settings.Apply();
            return true;
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsHeading(styleHeading);
            style.AsHeading(miscHeading);
            style.AsHeading(dirsHeading);
            style.AsAccent(stylePanel);
            style.AsAccent(miscPanel);
            style.AsAccent(dirsPanel);
            style.AsTextView(styleDropDown);
            style.AsTextView(dirsListBox);
            style.AsAccent(useStartPageButton);
            style.AsAccent(rememberProjectButton);
            style.AsAccent(addDirButton);
            style.AsAccent(removeDirButton);
            style.AsAccent(moveDirUpButton);
            style.AsAccent(moveDirDownButton);
        }

        protected override void OnLoad(EventArgs e)
        {
            styleDropDown.Items.Clear();
            dirsListBox.Items.Clear();

            // populate lists, combo boxes, etc.
            var styleNames = from pluginName in PluginManager.GetNames<IStyleProvider>()
                             let plugin = PluginManager.Get<IStyleProvider>(pluginName)
                             from style in plugin.Styles
                             orderby pluginName
                             select pluginName + ": " + style.Name;
            foreach (var name in styleNames)
                styleDropDown.Items.Add(name);
            styleDropDown.SelectedIndex = 0;

            // fill in current settings
            styleDropDown.Text = Core.Settings.StyleName;
            useStartPageButton.Checked = Core.Settings.UseStartPage;
            rememberProjectButton.Checked = Core.Settings.AutoOpenLastProject;
            dirsListBox.Items.AddRange(Core.Settings.ProjectPaths);

            removeDirButton.Enabled = dirsListBox.Items.Count > 0 && dirsListBox.SelectedIndex >= 0;
            moveDirUpButton.Enabled = moveDirDownButton.Enabled = removeDirButton.Enabled;
            base.OnLoad(e);
        }

        private void PathList_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeDirButton.Enabled = dirsListBox.Items.Count > 0 && dirsListBox.SelectedIndex >= 0;
            moveDirUpButton.Enabled = moveDirDownButton.Enabled = removeDirButton.Enabled;
        }

        private void AddPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Select where you want Sphere Studio to search for projects.";
            browser.ShowNewFolderButton = true;
            if (browser.ShowDialog() == DialogResult.OK)
            {
                int idx = dirsListBox.Items.Add(browser.SelectedPath);
                dirsListBox.SelectedIndex = idx;
            }
        }

        private void RemovePathButton_Click(object sender, EventArgs e)
        {
            dirsListBox.Items.RemoveAt(dirsListBox.SelectedIndex);
            removeDirButton.Enabled = dirsListBox.Items.Count > 0 && dirsListBox.SelectedIndex >= 0;
            moveDirUpButton.Enabled = moveDirDownButton.Enabled = removeDirButton.Enabled;
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            var idx = dirsListBox.SelectedIndex;
            if (idx - 1 >= 0)
            {
                var item = dirsListBox.Items[idx];
                dirsListBox.Items.RemoveAt(idx);
                dirsListBox.Items.Insert(idx - 1, item);
                dirsListBox.SelectedIndex = idx - 1;
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            var idx = dirsListBox.SelectedIndex;
            if (idx + 1 < dirsListBox.Items.Count)
            {
                var item = dirsListBox.Items[idx];
                dirsListBox.Items.RemoveAt(idx);
                dirsListBox.Items.Insert(idx + 1, item);
                dirsListBox.SelectedIndex = idx + 1;
            }
        }
    }
}
