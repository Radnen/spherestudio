using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Sphere_Editor.Utility;

namespace Sphere_Editor.Settings
{
    public partial class EditorSettings : Form
    {
        #region getters and setters
        public string SpherePath
        {
            get { return SpherePathBox.Text; }
            set { SpherePathBox.Text = value; }
        }

        public string ConfigPath
        {
            get { return ConfigPathBox.Text; }
            set { ConfigPathBox.Text = value; }
        }

        public string[] GamePaths
        {
            get
            {
                string[] strings = new string[PathListBox.Items.Count];
                PathListBox.Items.CopyTo(strings, 0);
                return strings;
            }
            set { PathListBox.Items.AddRange(value); }
        }

        public string LabelFont
        {
            get { return FontComboBox.Text; }
            set { FontComboBox.Text = value; }
        }

        public bool UseDockForm
        {
            get { return !ItemCheckBox.GetItemChecked(0); }
            set { ItemCheckBox.SetItemChecked(0, !value); }
        }

        public bool AutoStart
        {
            get { return ItemCheckBox.GetItemChecked(2); }
            set { ItemCheckBox.SetItemChecked(2, value); }
        }

        public bool UseScriptUpdate
        {
            get { return ItemCheckBox.GetItemChecked(1); }
            set { ItemCheckBox.SetItemChecked(1, value); }
        }

        private bool _updatePlugins = false;
        #endregion

        public EditorSettings(SphereSettings settings)
        {
            InitializeComponent();
            SpherePath = settings.SpherePath;
            ConfigPath = settings.ConfigPath;
            GamePaths = settings.GetGamePaths();
            UseDockForm = settings.UseDockForm;
            AutoStart = settings.AutoOpen;
            UseScriptUpdate = settings.UseScriptUpdate;
            LabelFont = settings.LabelFont;
        }

        private void SpherePathButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                string path = FolderBrowser.SelectedPath;
                if (File.Exists(path + "\\engine.exe"))
                    SpherePathBox.Text = path + "\\engine.exe";
                if (File.Exists(path + "\\config.exe"))
                    ConfigPathBox.Text = path + "\\config.exe";
                if (Directory.Exists(path + "\\games"))
                    PathListBox.Items.Add(path + "\\games");
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                PathListBox.Items.Add(FolderBrowser.SelectedPath);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            PathListBox.Items.RemoveAt(PathListBox.SelectedIndex);
            if (PathListBox.Items.Count == 0) RemoveButton.Enabled = false;
        }

        private void PathListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveButton.Enabled = true;
        }

        private void EditorSettings_Load(object sender, EventArgs e)
        {
            _updatePlugins = false;
            foreach (KeyValuePair<string, PluginWrapper> pair in Global.plugins)
            {
                ListViewItem item = new ListViewItem();
                item.Text = pair.Value.Plugin.Name;
                item.SubItems.Add(pair.Value.Plugin.Author);
                item.SubItems.Add(pair.Value.Plugin.Version);
                item.SubItems.Add(pair.Value.Plugin.Description);
                item.Tag = pair.Key;
                item.Checked = pair.Value.Enabled;
                PluginList.Items.Add(item);
            }
            _updatePlugins = true;
        }

        private void PluginList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!_updatePlugins) return;
            ListViewItem item = PluginList.Items[e.Index];
            if (e.NewValue == CheckState.Checked) Global.plugins[(string)item.Tag].Activate();
            else Global.plugins[(string)item.Tag].Deactivate();
        }
    }
}
