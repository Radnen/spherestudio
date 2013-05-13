using System.IO;

// This contains game project related stuff //
namespace Sphere.Core.Settings
{
    /// <summary>
    /// The settings that describe a sphere game.
    /// </summary>
    public class ProjectSettings : GenSettings
    {
        /// <summary>
        /// Gets or sets the width of the Sphere game window.
        /// </summary>
        public string Width
        {
            get { return GetString("screen_width"); }
            set { SetItem("screen_width", value); }
        }

        /// <summary>
        /// Gets or sets the height of the Sphere game window.
        /// </summary>
        public string Height
        {
            get { return GetString("screen_height"); }
            set { SetItem("screen_height", value); }
        }

        /// <summary>
        /// Gets or sets the name of this Sphere game.
        /// </summary>
        public string Name
        {
            get { return GetString("name"); }
            set { SetItem("name", value); }
        }

        /// <summary>
        /// Gets or sets the author of this Sphere game.
        /// </summary>
        public string Author
        {
            get { return GetString("author"); }
            set { SetItem("author", value); }
        }

        /// <summary>
        /// Gets or sets the description of this Sphere game.
        /// </summary>
        public string Description
        {
            get { return GetString("description"); }
            set { SetItem("description", value); }
        }

        /// <summary>
        /// Gets or sets the starting script for this Sphere game.
        /// </summary>
        public string Script
        {
            get { return GetString("script"); }
            set { SetItem("script", value); }
        }

        /// <summary>
        /// Saves the settings to the \RootPath\ + 'game.sgm'
        /// </summary>
        public void SaveSettings()
        {
            SaveSettings(string.Format("{0}\\game.sgm", RootPath));
        }

        /// <summary>
        /// Creates the default setup used by a Sphere game.
        /// </summary>
        public void Create()
        {
            // Create The Main Folder //
            var gameDir = new DirectoryInfo(RootPath);
            gameDir.Create();

            // Create the Sub-folders //
            string[] subfolders = { "animations", "fonts", "images", "maps", "scripts", "sounds", "spritesets", "windowstyles" };
            foreach (string folder in subfolders)
            {
                var subfolder = new DirectoryInfo(RootPath + "\\" + folder);
                subfolder.Create();
            }
        }

        /// <summary>
        /// Sets the rootpath of this game project.
        /// </summary>
        /// <param name="path">Path to the directory of the game.sgm file.</param>
        public void SetRootPath(string path)
        {
            RootPath = path;
        }
    }
}
