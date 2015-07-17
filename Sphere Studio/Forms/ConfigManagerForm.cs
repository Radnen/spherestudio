using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using SphereStudio.Settings;
using Sphere.Plugins;
using Sphere.Core.Editor;

namespace SphereStudio.Forms
{
    public partial class ConfigManagerForm : Form
    {
        public ConfigManagerForm()
        {
            InitializeComponent();
            
            UpdatePresetBox();
            UpdatePluginsList();
            UpdateEditorsList();
            
            presetBox_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private bool _updatingEditors = false;
        private bool _updatingPresets = false;
        private bool _updatingPlugins = false;

        private void UpdateEditorsList()
        {
            if (_updatingEditors) return;
            _updatingEditors = true;
            
            defEditorCombo.Items.Clear();
            defEditorCombo.Items.Add("(none selected)");
            defEditorCombo.SelectedIndex = 0;
            var wildcards = from plugin in PluginManager.GetWildcards()
                            orderby plugin.Name ascending
                            select plugin;
            foreach (IEditorPlugin plugin in wildcards)
                defEditorCombo.Items.Add(plugin.Name);
            if (Global.Settings.DefaultEditor != null)
                defEditorCombo.Text = Global.Settings.DefaultEditor;

            _updatingEditors = false;
        }
        
        private void UpdatePluginsList()
        {
            if (_updatingPlugins) return;
            _updatingPlugins = true;

            pluginList.CreateGraphics();  // workaround for early ItemCheck event
            pluginList.Items.Clear();
            foreach (KeyValuePair<string, PluginWrapper> pair in Global.Plugins)
            {
                ListViewItem item = new ListViewItem();
                item.Text = pair.Value.Plugin.Name;
                item.SubItems.Add(pair.Value.Plugin.Author);
                item.SubItems.Add(pair.Value.Plugin.Version);
                item.SubItems.Add(pair.Value.Plugin.Description);
                item.Tag = pair.Key;
                item.Checked = Global.Settings.Plugins.Contains(pair.Value.Name);
                pluginList.Items.Add(item);
            }
            
            _updatingPlugins = false;
        }
        
        private void UpdatePresetBox()
        {
            if (_updatingPresets) return;
            _updatingPresets = true;
            
            string lastItem = Global.Settings.Preset;
            
            presetBox.Items.Clear();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Sphere Studio\Presets");
            if (!Directory.Exists(path))
                return;
            var presets = from filename in Directory.GetFiles(path, "*.preset")
                        orderby filename ascending
                        select Path.GetFileNameWithoutExtension(filename);
            foreach (string name in presets)
                presetBox.Items.Add(name);

            if (presetBox.Items.Contains(Global.Settings.Preset ?? ""))
            {
                presetBox.Text = Global.Settings.Preset;
                deleteButton.Enabled = true;
            }
            else
            {
                presetBox.Items.Insert(0, "Custom Settings");
                presetBox.SelectedIndex = 0;
                deleteButton.Enabled = false;
            }

            _updatingPresets = false;
        }

        private void findEngineButton_Click(object sender, EventArgs e)
        {
            using (FileDialog diag = new OpenFileDialog())
            {
                diag.Filter = "Executable Files|*.exe";
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.GetDirectoryName(diag.FileName) + @"\";
                    string exeName = Path.GetFileNameWithoutExtension(diag.FileName);
                    if (exeName.Substring(exeName.Length - 2) == "64")
                        exeName = exeName.Substring(0, exeName.Length - 2);
                    string exeName64 = path + exeName + "64.exe";
                    exeName = path + exeName + ".exe";
                    if (File.Exists(exeName) || File.Exists(exeName64))
                    {
                        enginePathBox.Clear();
                        enginePath64Box.Clear();
                        configPathBox.Clear();
                        if (File.Exists(exeName)) enginePathBox.Text = exeName;
                        if (File.Exists(exeName64)) enginePath64Box.Text = exeName64;
                        if (File.Exists(path + "config.exe"))
                            configPathBox.Text = path + "config.exe";
                        Global.Settings.EnginePath = enginePathBox.Text;
                        Global.Settings.EnginePath64 = enginePath64Box.Text;
                        Global.Settings.EngineConfigPath = configPathBox.Text;
                        UpdatePresetBox();
                    }
                    else
                    {
                        MessageBox.Show(String.Format("{0}\n\nThis directory doesn't seem to contain a Sphere engine. Make sure the directory you choose contains either or both engine.exe or engine64.exe.", path));
                    }
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Global.Settings.Preset = presetBox.Text;
        }

        private void presetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updatingPresets) return;
            
            Global.Settings.Preset = presetBox.Text;
            Global.Settings.Apply();
            enginePathBox.Text = Global.Settings.EnginePath;
            enginePath64Box.Text = Global.Settings.EnginePath64;
            configPathBox.Text = Global.Settings.EngineConfigPath;
            UpdatePluginsList();
            UpdateEditorsList();
            UpdatePresetBox();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var diag = new SavePresetForm())
            {
                if (diag.ShowDialog() != DialogResult.OK)
                    return;
                string filename = diag.PresetName + ".preset";
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    @"Sphere Studio\Presets", filename);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                INISettings preset = new INISettings(path, "Preset");
                preset.SetValue("enginePath", enginePathBox.Text);
                preset.SetValue("enginePath64", enginePath64Box.Text);
                preset.SetValue("engineConfigPath", configPathBox.Text);
                preset.SetValue("defaultEditor", defEditorCombo.SelectedIndex > 0 ? defEditorCombo.Text : "");
                preset.SetValue("plugins", Global.Settings.Plugins);
                Global.Settings.Preset = Path.GetFileNameWithoutExtension(filename);
                Global.Settings.Apply();
                UpdatePresetBox();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string filename = string.Format("{0}.preset", presetBox.Text);
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                @"Sphere Studio\Presets", filename);
            DialogResult result = MessageBox.Show(
                String.Format("Are you sure you want to delete the preset file \"{0}\"?", filename),
                "Delete Preset", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                File.Delete(path);
                UpdatePresetBox();
            }
        }

        private void enginePathBox_Validated(object sender, EventArgs e)
        {
            Global.Settings.EnginePath = enginePathBox.Text;
            UpdatePresetBox();
        }

        private void enginePath64Box_Validated(object sender, EventArgs e)
        {
            Global.Settings.EnginePath64 = enginePath64Box.Text;
            UpdatePresetBox();
        }

        private void configPathBox_Validated(object sender, EventArgs e)
        {
            Global.Settings.EngineConfigPath = configPathBox.Text;
            UpdatePresetBox();
        }

        private void pluginList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_updatingPlugins) return;

            Global.Settings.Plugins = (from ListViewItem item in pluginList.Items
                                       where item.Checked
                                       select item.Tag as string).ToArray();
            Global.Settings.Apply();
            UpdateEditorsList();
            UpdatePresetBox();
        }

        private void defEditorCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updatingEditors) return;
            
            Global.Settings.DefaultEditor = defEditorCombo.SelectedIndex > 0 ? defEditorCombo.Text : null;
            Global.Settings.Apply();
            UpdatePresetBox();
            UpdateEditorsList();
        }
    }
}
