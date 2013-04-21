using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Sphere.Core.Settings;
using Sphere_Editor.Utility;

namespace Sphere_Editor.Forms
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
            set { PathListBox.Items.Clear(); PathListBox.Items.AddRange(value); }
        }

        public string LabelFont
        {
            get { return FontComboBox.Text; }
            set { FontComboBox.Text = value; }
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

        private bool _updatePlugins = false;
        #endregion

        public EditorSettings(SphereSettings settings)
        {
            InitializeComponent();
            SetValues(settings);
        }

        private void SetValues(SphereSettings settings)
        {
            SpherePath = settings.SpherePath;
            ConfigPath = settings.ConfigPath;
            GamePaths = settings.GetArray("games_path");
            AutoStart = settings.AutoOpen;
            UseScriptUpdate = settings.UseScriptUpdate;
            LabelFont = settings.LabelFont;
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
            settings.LabelFont = LabelFont;
            settings.StoreArray("games_path", GamePaths);

            int i = 0;
            string[] str = new string[Global.plugins.Count];
            foreach (var item in Global.plugins) str[i++] = item.Key;

            settings.StoreArray("plugins", str);
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
            if (e.NewValue == CheckState.Checked) Global.plugins[(string)item.Tag].Activate();
            else Global.plugins[(string)item.Tag].Deactivate();
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
            using (Sphere_Editor.Forms.StringInputForm form = new Sphere_Editor.Forms.StringInputForm())
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
    }
}
