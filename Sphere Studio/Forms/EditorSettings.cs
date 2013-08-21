﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Sphere.Core.Editor;
using Sphere.Core.Settings;
using Sphere.Plugins;

namespace SphereStudio.Forms
{
    internal partial class EditorSettings : Form, IStyleable
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
            set { PathListBox.Items.Clear(); PathListBox.Items.AddRange(value); }
        }

        public string Style
        {
            get { return StyleComboBox.Text; }
            set { StyleComboBox.Text = value; }
        }

        public bool UseScriptUpdate
        {
            get { return ItemCheckBox.GetItemChecked(0); }
            set { ItemCheckBox.SetItemChecked(0, value); }
        }

        public bool AutoStart
        {
            get { return ItemCheckBox.GetItemChecked(1); }
            set { ItemCheckBox.SetItemChecked(1, value); }
        }

        public bool UseStartPage
        {
            get { return ItemCheckBox.GetItemChecked(2); }
            set { ItemCheckBox.SetItemChecked(2, value); }
        }

        private bool _updatePlugins = false;
        #endregion

        public EditorSettings(SphereSettings settings)
        {
            InitializeComponent();
            foreach (string name in from key in StyleSettings.Styles.Keys orderby key select key)
            {
                StyleComboBox.Items.Add(name);
            }
            SetValues(settings);
        }

        private void SetValues(SphereSettings settings)
        {
            SpherePath = settings.SpherePath;
            ConfigPath = settings.ConfigPath;
            GamePaths = settings.GetArray("games_path");
            AutoStart = settings.AutoOpen;
            UseScriptUpdate = settings.UseScriptUpdate;
            UseStartPage = settings.UseStartPage;
            Style = settings.Style.ToString();
            UpdateStyle();
        }

        /// <summary>
        /// Gets a copy of the data put into this form.
        /// </summary>
        /// <returns>A GenSettings object representing the editor.</returns>
        public SphereSettings GetSettings()
        {
            SphereSettings settings = new SphereSettings();
            settings.AutoOpen = AutoStart;
            settings.SpherePath = SpherePath;
            settings.ConfigPath = ConfigPath;
            settings.UseScriptUpdate = UseScriptUpdate;
            settings.UseStartPage = UseStartPage;
            settings.Style = Style;
            settings.StoreArray("games_path", GamePaths);

            List<string> activated = new List<string>();
            foreach (var item in Global.Plugins)
            {
                if (item.Value.Enabled) activated.Add(item.Key);
            }

            settings.StoreArray("plugins", activated);
            return settings;
        }

        private void SpherePathButton_Click(object sender, EventArgs e)
        {
            using (FileDialog diag = new OpenFileDialog())
            {
                diag.Filter = "Executable Files|*.exe";
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.GetDirectoryName(diag.FileName);
                    if (File.Exists(path + "\\engine.exe"))
                        SpherePathBox.Text = path + "\\engine.exe";
                    if (File.Exists(path + "\\config.exe"))
                        ConfigPathBox.Text = path + "\\config.exe";
                    if (Directory.Exists(path + "\\games"))
                        PathListBox.Items.Add(path + "\\games");
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            FolderBrowser.Description = "Choose a custom Sphere games location.\n" +
                                        "Usually Sphere/games/ but you can use your own.";
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                PathListBox.Items.Add(FolderBrowser.SelectedPath);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            PathListBox.Items.RemoveAt(PathListBox.SelectedIndex);
            RemoveButton.Enabled = PathListBox.Items.Count > 0 && PathListBox.SelectedIndex > 0;
        }

        private void PathListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveButton.Enabled = true;
        }

        private void EditorSettings_Load(object sender, EventArgs e)
        {
            _updatePlugins = false;
            foreach (KeyValuePair<string, PluginWrapper> pair in Global.Plugins)
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

            string[] files = Directory.GetFiles(Application.StartupPath, "*.preset");
            foreach (string s in files)
            {
                PresetListBox.Items.Add(Path.GetFileNameWithoutExtension(s));
            }
        }

        private void PluginList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!_updatePlugins) return;
            ListViewItem item = PluginList.Items[e.Index];
            if (e.NewValue == CheckState.Checked) Global.Plugins[(string)item.Tag].Activate();
            else Global.Plugins[(string)item.Tag].Deactivate();
        }

        private void PresetListBox_DoubleClick(object sender, EventArgs e)
        {
            UsePresetButton.PerformClick();
        }
        
        private void PresetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemovePresetButton.Enabled = true;
            UsePresetButton.Enabled = true;
        }

        private void RemovePresetButton_Click(object sender, EventArgs e)
        {
            string path = (string)PresetListBox.SelectedItem;
            if (File.Exists(path)) File.Delete(path);
            PresetListBox.Items.RemoveAt(PresetListBox.SelectedIndex);
            RemovePresetButton.Enabled = PresetListBox.Items.Count > 0 && PresetListBox.SelectedIndex > 0;
        }

        private void SavePresetButton_Click(object sender, EventArgs e)
        {
            using (StringInputForm form = new StringInputForm())
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    GenSettings old = Global.CurrentEditor.Clone();
                    Global.CurrentEditor.SetSettings(GetSettings());

                    string file = form.Input + ".preset";
                    Global.CurrentEditor.SaveSettings(file);
                    Global.CurrentEditor.SetSettings(old);

                    PresetListBox.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
        }

        private void UsePresetButton_Click(object sender, EventArgs e)
        {
            SphereSettings settings = new SphereSettings();
            settings.LoadSettings(((string)PresetListBox.SelectedItem) + ".preset");
            SetValues(settings);
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            var index = PathListBox.SelectedIndex;

            if (index + 1 < PathListBox.Items.Count)
            {
                var item = PathListBox.Items[index];
                PathListBox.Items.RemoveAt(index);
                PathListBox.Items.Insert(index + 1, item);
                PathListBox.SelectedIndex = index + 1;
            }
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            var index = PathListBox.SelectedIndex;

            if (index > 0)
            {
                var item = PathListBox.Items[index];
                PathListBox.Items.RemoveAt(index);
                PathListBox.Items.Insert(index - 1, item);
                PathListBox.SelectedIndex = index - 1;
            }
        }

        public void UpdateStyle()
        {
            StyleSettings.ApplyStyle(ButtonPanel);
            StyleSettings.ApplyStyle(okButton);
            StyleSettings.ApplyStyle(cancelButton);
        }
    }
}
