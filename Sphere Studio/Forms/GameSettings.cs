using System;
using System.IO;
using System.Windows.Forms;
using Sphere.Core.Settings;
using Sphere.Core.Editor;

namespace SphereStudio.Forms
{
    internal partial class GameSettings : Form, IStyleable
    {
        public GameSettings(ProjectSettings someProject)
        {
            InitializeComponent();
            PathTextBox.Text = someProject.RootPath;
            NameTextBox.Text = someProject.Name;
            AuthorTextBox.Text = someProject.Author;
            DescTextBox.Text = someProject.Description;
            WidthTextBox.Text = someProject.Width;
            HeightTextBox.Text = someProject.Height;
            ScriptComboBox.Text = someProject.Script;
            UpdateStyle();
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            // I'll need to populate the script combo box.
            DirectoryInfo dir = new DirectoryInfo(PathTextBox.Text + "\\scripts");
            FileInfo[] scriptList = dir.GetFiles("*.js");
            for (int i = 0; i < scriptList.Length; ++i)
            {
                ScriptComboBox.Items.Add(scriptList[i].Name);
            }
        }

        public ProjectSettings GetSettings()
        {
            ProjectSettings settings = new ProjectSettings();
            settings.SetRootPath(PathTextBox.Text);
            settings.Name = NameTextBox.Text;
            settings.Author = AuthorTextBox.Text;
            settings.Description = DescTextBox.Text;
            settings.Width = WidthTextBox.Text;
            settings.Height = HeightTextBox.Text;
            settings.Script = ScriptComboBox.Text;
            return settings;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }

        public void UpdateStyle()
        {
            StyleSettings.ApplyStyle(ButtonPanel);
            StyleSettings.ApplyStyle(okayButton);
            StyleSettings.ApplyStyle(cancelButton);
        }
    }
}
