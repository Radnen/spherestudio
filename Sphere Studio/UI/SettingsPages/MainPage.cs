using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sphere.Core.Editor;
using Sphere.Plugins.Interfaces;
using SphereStudio.UI;

namespace SphereStudio.UI.SettingsPages
{
    public partial class MainPage : UserControl, ISettingsPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public Control Control { get { return this; } }

        public bool Apply()
        {
            string[] paths = new string[PathList.Items.Count];
            PathList.Items.CopyTo(paths, 0);

            Global.Settings.UIStyle = StylePicker.Text;
            Global.Settings.UseStartPage = UseStartPage.Checked;
            Global.Settings.AutoOpenLastProject = OpenLastProject.Checked;
            Global.Settings.AutoHideBuild = AutoHideBuild.Checked;
            Global.Settings.UseScriptHeaders = UseScriptHeader.Checked;
            Global.Settings.ProjectPaths = paths;
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            StylePicker.Items.Clear();
            PathList.Items.Clear();

            // populate lists, combo boxes, etc.
            foreach (var item in StyleSettings.Styles)
                StylePicker.Items.Add(item.Key);
            StylePicker.SelectedIndex = 0;

            // fill in current settings
            StylePicker.Text = Global.Settings.UIStyle;
            UseStartPage.Checked = Global.Settings.UseStartPage;
            OpenLastProject.Checked = Global.Settings.AutoOpenLastProject;
            AutoHideBuild.Checked = Global.Settings.AutoHideBuild;
            UseScriptHeader.Checked = Global.Settings.UseScriptHeaders;
            PathList.Items.AddRange(Global.Settings.ProjectPaths);

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
