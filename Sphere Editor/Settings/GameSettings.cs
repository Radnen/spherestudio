using System;
using System.IO;
using System.Windows.Forms;

namespace Sphere_Editor.Settings
{
    public partial class GameSettings : Form
    {
        public GameSettings(ProjectSettings someProject)
        {
            InitializeComponent();
            PathTextBox.Text = someProject.Path;
            NameTextBox.Text = someProject.Name;
            AuthorTextBox.Text = someProject.Author;
            DescTextBox.Text = someProject.Description;
            WidthTextBox.Text = someProject.Width;
            HeightTextBox.Text = someProject.Height;
            ScriptComboBox.Text = someProject.Script;
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

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8);
        }
    }
}
