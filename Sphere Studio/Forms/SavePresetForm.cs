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

namespace SphereStudio.Forms
{
    public partial class SavePresetForm : Form
    {
        public SavePresetForm()
        {
            InitializeComponent();
            UpdatePresetBox();

            presetBox.SelectedIndex = 0;
        }

        public string PresetName
        {
            get;
            private set;
        }

        private void MakeDefaultName()
        {
            const string defaultName = "Untitled Preset";
            
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Sphere Studio\Presets");
            string name = defaultName;
            int ordinal = 1;
            while (File.Exists(Path.Combine(path, name + ".preset")))
                name = string.Format("{0} {1}", defaultName, ++ordinal);
            customNameBox.Text = name;
        }
        
        private void UpdatePresetBox()
        {
            presetBox.Items.Clear();
            presetBox.Items.Add("new preset (enter name below)");
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Sphere Studio\Presets");
            if (Directory.Exists(path))
            {
                var presets = from filename in Directory.GetFiles(path, "*.preset")
                            orderby filename ascending
                            select Path.GetFileNameWithoutExtension(filename);
                foreach (string name in presets)
                    presetBox.Items.Add(name);
            }
        }

        private void presetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (presetBox.SelectedIndex == 0)
            {
                MakeDefaultName();
                customNameBox.Enabled = true;
                customNameBox.SelectAll();
                customNameBox.Select();
            }
            else
            {
                customNameBox.Enabled = false;
                customNameBox.Text = presetBox.Text;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string filename = customNameBox.Text + ".preset";
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                @"Sphere Studio\Presets", filename);
            bool isSaveAllowed = true;
            if (File.Exists(path))
            {
                DialogResult result = MessageBox.Show(
                    String.Format("A configuration preset named \"{0}\" already exists. Do you want to overwrite it?", customNameBox.Text),
                    "Preset Already Exists", MessageBoxButtons.YesNo);
                isSaveAllowed = result == DialogResult.Yes;
            }
            if (isSaveAllowed)
            {
                PresetName = customNameBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void customNameBox_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]");
            okButton.Enabled = !regex.IsMatch(customNameBox.Text);
        }
    }
}
