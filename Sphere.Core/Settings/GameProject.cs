using System.IO;
using System.Windows.Forms;
using Sphere.Core;

// This contains game project related stuff //
namespace Sphere.Core.Settings
{
    public class ProjectSettings : GenSettings
    {
        /// <summary>
        /// Gets or sets the width of the Sphere game window.
        /// </summary>
        public string Width
        {
            get { return GetString("screen_width"); }
            set { SetItem<string>("screen_width", value); }
        }

        /// <summary>
        /// Gets or sets the height of the Sphere game window.
        /// </summary>
        public string Height
        {
            get { return GetString("screen_height"); }
            set { SetItem<string>("screen_height", value); }
        }

        /// <summary>
        /// Gets or sets the name of this Sphere game.
        /// </summary>
        public string Name
        {
            get { return GetString("name"); }
            set { SetItem<string>("name", value); }
        }

        /// <summary>
        /// Gets or sets the author of this Sphere game.
        /// </summary>
        public string Author
        {
            get { return GetString("author"); }
            set { SetItem<string>("author", value); }
        }

        /// <summary>
        /// Gets or sets the description of this Sphere game.
        /// </summary>
        public string Description
        {
            get { return GetString("description"); }
            set { SetItem<string>("description", value); }
        }

        /// <summary>
        /// Gets or sets the starting script for this Sphere game.
        /// </summary>
        public string Script
        {
            get { return GetString("script"); }
            set { SetItem<string>("script", value); }
        }

        /// <summary>
        /// Saves the settings to the \RootPath\ + 'game.sgm'
        /// </summary>
        public void SaveSettings()
        {
            SaveSettings(string.Format("{0}\\game.sgm", RootPath));
        }

        public void Create()
        {
            // Create The Main Folder //
            DirectoryInfo GameDir = new DirectoryInfo(RootPath);
            GameDir.Create();

            // Create the Sub-folders //
            string[] subfolders = { "animations", "fonts", "images", "maps", "scripts", "sounds", "spritesets", "windowstyles" };
            for (int i = 0; i < subfolders.Length; ++i)
            {
                DirectoryInfo subfolder = new DirectoryInfo(RootPath + "\\" + subfolders[i]);
                subfolder.Create();
            }
        }

        public void SetRootPath(string path)
        {
            RootPath = path;
        }
    }
}
