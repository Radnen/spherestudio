using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

using SphereStudio.Forms;
using SphereStudio.Settings;
using SphereStudio.UI;
using Sphere.Core;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio
{
    static class Core
    {
        static Core()
        {
            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Sphere Studio");
            string iniPath = Path.Combine(sphereDir, "Settings", "Sphere Studio.ini");
            MainIniFile = new IniFile(iniPath);
            Settings = new CoreSettings(Core.MainIniFile);

            // load plugin modules (user-installed plugins first)
            Plugins = new Dictionary<string, PluginShim>();
            string[] paths =
            {
                Path.Combine(sphereDir, "Plugins"),
                Path.Combine(Application.StartupPath, "Plugins")
            };
            foreach (string path in
                from path in paths
                where Directory.Exists(path)
                select path)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (FileInfo file in dir.GetFiles("*.dll"))
                {
                    string handle = Path.GetFileNameWithoutExtension(file.Name);
                    if (!Plugins.Keys.Contains(handle))  // only the first by that name is used
                        Plugins[handle] = new PluginShim(file.FullName, handle);
                }
            }
        }

        /// <summary>
        /// Grants access to the main .ini file (Sphere Studio.ini).
        /// </summary>
        public static IniFile MainIniFile { get; private set; }

        /// <summary>
        /// Gets or sets the currently loaded project.
        /// </summary>
        public static Project Project { get; set; }

        /// <summary>
        /// Grants access to the Sphere Studio core configuration.
        /// </summary>
        public static CoreSettings Settings { get; private set; }

        /// <summary>
        /// Gets the list of loaded plugins.
        /// </summary>
        public static Dictionary<string, PluginShim> Plugins { get; private set; }

        /// <summary>
        /// Gets the registered name of the IFileOpener handling a specified filename.
        /// </summary>
        /// <param name="fileName">The filename to find a file opener for.</param>
        /// <returns>The registered name of the correct file opener, or null if none was found.</returns>
        public static string GetFileOpenerName(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);
            if (fileExtension.StartsWith("."))  // remove dot from extension
                fileExtension = fileExtension.Substring(1);

            var names = from name in PluginManager.GetNames<IFileOpener>()
                        let plugin = PluginManager.Get<IFileOpener>(name)
                        where plugin.FileExtensions.Contains(fileExtension)
                        select name;
            return names.FirstOrDefault();
        }
    }
}
