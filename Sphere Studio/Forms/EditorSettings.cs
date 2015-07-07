using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Sphere.Core.Editor;
using Sphere.Core.Settings;
using Sphere.Plugins;
using SphereStudio.Settings;

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

        public string Sphere64Path
        {
            get { return Sphere64PathBox.Text; }
            set { Sphere64PathBox.Text = value; }
        }

        public string DefaultEditor
        {
            get { return defEditorCombo.Text != "(none selected)" ? defEditorCombo.Text : ""; }
            set { defEditorCombo.Text = value; }
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

        public EditorSettings(CoreSettings settings)
        {
            InitializeComponent();

            foreach (var item in StyleSettings.Styles)
                StyleComboBox.Items.Add(item.Key);
            RefreshPlugins();
            
            FillValues(settings);
        }

        private void RefreshPlugins()
        {
            string lastWildcard = DefaultEditor;
            defEditorCombo.Items.Clear();
            defEditorCombo.Items.Add("(none selected)");
            defEditorCombo.SelectedIndex = 0;
            var wildcards = PluginManager.GetWildcards();
            foreach (var plugin in wildcards)
                defEditorCombo.Items.Add(plugin.Name);
            defEditorCombo.Text = lastWildcard;
        }
        
        private void FillValues(CoreSettings settings)
        {
            SpherePath = settings.EnginePath;
            Sphere64Path = settings.EnginePath64;
            ConfigPath = settings.EngineConfigPath;
            GamePaths = settings.GetStringArray("gamePaths");
            AutoStart = settings.AutoOpenProject;
            UseScriptUpdate = settings.AutoScriptHeader;
            UseStartPage = settings.AutoStartPage;
            Style = settings.UIStyle;
            DefaultEditor = settings.DefaultEditor;
            UpdateStyle();
        }

        private void SpherePathButton_Click(object sender, EventArgs e)
        {
            using (FileDialog diag = new OpenFileDialog())
            {
                diag.Filter = "Executable Files|*.exe";
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.GetDirectoryName(diag.FileName);
                    if (File.Exists(path + "\\engine.exe") || File.Exists(path + "\\engine64.exe"))
                    {
                        SpherePathBox.Clear();
                        Sphere64PathBox.Clear();
                        ConfigPathBox.Clear();
                        if (File.Exists(path + "\\engine.exe"))
                            SpherePathBox.Text = path + "\\engine.exe";
                        if (File.Exists(path + "\\engine64.exe"))
                            Sphere64PathBox.Text = path + "\\engine64.exe";
                        if (File.Exists(path + "\\config.exe"))
                            ConfigPathBox.Text = path + "\\config.exe";
                        if (Directory.Exists(path + "\\games"))
                            PathListBox.Items.Add(path + "\\games");
                    }
                    else
                    {
                        MessageBox.Show(String.Format("{0}\n\nThis directory doesn't appear to contain a Sphere engine. Make sure the directory you choose contains either or both engine.exe or engine64.exe.", path));
                    }
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
            UpdatePluginList();
            UpdatePresetBox();
        }

        private void UpdatePluginList()
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
        }
        
        private void UpdatePresetBox()
        {
            PresetListBox.Items.Clear();

            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
            string path = Path.Combine(sphereDir, @"Presets");
            if (!Directory.Exists(path)) return;

            string[] files = Directory.GetFiles(path, "*.preset");
            foreach (string s in files)
                PresetListBox.Items.Add(Path.GetFileNameWithoutExtension(s));

            PresetListBox.SelectedItem = null;
        }

        private void PluginList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!_updatePlugins) return;
            
            ListViewItem item = PluginList.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
                Global.Plugins[(string)item.Tag].Activate();
            else
                Global.Plugins[(string)item.Tag].Deactivate();
            RefreshPlugins();
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
            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
            string path = Path.Combine(sphereDir, @"Presets", (string)PresetListBox.SelectedItem + ".preset");
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
                    string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
                    Directory.CreateDirectory(Path.Combine(sphereDir, @"Presets"));
                    string presetName = form.Input;
                    string filePath = Path.Combine(sphereDir, @"Presets", presetName + ".preset");
                    bool continueSave = true;
                    if (File.Exists(filePath))
                    {
                        var result = MessageBox.Show(
                            String.Format("Configuration preset \"{0}\" already exists. Do you want to overwrite it?", presetName),
                            "Preset Already Exists", MessageBoxButtons.YesNo);
                        continueSave = (result == DialogResult.Yes);
                    }
                    if (continueSave)
                    {
                        INISettings preset = new INISettings(filePath, "Preset");
                        preset.SetValue("engineConfigPath", ConfigPath);
                        preset.SetValue("enginePath", SpherePath);
                        preset.SetValue("enginePath64", Sphere64Path);
                        preset.SetValue("defaultEditor", DefaultEditor);
                        UpdatePresetBox();
                    }
                    PresetListBox.SelectedItem = null;
                }
            }
        }

        private void UsePresetButton_Click(object sender, EventArgs e)
        {
            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
            string path = Path.Combine(sphereDir, @"Presets", (string)PresetListBox.SelectedItem + ".preset");
            INISettings preset = new INISettings(path, "Preset");
            SpherePath = preset.GetString("enginePath", "");
            Sphere64Path = preset.GetString("enginePath64", "");
            ConfigPath = preset.GetString("engineConfigPath", "");
            DefaultEditor = preset.GetString("defaultEditor", "");
            PresetListBox.SelectedItem = null;
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
            StyleSettings.ApplySecondaryStyle(this);
            StyleSettings.ApplyStyle(ButtonPanel);
            StyleSettings.ApplyStyle(okButton);
            StyleSettings.ApplyStyle(cancelButton);
            StyleSettings.ApplyStyle(PresetsPanel);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            StyleSettings.CurrentStyle = Style;
            UpdateStyle();
            Global.Settings.UIStyle = Style;
            Global.Settings.AutoOpenProject = AutoStart;
            Global.Settings.AutoStartPage = UseStartPage;
            Global.Settings.AutoScriptHeader = UseScriptUpdate;
            Global.Settings.EngineConfigPath = ConfigPath;
            Global.Settings.EnginePath = SpherePath;
            Global.Settings.EnginePath64 = Sphere64Path;
            Global.Settings.DefaultEditor = DefaultEditor;
            Invalidate(true);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ApplyButton.PerformClick();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
