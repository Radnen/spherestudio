using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using SphereStudio.Base;
using SphereStudio.Ide.Utility;

namespace SphereStudio.Ide.Forms
{
    partial class PluginManagerForm : Form, IStyleAware
    {
        private bool updatingHandlers = false;
        private bool updatingPresets = false;
        private bool updatingPlugins = false;

        public PluginManagerForm()
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);

            updatePresets();
            updatePlugins();
            updateHandlers();
            
            presetDropDown_SelectedIndexChanged(null, EventArgs.Empty);
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
            style.AsTextView(otherDropDown);
            style.AsTextView(scriptDropDown);
            style.AsTextView(imageDropDown);
            style.AsTextView(presetDropDown);

            style.AsHeading(pluginsHeading);
            style.AsAccent(pluginsPanel);
            style.AsTextView(pluginsListView);
        }

        private string getPluginName(ComboBox comboBox)
        {
            return comboBox.SelectedIndex > 0 ? comboBox.Text : null;
        }

        private void handleSelectionChanged()
        {
            if (updatingHandlers)
                return;

            Core.Settings.Engine = getPluginName(engineDropDown);
            Core.Settings.Compiler = getPluginName(typeDropDown);
            Core.Settings.FileOpener = getPluginName(otherDropDown);
            Core.Settings.ScriptEditor = getPluginName(scriptDropDown);
            Core.Settings.ImageEditor = getPluginName(imageDropDown);
            Core.Settings.Apply();
            updatePresets();
            updateHandlers();
        }

        private void populateHandlers<T>(ComboBox comboBox, string currentName)
            where T : IPlugin
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("(no handler selected)");
            foreach (string name in PluginManager.GetNames<T>())
                comboBox.Items.Add(name);
            if (comboBox.Items.Contains(currentName))
                comboBox.Text = currentName;
            else
                comboBox.SelectedIndex = 0;
        }

        private void updateHandlers()
        {
            if (updatingHandlers)
                return;
            
            updatingHandlers = true;

            populateHandlers<ICompiler>(typeDropDown, Core.Settings.Compiler);
            populateHandlers<IStarter>(engineDropDown, Core.Settings.Engine);
            populateHandlers<IEditor<ScriptView>>(otherDropDown, Core.Settings.FileOpener);
            populateHandlers<IEditor<ScriptView>>(scriptDropDown, Core.Settings.ScriptEditor);
            populateHandlers<IEditor<ImageView>>(imageDropDown, Core.Settings.ImageEditor);

            updatingHandlers = false;
        }
        
        private void updatePlugins()
        {
            if (updatingPlugins)
                return;
            
            updatingPlugins = true;

            pluginsListView.CreateGraphics();  // workaround for early ItemCheck event
            pluginsListView.Items.Clear();
            foreach (var pair in Core.Plugins)
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
            
            updatingPlugins = false;
        }
        
        private void updatePresets()
        {
            if (updatingPresets)
                return;
            
            updatingPresets = true;
            
            presetDropDown.Items.Clear();
            string presetPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Sphere Studio", "pluginPresets");
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

            updatingPresets = false;
        }

        private void okButton_Click(object sender, EventArgs e)
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

        private void presetDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingPresets)
                return;
            
            Core.Settings.Preset = presetDropDown.Text;
            Core.Settings.Apply();
            updatePlugins();
            updateHandlers();
            updatePresets();
        }

        private void savePresetButton_Click(object sender, EventArgs e)
        {
            using (var diag = new SavePresetForm())
            {
                if (diag.ShowDialog() != DialogResult.OK)
                    return;
                string fileName = diag.PresetName + ".preset";
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Sphere Studio", "pluginPresets", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (IniFile preset = new IniFile(path))
                {
                    preset.Write("Preset", "compiler", getPluginName(typeDropDown));
                    preset.Write("Preset", "engine", getPluginName(engineDropDown));
                    preset.Write("Preset", "defaultFileOpener", getPluginName(otherDropDown));
                    preset.Write("Preset", "scriptEditor", getPluginName(scriptDropDown));
                    preset.Write("Preset", "imageEditor", getPluginName(imageDropDown));
                    preset.Write("Preset", "disabledPlugins", string.Join("|", Core.Settings.DisabledPlugins));
                }
                Core.Settings.Preset = Path.GetFileNameWithoutExtension(fileName);
                Core.Settings.Apply();
                updatePresets();
            }
        }

        private void deletePresetButton_Click(object sender, EventArgs e)
        {
            string filename = $"{presetDropDown.Text}.preset";
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Sphere Studio", "pluginPresets", filename);
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the preset file \"{filename}\"?",
                "Delete Preset", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                File.Delete(path);
                updatePresets();
            }
        }

        private void pluginsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (updatingPlugins)
                return;

            Core.Settings.DisabledPlugins = (from ListViewItem item in pluginsListView.Items
                                        where !item.Checked
                                        select item.Tag as string).ToArray();
            Core.Settings.Apply();
            updateHandlers();
            updatePresets();
            handleSelectionChanged();
        }

        private void engineDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleSelectionChanged();
        }

        private void typeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleSelectionChanged();
        }

        private void otherDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleSelectionChanged();
        }

        private void scriptDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleSelectionChanged();
        }

        private void imageDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleSelectionChanged();
        }
    }
}
