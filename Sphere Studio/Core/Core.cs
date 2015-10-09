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
    internal static class Core
    {
        /// <summary>
        /// Gets a list of all plugins found by the editor.
        /// </summary>
        public static Dictionary<string, PluginShim> Plugins = new Dictionary<string, PluginShim>();

        /// <summary>
        /// Refreshes the plugin list by observing the /plugins sub-directory.
        /// </summary>
        static Core()
        {
            // load the main .ini file (Sphere Studio.ini)
            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Sphere Studio");
            string iniPath = Path.Combine(sphereDir, "Settings", "Sphere Studio.ini");
            MainIniFile = new IniFile(iniPath);
            
            // load plugins (user-installed plugins first)
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

        public static IniFile MainIniFile;
        public static Project Project = null;
        public static CoreSettings Settings;

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
