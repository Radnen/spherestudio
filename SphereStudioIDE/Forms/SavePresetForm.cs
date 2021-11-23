using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using SphereStudio.Base;

namespace SphereStudio.Ide.Forms
{
    public partial class SavePresetForm : Form, IStyleAware
    {
        public SavePresetForm()
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);
            
            UpdatePresetBox();
            presetDropDown.SelectedIndex = 0;
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsHeading(header);
            style.AsHeading(footer);
            style.AsAccent(okButton);
            style.AsAccent(cancelButton);

            style.AsHeading(nameHeading);
            style.AsAccent(namePanel);
            style.AsTextView(presetDropDown);
            style.AsTextView(nameTextBox);
        }

        public string PresetName { get; private set; }

        private void MakeDefaultName()
        {
            const string defaultName = "Untitled Preset";
            
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Sphere Studio", "pluginPresets");
            string name = defaultName;
            int ordinal = 1;
            while (File.Exists(Path.Combine(path, name + ".preset")))
                name = $"{defaultName} {++ordinal}";
            nameTextBox.Text = name;
        }
        
        private void UpdatePresetBox()
        {
            presetDropDown.Items.Clear();
            presetDropDown.Items.Add("new preset (enter name below)");
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Sphere Studio", "pluginPresets");
            if (Directory.Exists(path))
            {
                var presets = from filename in Directory.GetFiles(path, "*.preset")
                            orderby filename ascending
                            select Path.GetFileNameWithoutExtension(filename);
                foreach (string name in presets)
                    presetDropDown.Items.Add(name);
            }
        }

        private void presetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (presetDropDown.SelectedIndex == 0)
            {
                MakeDefaultName();
                nameTextBox.Enabled = true;
                nameTextBox.SelectAll();
                nameTextBox.Select();
            }
            else
            {
                nameTextBox.Enabled = false;
                nameTextBox.Text = presetDropDown.Text;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string filename = nameTextBox.Text + ".preset";
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Sphere Studio", "pluginPresets", filename);
            bool isSaveAllowed = true;
            if (File.Exists(path))
            {
                DialogResult result = MessageBox.Show(
                    String.Format("A configuration preset named \"{0}\" already exists. Do you want to overwrite it?", nameTextBox.Text),
                    "Preset Already Exists", MessageBoxButtons.YesNo);
                isSaveAllowed = result == DialogResult.Yes;
            }
            if (isSaveAllowed)
            {
                PresetName = nameTextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void customNameBox_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]");
            okButton.Enabled = !regex.IsMatch(nameTextBox.Text);
        }
    }
}
