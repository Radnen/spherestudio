using System;
using System.IO;
using System.Windows.Forms;

// This contains game project related stuff //
namespace Sphere_Editor.Settings
{
    public class ProjectSettings : GenSettings
    {
        public string Width
        {
            get { return GetKeyData("screen_width"); }
            set { SetItem<string>("screen_width", value); }
        }

        public string Height
        {
            get { return GetKeyData("screen_height"); }
            set { SetItem<string>("screen_height", value); }
        }

        public string Name
        {
            get { return GetKeyData("name"); }
            set { SetItem<string>("name", value); }
        }

        public string Author
        {
            get { return GetKeyData("author"); }
            set { SetItem<string>("author", value); }
        }

        public string Description
        {
            get { return GetKeyData("description"); }
            set { SetItem<string>("description", value); }
        }

        public string Script
        {
            get { return GetKeyData("script"); }
            set { SetItem<string>("script", value); }
        }

        public void SetDataNew(System.Windows.Forms.Form newForm)
        {
            Control.ControlCollection PropertyControls = newForm.Controls["PropertiesBox"].Controls;
            Control.ControlCollection ProjectControls = newForm.Controls["ProjectBox"].Controls;
            Width = PropertyControls["WidthBox"].Text;
            Height = PropertyControls["HeightBox"].Text;
            Author = PropertyControls["AuthorBox"].Text;
            Description = PropertyControls["DescriptionBox"].Text;
            Name = ProjectControls["NameBox"].Text;
            RootPath = ProjectControls["DirectoryBox"].Text;
        }

        public void SetData(System.Windows.Forms.Form setForm)
        {
            Control.ControlCollection Controls = setForm.Controls;
            Width = Controls["WidthTextBox"].Text;
            Height = Controls["HeightTextBox"].Text;
            Author = Controls["AuthorTextBox"].Text;
            Description = Controls["DescTextBox"].Text;
            Name = Controls["NameTextBox"].Text;
            RootPath = Controls["PathTextBox"].Text;
            Script = Controls["ScriptComboBox"].Text;
        }

        // save data to a .sgm file.
        public void SaveSettings()
        {
            SaveSettings(RootPath + "\\game.sgm");
        }

        internal void Create()
        {
            // Create The Main Folder //
            DirectoryInfo GameDir = new DirectoryInfo(RootPath);
            GameDir.Create();

            // Create the Sub-folders //
            string[] subfolders = {"animations", "fonts", "images", "maps", "scripts", "sounds", "spritesets", "windowstyles"};
            for (int i = 0; i < subfolders.Length; ++i)
            {
                DirectoryInfo subfolder = new DirectoryInfo(RootPath + "\\" + subfolders[i]);
                subfolder.Create();
            }
        }
    }
}
