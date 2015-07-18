using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Core;
using Sphere.Plugins;

namespace SphereStudio.Settings
{
    class UserSettings : INISettings
    {
        public UserSettings(string filepath):
            base(new INI(filepath, false), "User")
        {

        }

        /// <summary>
        /// Identifies the author of this file.
        /// </summary>
        public string Author
        {
            get { return GetString("author", ""); }
            set { SetValue("author", value); }
        }

        /// <summary>
        /// Identifies the project name this file belongs to.
        /// </summary>
        public string ProjectName
        {
            get { return GetString("projectName", ""); }
            set { SetValue("projectName", value); }
        }

        /// <summary>
        /// Stores as a comma-separated list the opened files in the editor.
        /// </summary>
        public string[] Documents
        {
            get { return GetStringArray("openDocuments"); }
            set { SetValue("openDocuments", value); }
        }

        /// <summary>
        /// Gets or sets the filepath of the last opened document you viewed.
        /// </summary>
        public string CurrentDocument
        {
            get { return GetString("currentDocument", ""); }
            set { SetValue("currentDocument", value); }
        }

        /// <summary>
        /// Gets or sets if the start menu is hidden for this user.
        /// </summary>
        public bool StartHidden
        {
            get { return GetBoolean("hideStart", false); }
            set { SetValue("hideStart", value); }
        }

    }
}
