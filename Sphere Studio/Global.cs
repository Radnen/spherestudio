using Sphere.Core.Settings;
using Sphere.Plugins;
using SphereStudio.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SphereStudio
{
    internal static class Global
    {
        public static Dictionary<string, PluginWrapper> Plugins = new Dictionary<string, PluginWrapper>();

        public static void EvalPlugins()
        {
            string path = Application.StartupPath + "/plugins";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
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
                        if (name != null) Plugins[name] = new PluginWrapper(b, name);
                    }
                }
            }
        }

        public static void ActivatePlugins(string[] pluginNames)
        {
            foreach (string s in pluginNames)
            {
                if (Plugins.ContainsKey(s)) Plugins[s].Activate();
            }
        }

        public static ProjectSettings CurrentProject = null;
        public static SphereSettings CurrentEditor = new SphereSettings();
        public static Sphere.Core.Entity CopiedEnt { get; set; }

        // Extention checking functions. Globally useable. :)
        public static bool IsScript(ref string name)
        {
            return name.ToLower().EndsWith(".js");
        }

        public static bool IsSound(ref string name)
        {
            string test = Path.GetExtension(name).ToLower();
            return (test == ".mod" || test == ".xm" || test == ".it" ||
                    test == ".mp3" || test == ".ogg" || test == ".wav" ||
                    test == ".s3m");
        }

        public static bool IsImage(ref string name)
        {
            string test = Path.GetExtension(name).ToLower();
            return (test == ".png" || test == ".gif" || test == ".tga" ||
                    test == ".jpg" || test == ".bmp");
        }

        public static bool IsSpriteset(ref string name)
        {
            return name.ToLower().EndsWith(".rss");
        }

        public static bool IsWindowStyle(ref string name)
        {
            return name.ToLower().EndsWith(".rws");
        }

        public static bool IsFont(ref string name)
        {
            return name.EndsWith(".rfn");
        }

        public static bool IsMap(ref string name)
        {
            return name.EndsWith(".rmp");
        }

        public static bool IsTileset(ref string name)
        {
            return name.EndsWith(".rts");
        }

        public static bool IsText(ref string name)
        {
            string test = Path.GetExtension(name).ToLower();
            return (test == ".txt" || test == ".sav" || test == ".sgm" ||
                    test == ".rtf" || test == ".dat" || test == ".ini");
        }

        // returns true if settings were altered
        public static bool EditSettings(IDEForm parent)
        {
            EditorSettings settings = new EditorSettings(CurrentEditor);
            settings.MainIDE = parent;
            if (settings.ShowDialog() == DialogResult.OK)
            {
                CurrentEditor.SetSettings(settings.GetSettings());
                return true;
            }
            return false;
        }
    }
}
