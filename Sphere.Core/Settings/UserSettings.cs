using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Core.Settings
{
    public class UserSettings : GenSettings
    {
        /// <summary>
        /// Identifies the author of this file.
        /// </summary>
        public string Author
        {
            get { return GetString("author"); }
            set { SetItem("author", value); }
        }

        /// <summary>
        /// Identifies the project name this file belongs to.
        /// </summary>
        public string ProjectName
        {
            get { return GetString("project_name"); }
            set { SetItem("project_name", value); }
        }

        /// <summary>
        /// Stores as a comma-separated list the opened files in the editor.
        /// </summary>
        public string[] Documents
        {
            get
            {
                string docs = GetString("documents");
                return docs.Split(',');
            }
            set { SetItem("documents", String.Join(",", value)); }
        }

        /// <summary>
        /// Gets or sets the filepath of the last opened document you viewed.
        /// </summary>
        public string CurrentDocument
        {
            get { return GetString("current_document"); }
            set { SetItem("current_document", value); }
        }

        /// <summary>
        /// Gets or sets if the start menu is hidden for this user.
        /// </summary>
        public bool StartHidden
        {
            get { return GetBool("start_hidden"); }
            set { SetItem("start_hidden", value); }
        }

        /// <summary>
        /// Saves with default name to project's root directory.
        /// </summary>
        /// <param name="project_path">Project's root directory.</param>
        public void SaveSettings(string project_path)
        {
            SaveSettings(Path.Combine(project_path, ".ssuser"), false);
        }

        public override bool LoadSettings(string path)
        {
            return base.LoadSettings(Path.Combine(path, ".ssuser"));
        }
    }
}
