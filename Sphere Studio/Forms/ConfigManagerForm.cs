using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SphereStudio.Settings;
using Sphere.Plugins;

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
            
            presetBox.Text = Global.Settings.Preset;
            presetBox_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private bool _updatingPlugins = false;

        private void UpdateEditorsList()
        {
            string lastSelection = defEditorCombo.Text;
            defEditorCombo.Items.Clear();
            defEditorCombo.Items.Add("(none selected)");
            defEditorCombo.SelectedIndex = 0;
            var wildcards = from plugin in PluginManager.GetWildcards()
                            orderby plugin.Name ascending
                            select plugin;
            foreach (IEditorPlugin plugin in wildcards)
                defEditorCombo.Items.Add(plugin.Name);
            defEditorCombo.Text = lastSelection;
        }
        
        private void UpdatePluginsList()
        {
            if (_updatingPlugins)
                return;
            _updatingPlugins = true;

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
            var lastItem = presetBox.Text;
            
            presetBox.Items.Clear();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Sphere Studio\Presets");
            if (!Directory.Exists(path))
                return;
            var files = from filename in Directory.GetFiles(path, "*.preset")
                        orderby filename ascending
                        select filename;
            foreach (string filename in files)
                presetBox.Items.Add(Path.GetFileNameWithoutExtension(filename));

            presetBox.Text = lastItem;
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
            Global.Settings.Preset = presetBox.Text;
            Global.Settings.Apply();
            enginePathBox.Text = Global.Settings.EnginePath;
            enginePath64Box.Text = Global.Settings.EnginePath64;
            configPathBox.Text = Global.Settings.EngineConfigPath;
            defEditorCombo.Text = Global.Settings.DefaultEditor;
            UpdatePluginsList();
            deleteButton.Enabled = true;
        }

        private void presetBox_TextUpdate(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string filename = string.Format("{0}.preset", presetBox.Text);
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                @"Sphere Studio\Presets", filename);
            bool isSaveAllowed = true;
            if (File.Exists(path))
            {
                DialogResult result = MessageBox.Show(
                    String.Format("A preset file named \"{0}\" already exists. Do you want to overwrite it?", filename),
                    "Preset Already Exists", MessageBoxButtons.YesNo);
                isSaveAllowed = result == DialogResult.Yes;
            }
            if (isSaveAllowed)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                INISettings preset = new INISettings(path, "Preset");
                preset.SetValue("enginePath", enginePathBox.Text);
                preset.SetValue("enginePath64", enginePath64Box.Text);
                preset.SetValue("engineConfigPath", configPathBox.Text);
                preset.SetValue("defaultEditor", defEditorCombo.SelectedIndex > 0 ? defEditorCombo.Text : "");
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
            }
        }

        private void pluginList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_updatingPlugins) return;

            ListViewItem item = pluginList.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
                Global.Plugins[(string)item.Tag].Activate();
            else
                Global.Plugins[(string)item.Tag].Deactivate();
            UpdateEditorsList();
        }
    }
}
