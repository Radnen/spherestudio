using Sphere.Core.Settings;
using Sphere.Plugins;
using SphereStudio.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

using SphereStudio.Settings;

namespace SphereStudio
{
    internal static class Global
    {
        /// <summary>
        /// Gets a list of all plugins found by the editor.
        /// </summary>
        public static Dictionary<string, PluginWrapper> Plugins = new Dictionary<string, PluginWrapper>();

        /// <summary>
        /// Refreshes the plugin list by observing the /plugins sub-directory.
        /// </summary>
        public static void EvalPlugins()
        {
            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
            
            // don't rearrange, we want to load user plugins first
            string[] paths = { Path.Combine(sphereDir, "Plugins"), Path.Combine(Application.StartupPath, "Plugins") };

            foreach (string path in
                from path in paths
                where Directory.Exists(path)
                select path)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (FileInfo file in dir.GetFiles("*.dll"))
                {
                    Assembly assembly = Assembly.LoadFrom(file.FullName);
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.GetInterface("IPlugin") != null)
                        {
                            IPlugin b = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null) as IPlugin;
                            if (b == null) continue;
                            string name = Path.GetFileNameWithoutExtension(file.Name);
                            if (name != null && !Plugins.Keys.Contains(name))  // only the first by that name is used
                                Plugins[name] = new PluginWrapper(b, name);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Activates plugins mentioned in the array.
        /// </summary>
        /// <param name="plugins">An array of plugin names to activate.</param>
        public static void ActivatePlugins(string[] plugins)
        {
            PluginWrapper wrapper;

            foreach (string s in plugins)
                if (Plugins.TryGetValue(s, out wrapper))
                    wrapper.Activate();
        }

        public static ProjectSettings CurrentProject = null;
        public static UserSettings CurrentUser = null;
        public static CoreSettings Settings = new CoreSettings();
        public static Sphere.Core.Entity CopiedEnt { get; set; }

        /// <summary>
        /// Checks to see if filename is a script.
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>True if a script file.</returns>
        public static bool IsScript(ref string name)
        {
            return name.ToLower().EndsWith(".js");
        }

        /// <summary>
        /// Checks to see if filename is a sound.
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>True if a sound file.</returns>
        public static bool IsSound(ref string name)
        {
            string test = Path.GetExtension(name).ToLower();
            return (test == ".mod" || test == ".xm" || test == ".it" ||
                    test == ".mp3" || test == ".ogg" || test == ".wav" ||
                    test == ".s3m");
        }

        /// <summary>
        /// Checks to see if filename is an image.
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>True if an image file.</returns>
        public static bool IsImage(ref string name)
        {
            string test = Path.GetExtension(name).ToLower();
            return (test == ".png" || test == ".gif" || test == ".tga" ||
                    test == ".jpg" || test == ".bmp");
        }

        /// <summary>
        /// Checks to see if filename is a spriteset.
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>True if a spriteset file.</returns>
        public static bool IsSpriteset(ref string name)
        {
            return name.ToLower().EndsWith(".rss");
        }

        /// <summary>
        /// Checks to see if filename is a windowstyle.
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>True if a windowstyle file.</returns>
        public static bool IsWindowStyle(ref string name)
        {
            return name.ToLower().EndsWith(".rws");
        }

        /// <summary>
        /// Checks to see if filename is a font.
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>True if a font file.</returns>
        public static bool IsFont(ref string name)
        {
            return name.EndsWith(".rfn");
        }

        /// <summary>
        /// Checks to see if filename is a map.
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>True if a map file.</returns>
        public static bool IsMap(ref string name)
        {
            return name.EndsWith(".rmp");
        }

        /// <summary>
        /// Checks to see if filename is a tileset.
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>True if a tileset file.</returns>
        public static bool IsTileset(ref string name)
        {
            return name.EndsWith(".rts");
        }

        /// <summary>
        /// Opens the editor settings dialog.
        /// </summary>
        /// <returns>Returns true if there were changes.</returns>
        public static bool EditSettings()
        {
            EditorSettings settings = new EditorSettings(Settings);
            return settings.ShowDialog() == DialogResult.OK;
        }
    }
}
