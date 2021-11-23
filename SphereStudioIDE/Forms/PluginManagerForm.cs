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

using SphereStudio;
using SphereStudio.Ide;
using SphereStudio.Ide.BuiltIns;
using SphereStudio.Ide.Utility;
using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Ide.Forms
{
    partial class PluginManagerForm : Form, IStyleAware
    {
        private bool _updatingDefaultsLists = false;
        private bool _updatingPresets = false;
        private bool _updatingPlugins = false;

        public PluginManagerForm()
        {
            InitializeComponent();
            
            UpdatePresetsList();
            UpdatePluginsList();
            UpdateDefaultsLists();
            
            PresetsList_SelectedIndexChanged(null, EventArgs.Empty);

            StyleManager.AutoStyle(this);
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsHeading(header);
            style.AsHeading(footer);
            style.AsAccent(okButton);

            style.AsTextView(presetDropDown);
            style.AsAccent(savePresetButton);
            style.AsAccent(deletePresetButton);

            style.AsHeading(defaultsHeading);
            style.AsAccent(defaultsPanel);
            style.AsTextView(engineDropDown);
            style.AsTextView(typeDropDown);
            style.AsTextView(fileDropDown);
            style.AsTextView(scriptDropDown);
            style.AsTextView(imageDropDown);
            style.AsTextView(presetDropDown);

            style.AsHeading(pluginsHeading);
            style.AsAccent(pluginsPanel);
            style.AsTextView(pluginsListView);
        }

        private string GetPluginName(ComboBox comboBox)
        {
            return comboBox.Tag != null || comboBox.SelectedIndex > 0
                ? comboBox.Text : null;
        }

        private void HandleSelectionChanged()
        {
            if (_updatingDefaultsLists) return;

            Core.Settings.Engine = GetPluginName(engineDropDown);
            Core.Settings.Compiler = GetPluginName(typeDropDown);
            Core.Settings.FileOpener = GetPluginName(fileDropDown);
            Core.Settings.ScriptEditor = GetPluginName(scriptDropDown);
            Core.Settings.ImageEditor = GetPluginName(imageDropDown);
            Core.Settings.Apply();
            UpdatePresetsList();
            UpdateDefaultsLists();
        }

        private void PopulateComboBox<T>(ComboBox combo, string currentName)
            where T : IPlugin
        {
            combo.Items.Clear();
            foreach (string name in PluginManager.GetNames<T>())
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
            
            PopulateComboBox<ICompiler>(typeDropDown, Core.Settings.Compiler);
            PopulateComboBox<IStarter>(engineDropDown, Core.Settings.Engine);
            PopulateComboBox<IFileOpener>(fileDropDown, Core.Settings.FileOpener);
            PopulateComboBox<IEditor<ScriptView>>(scriptDropDown, Core.Settings.ScriptEditor);
            PopulateComboBox<IEditor<ImageView>>(imageDropDown, Core.Settings.ImageEditor);

            _updatingDefaultsLists = false;
        }
        
        private void UpdatePluginsList()
        {
            if (_updatingPlugins) return;
            _updatingPlugins = true;

            pluginsListView.CreateGraphics();  // workaround for early ItemCheck event
            pluginsListView.Items.Clear();
            foreach (KeyValuePair<string, PluginShim> pair in Core.Plugins)
            {
                ListViewItem item = new ListViewItem();
                item.Text = pair.Value.Main.Name;
                item.SubItems.Add(pair.Value.Main.Author);
                item.SubItems.Add(pair.Value.Main.Version);
                item.SubItems.Add(pair.Value.Main.Description);
                item.Tag = pair.Key;
                item.Checked = !Core.Settings.DisabledPlugins.Contains(pair.Value.Handle);
                pluginsListView.Items.Add(item);
            }
            
            _updatingPlugins = false;
        }
        
        private void UpdatePresetsList()
        {
            if (_updatingPresets) return;
            _updatingPresets = true;
            
            string lastItem = Core.Settings.Preset;
            
            presetDropDown.Items.Clear();
            string presetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio", "Presets");
            if (Directory.Exists(presetPath))
            {
                var presets = from filename in Directory.GetFiles(presetPath, "*.preset")
                              orderby filename ascending
                              select Path.GetFileNameWithoutExtension(filename);
                foreach (string name in presets)
                    presetDropDown.Items.Add(name);
            }

            if (presetDropDown.Items.Contains(Core.Settings.Preset ?? ""))
            {
                presetDropDown.Text = Core.Settings.Preset;
                deletePresetButton.Enabled = true;
            }
            else
            {
                presetDropDown.Items.Insert(0, "Custom Settings");
                presetDropDown.SelectedIndex = 0;
                deletePresetButton.Enabled = false;
            }

            _updatingPresets = false;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool haveAllPlugins = PluginManager.Get<IStarter>(Core.Settings.Engine) != null
                && PluginManager.Get<ICompiler>(Core.Settings.Compiler) != null
                && PluginManager.Get<IFileOpener>(Core.Settings.FileOpener) != null
                && PluginManager.Get<IEditor<ScriptView>>(Core.Settings.ScriptEditor) != null
                && PluginManager.Get<IEditor<ImageView>>(Core.Settings.ImageEditor) != null;
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
            Core.Settings.Preset = presetDropDown.Text;
        }

        private void PresetsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updatingPresets) return;
            
            Core.Settings.Preset = presetDropDown.Text;
            Core.Settings.Apply();
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
                    "Sphere Studio", "Presets", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (IniFile preset = new IniFile(path))
                {
                    preset.Write("Preset", "compiler", GetPluginName(typeDropDown));
                    preset.Write("Preset", "engine", GetPluginName(engineDropDown));
                    preset.Write("Preset", "defaultFileOpener", GetPluginName(fileDropDown));
                    preset.Write("Preset", "scriptEditor", GetPluginName(scriptDropDown));
                    preset.Write("Preset", "imageEditor", GetPluginName(imageDropDown));
                    preset.Write("Preset", "disabledPlugins", string.Join("|", Core.Settings.DisabledPlugins));
                }
                Core.Settings.Preset = Path.GetFileNameWithoutExtension(fileName);
                Core.Settings.Apply();
                UpdatePresetsList();
            }
        }

        private void DeletePresetButton_Click(object sender, EventArgs e)
        {
            string filename = string.Format("{0}.preset", presetDropDown.Text);
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Sphere Studio", "Presets", filename);
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

            Core.Settings.DisabledPlugins = (from ListViewItem item in pluginsListView.Items
                                        where !item.Checked
                                        select item.Tag as string).ToArray();
            Core.Settings.Apply();
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
