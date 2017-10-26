using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

using SphereStudio;
using SphereStudio.Ide.Utility;
using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Ide
{
    static class Core
    {
        static Core()
        {
            var homeDirPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Sphere Studio");
            var programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var iniPath = Path.Combine(homeDirPath, "Settings", "Sphere Studio.ini");

            MainIniFile = new IniFile(iniPath);
            Settings = new CoreSettings(Core.MainIniFile);

            // load plugin modules (user-installed plugins first)
            Plugins = new Dictionary<string, PluginShim>();
            string[] searchPaths = {
                Path.Combine(homeDirPath, "Plugins"),
                Path.Combine(programDataPath, "Sphere Studio", "Plugins"),
                Path.Combine(Application.StartupPath, "Plugins"),
            };
            foreach (string path in
                from path in searchPaths
                where Directory.Exists(path)
                select path)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (FileInfo file in dir.GetFiles("*.dll")) {
                    string handle = Path.GetFileNameWithoutExtension(file.Name);
                    if (!Plugins.Keys.Contains(handle))  // only the first by that name is used
                        try {
                            Plugins[handle] = new PluginShim(file.FullName, handle);
                        }
                        catch (Exception e) {
                            MessageBox.Show(
                                $"Sphere Studio was unable to load the plugin file {file.FullName}.\n\nThe error encountered was:\n{e.Message}",
                                "Couldn't Load Plugin Module", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

    class CoreSettings : IniSettings, ICoreSettings
    {
        public CoreSettings(IniFile ini) :
            base(ini, "Sphere Studio")
        {
            Preset = GetString("preset", "");
        }

        public bool AutoHideBuild
        {
            get { return GetBoolean("autoHideBuild", false); }
            set { SetValue("autoHideBuild", value); }
        }

        public string[] HiddenPanes
        {
            get { return GetStringArray("hiddenPanes", new string[0]); }
            set { SetValue("hiddenPanes", value); }
        }

        public string[] AutoHidePanes
        {
            get { return GetStringArray("autoHidePanes", new string[0]); }
            set { SetValue("autoHidePanes", value); }
        }

        public bool AutoOpenLastProject
        {
            get { return GetBoolean("autoOpenProject", false); }
            set { SetValue("autoOpenProject", value); }
        }

        public bool UseScriptHeaders
        {
            get { return GetBoolean("useScriptHeaders", false); }
            set { SetValue("useScriptHeaders", value); }
        }

        public bool UseStartPage
        {
            get { return GetBoolean("autoStartPage", true); }
            set { SetValue("autoStartPage", value); }
        }

        public string Engine
        {
            get { return GetString("defaultEngine", ""); }
            set { Preset = null; SetValue("defaultEngine", value); }
        }

        public string Compiler
        {
            get { return GetString("defaultCompiler", ""); }
            set { Preset = null; SetValue("defaultCompiler", value); }
        }

        public string FileOpener
        {
            get { return GetString("defaultFileOpener", ""); }
            set { Preset = null; SetValue("defaultFileOpener", value); }
        }

        public string ImageEditor
        {
            get { return GetString("imageEditor", ""); }
            set { Preset = null; SetValue("imageEditor", value); }
        }

        public string ScriptEditor
        {
            get { return GetString("scriptEditor", ""); }
            set { Preset = null; SetValue("scriptEditor", value); }
        }

        public string LastProject
        {
            get { return GetString("lastProject", ""); }
            set { SetValue("lastProject", value); }
        }

        public string[] DisabledPlugins
        {
            get { return GetStringArray("disabledPlugins", new string[0]); }
            set { Preset = ""; SetValue("disabledPlugins", value); }
        }

        public string Preset
        {
            get
            {
                string value = GetString("preset", "");
                return string.IsNullOrWhiteSpace(value) ? null : value;
            }
            set
            {
                string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Sphere Studio");
                string path = Path.Combine(sphereDir, @"Presets", value + ".preset");
                if (!string.IsNullOrWhiteSpace(value) && File.Exists(path)) {
                    using (IniFile preset = new IniFile(path, false)) {
                        Compiler = preset.Read("Preset", "compiler", "");
                        Engine = preset.Read("Preset", "engine", "");
                        FileOpener = preset.Read("Preset", "defaultFileOpener", "");
                        ImageEditor = preset.Read("Preset", "imageEditor", "");
                        ScriptEditor = preset.Read("Preset", "scriptEditor", "");
                        DisabledPlugins = preset.Read("Preset", "disabledPlugins", "").Split('|');
                    }
                    SetValue("preset", value);
                }
                else {
                    SetValue("preset", "");
                }
            }
        }

        public string[] ProjectPaths
        {
            get
            {
                return GetStringArray("gamePaths", new string[0]);
            }
            set { SetValue("gamePaths", value); }
        }

        public View StartPageView
        {
            get
            {
                string val = GetString("startView", "Tile");
                return (View)Enum.Parse(typeof(View), val);
            }
            set
            {
                SetValue("startView", value);
            }
        }

        public string StyleName
        {
            get { return GetString("uiStyle", Program.DefaultStyle); }
            set { SetValue("uiStyle", value); }
        }

        public UIStyle UIStyle
        {
            get
            {
                var styles = from name in PluginManager.GetNames<IStyleProvider>()
                             let plugin = PluginManager.Get<IStyleProvider>(name)
                             from style in plugin.Styles
                             select new {
                                 Name = name + ": " + style.Name,
                                 Style = style
                             };
                var uiStyle = styles.Where(it => it.Name == StyleName).Select(it => it.Style).FirstOrDefault();
                if (uiStyle == null)
                    uiStyle = styles.Where(it => it.Name == Program.DefaultStyle).Select(it => it.Style).FirstOrDefault();
                return uiStyle;
            }
        }

        public void Apply()
        {
            foreach (var plugin in Core.Plugins)
                plugin.Value.Enabled = !DisabledPlugins.Contains(plugin.Key);
            PluginManager.Core.Docking.Refresh();
            if (UIStyle != null && StyleManager.Style != UIStyle)
                StyleManager.Style = UIStyle;
        }
    }
}
