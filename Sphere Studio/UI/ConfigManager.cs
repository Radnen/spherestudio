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
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;
using Sphere.Core;
using Sphere.Core.Editor;

namespace SphereStudio.Forms
{
    public partial class ConfigManager : Form
    {
        private bool _updatingDefaultsLists = false;
        private bool _updatingPresets = false;
        private bool _updatingPlugins = false;

        public ConfigManager()
        {
            InitializeComponent();
            
            UpdatePresetsList();
            UpdatePluginsList();
            UpdateDefaultsLists();
            
            PresetsList_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private string GetPluginName(ComboBox comboBox)
        {
            return comboBox.Tag != null || comboBox.SelectedIndex > 0
                ? comboBox.Text : null;
        }

        private void HandleSelectionChanged()
        {
            if (_updatingDefaultsLists) return;

            Global.Settings.Engine = GetPluginName(EnginePluginList);
            Global.Settings.Compiler = GetPluginName(CompilerPluginList);
            Global.Settings.DefaultFileOpener = GetPluginName(FilePluginList);
            Global.Settings.ScriptEditor = GetPluginName(ScriptPluginList);
            Global.Settings.ImageEditor = GetPluginName(ImagePluginList);
            Global.Settings.Apply();
            UpdatePresetsList();
            UpdateDefaultsLists();
        }

        private void PopulateComboBox<T>(ComboBox combo, string currentName)
            where T : IPlugin
        {
            combo.Items.Clear();
            foreach (string name in Sphere.Plugins.PluginManager.GetNames<T>())
            {
                combo.Items.Add(name);
            }
            if (combo.Items.Contains(currentName))
            {
                combo.Text = currentName;
                combo.Tag = combo.Text;
            }
            else
            {
                combo.Items.Insert(0, "Click to select a plugin!");
                combo.SelectedIndex = 0;
                combo.Tag = null;
            }
        }

        private void UpdateDefaultsLists()
        {
            if (_updatingDefaultsLists) return;
            _updatingDefaultsLists = true;
            
            PopulateComboBox<ICompiler>(CompilerPluginList, Global.Settings.Compiler);
            PopulateComboBox<IStarter>(EnginePluginList, Global.Settings.Engine);
            PopulateComboBox<IFileOpener>(FilePluginList, Global.Settings.DefaultFileOpener);
            PopulateComboBox<IEditor<ScriptView>>(ScriptPluginList, Global.Settings.ScriptEditor);
            PopulateComboBox<IEditor<ImageView>>(ImagePluginList, Global.Settings.ImageEditor);

            _updatingDefaultsLists = false;
        }
        
        private void UpdatePluginsList()
        {
            if (_updatingPlugins) return;
            _updatingPlugins = true;

            PluginsList.CreateGraphics();  // workaround for early ItemCheck event
            PluginsList.Items.Clear();
            foreach (KeyValuePair<string, PluginWrapper> pair in Global.Plugins)
            {
                ListViewItem item = new ListViewItem();
                item.Text = pair.Value.Plugin.Name;
                item.SubItems.Add(pair.Value.Plugin.Author);
                item.SubItems.Add(pair.Value.Plugin.Version);
                item.SubItems.Add(pair.Value.Plugin.Description);
                item.Tag = pair.Key;
                item.Checked = Global.Settings.Plugins.Contains(pair.Value.Name);
                PluginsList.Items.Add(item);
            }
            
            _updatingPlugins = false;
        }
        
        private void UpdatePresetsList()
        {
            if (_updatingPresets) return;
            _updatingPresets = true;
            
            string lastItem = Global.Settings.Preset;
            
            PresetsList.Items.Clear();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Sphere Studio\Presets");
            if (!Directory.Exists(path))
                return;
            var presets = from filename in Directory.GetFiles(path, "*.preset")
                        orderby filename ascending
                        select Path.GetFileNameWithoutExtension(filename);
            foreach (string name in presets)
                PresetsList.Items.Add(name);

            if (PresetsList.Items.Contains(Global.Settings.Preset ?? ""))
            {
                PresetsList.Text = Global.Settings.Preset;
                DeletePresetButton.Enabled = true;
            }
            else
            {
                PresetsList.Items.Insert(0, "Custom Settings");
                PresetsList.SelectedIndex = 0;
                DeletePresetButton.Enabled = false;
            }

            _updatingPresets = false;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool haveAllPlugins = !string.IsNullOrEmpty(Global.Settings.Engine)
                && !string.IsNullOrEmpty(Global.Settings.Compiler)
                && !string.IsNullOrEmpty(Global.Settings.DefaultFileOpener)
                && !string.IsNullOrEmpty(Global.Settings.ScriptEditor)
                && !string.IsNullOrEmpty(Global.Settings.ImageEditor);
            if (!haveAllPlugins)
            {
                DialogResult result = MessageBox.Show(
                    "You haven't selected plugins for one or more tasks. Continue?",
                    "No Handler Selected",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    DialogResult = DialogResult.None;
                    return;
                }
            }
            Global.Settings.Preset = PresetsList.Text;
        }

        private void PresetsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updatingPresets) return;
            
            Global.Settings.Preset = PresetsList.Text;
            Global.Settings.Apply();
            UpdatePluginsList();
            UpdateDefaultsLists();
            UpdatePresetsList();
        }

        private void SavePresetButton_Click(object sender, EventArgs e)
        {
            using (var diag = new SavePresetForm())
            {
                if (diag.ShowDialog() != DialogResult.OK)
                    return;
                string fileName = diag.PresetName + ".preset";
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    @"Sphere Studio\Presets", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (INI preset = new INI(path))
                {
                    preset.Write("Preset", "compiler", GetPluginName(CompilerPluginList));
                    preset.Write("Preset", "engine", GetPluginName(EnginePluginList));
                    preset.Write("Preset", "defaultFileOpener", GetPluginName(FilePluginList));
                    preset.Write("Preset", "scriptEditor", GetPluginName(ScriptPluginList));
                    preset.Write("Preset", "imageEditor", GetPluginName(ImagePluginList));
                    preset.Write("Preset", "plugins", string.Join("|", Global.Settings.Plugins));
                }
                Global.Settings.Preset = Path.GetFileNameWithoutExtension(fileName);
                Global.Settings.Apply();
                UpdatePresetsList();
            }
        }

        private void DeletePresetButton_Click(object sender, EventArgs e)
        {
            string filename = string.Format("{0}.preset", PresetsList.Text);
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                @"Sphere Studio\Presets", filename);
            DialogResult result = MessageBox.Show(
                String.Format("Are you sure you want to delete the preset file \"{0}\"?", filename),
                "Delete Preset", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                File.Delete(path);
                UpdatePresetsList();
            }
        }

        private void PluginsList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_updatingPlugins) return;

            Global.Settings.Plugins = (from ListViewItem item in PluginsList.Items
                                       where item.Checked
                                       select item.Tag as string).ToArray();
            Global.Settings.Apply();
            UpdateDefaultsLists();
            UpdatePresetsList();
        }

        private void EnginePluginList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged();
        }

        private void CompilerPluginList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged();
        }

        private void FilePluginList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged();
        }

        private void ScriptPluginList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged();
        }

        private void ImagePluginList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleSelectionChanged();
        }
    }
}
