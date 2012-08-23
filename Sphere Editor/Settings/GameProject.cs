using System;
using System.IO;
using System.Windows.Forms;

// This contains game project related stuff //
namespace Sphere_Editor.Settings
{
    public class ProjectSettings
    {
        public string Width { get; set; }
        public string Height { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string Script { get; set; }

        public void SetDataNew(System.Windows.Forms.Form newForm)
        {
            Control.ControlCollection PropertyControls = newForm.Controls["PropertiesBox"].Controls;
            Control.ControlCollection ProjectControls = newForm.Controls["ProjectBox"].Controls;
            Width = PropertyControls["WidthBox"].Text;
            Height = PropertyControls["HeightBox"].Text;
            Author = PropertyControls["AuthorBox"].Text;
            Description = PropertyControls["DescriptionBox"].Text;
            Name = ProjectControls["NameBox"].Text;
            Path = ProjectControls["DirectoryBox"].Text;
        }

        public void SetData(System.Windows.Forms.Form setForm)
        {
            Control.ControlCollection Controls = setForm.Controls;
            Width = Controls["WidthTextBox"].Text;
            Height = Controls["HeightTextBox"].Text;
            Author = Controls["AuthorTextBox"].Text;
            Description = Controls["DescTextBox"].Text;
            Name = Controls["NameTextBox"].Text;
            Path = Controls["PathTextBox"].Text;
            Script = Controls["ScriptComboBox"].Text;
        }

        // save data to a .sgm file.
        public void SaveData()
        {
            FileInfo file = new FileInfo(Path + "\\game.sgm");
            using (StreamWriter saver = new StreamWriter(file.OpenWrite()))
            {
                try
                {
                    saver.WriteLine("author=" + Author);
                    saver.WriteLine("description=" + Description);
                    saver.WriteLine("name=" + Name);
                    saver.WriteLine("screen_height=" + Height);
                    saver.WriteLine("screen_width=" + Width);
                    saver.WriteLine("script=" + Script);
                }
                catch
                {
                    MessageBox.Show("Error, file: game.sgm can't be written to.", "Alert!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                saver.Flush();
            }
        }

        // read in data from a .sgm file.
        public bool LoadData(string filename)
        {
            FileInfo gameSGM = new FileInfo(filename);
            if (!gameSGM.Exists) return false;
            Path = gameSGM.DirectoryName;
            try
            {
                using (StreamReader reader = gameSGM.OpenText())
                {
                    Author = reader.ReadLine().Split('=')[1];
                    Description = reader.ReadLine().Split('=')[1];
                    Name = reader.ReadLine().Split('=')[1];
                    Height = reader.ReadLine().Split('=')[1];
                    Width = reader.ReadLine().Split('=')[1];
                    Script = reader.ReadLine().Split('=')[1];
                }
            }
            catch
            {
                MessageBox.Show("Error, file: game.sgm can't be read from.", "Alert!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            return true;
        }

        internal void Create()
        {
            // Create The Main Folder //
            DirectoryInfo GameDir = new DirectoryInfo(Path);
            GameDir.Create();

            // Create the Sub-folders //
            string[] subfolders = {"animations", "fonts", "images", "maps", "scripts", "sounds", "spritesets", "windowstyles"};
            for (int i = 0; i < subfolders.Length; ++i)
            {
                DirectoryInfo subfolder = new DirectoryInfo(Path + "\\" + subfolders[i]);
                subfolder.Create();
            }
        }
    }
}
