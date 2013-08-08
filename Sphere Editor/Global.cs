using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Sphere.Core.Settings;
using Sphere.Plugins;
using Sphere_Editor.Forms;

namespace Sphere_Editor
{
    public static class Global
    {
        public static Dictionary<string, PluginWrapper> Plugins = new Dictionary<string, PluginWrapper>();
        public static List<string> Functions = new List<string>();

        public static void EvalPlugins()
        {
            string path = Application.StartupPath + "/Plugins";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo file in dir.GetFiles("*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(file.FullName);
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetInterface("IPlugin") != null)
                    {
                        IPlugin b = type.InvokeMember(null,
                                                   BindingFlags.CreateInstance,
                                                   null, null, null) as IPlugin;
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

        public static void LoadFunctions()
        {
            FileInfo file = new FileInfo(Application.StartupPath + "/docs/functions.txt");
            if (!file.Exists) return;

            using (StreamReader reader = file.OpenText())
            {
                while (!reader.EndOfStream)
                    Functions.Add(reader.ReadLine());
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
            return name.ToLower().Contains(".rss");
        }

        public static bool IsWindowStyle(ref string name)
        {
            return name.ToLower().Contains(".rws");
        }

        public static bool IsFont(ref string name)
        {
            return name.Contains(".rfn");
        }

        public static bool IsMap(ref string name)
        {
            return name.Contains(".rmp");
        }

        public static bool IsTileset(ref string name)
        {
            return name.Contains(".rts");
        }

        public static bool IsText(ref string name)
        {
            string test = Path.GetExtension(name).ToLower();
            return (test == ".txt" || test == ".sav" || test == ".sgm" ||
                    test == ".rtf" || test == ".dat" || test == ".ini");
        }

        // returns true if settings were altered
        public static bool EditSettings()
        {
            EditorSettings settings = new EditorSettings(CurrentEditor);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                CurrentEditor.SetSettings(settings.GetSettings());
                return true;
            }
            return false;
        }
    }

    class TipLabel : Label
    {
        private bool _clear = true;

        protected override void OnCreateControl()
        {
            Image = Properties.Resources.resultset_next;
            Text = "Rollover an item to view help.";
            Font = new Font(Global.CurrentEditor.LabelFont, 7.75F);
            TextAlign = ContentAlignment.MiddleCenter;
            ImageAlign = ContentAlignment.MiddleLeft;
            AutoSize = false;
            Height = 21;
            BackColor = Color.Lavender;

            base.OnCreateControl();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Font = new Font(Global.CurrentEditor.LabelFont, 7.75F);
            base.OnPaint(e);
        }

        [Localizable(false)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (_clear)
                {
                    Image = Properties.Resources.information;
                    TextAlign = ContentAlignment.MiddleCenter;
                    _clear = false;
                }
                base.Text = value;
            }
        }

        public bool AlwaysShow { get; set; }

        public void Clear()
        {
            Image = Properties.Resources.resultset_next;
            TextAlign = ContentAlignment.MiddleCenter;
            Text = "Rollover an item to view help.";
            _clear = true;
        }
    }
}
