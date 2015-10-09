using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Core;
using Sphere.Core.Editor;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.Settings
{
    class CoreSettings : INISettings, ICoreSettings
    {
        public CoreSettings(IniFile ini):
            base(ini, "Sphere Studio")
        {
            Preset = GetString("preset", "");
        }

        public bool AutoHideBuild
        {
            get { return GetBoolean("autoHideBuild", false); }
            set { SetValue("autoHideBuild", value); }
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

        public string Compiler
        {
            get { return GetString("compiler", ""); }
            set { Preset = null; SetValue("compiler", value); }
        }

        public string Engine
        {
            get { return GetString("engine", ""); }
            set { Preset = null; SetValue("engine", value); }
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

        public string[] Plugins
        {
            get { return GetStringArray("plugins"); }
            set { Preset = ""; SetValue("plugins", value); }
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
                if (!string.IsNullOrWhiteSpace(value) && File.Exists(path))
                {
                    using (IniFile preset = new IniFile(path, false))
                    {
                        Compiler = preset.Read("Preset", "compiler", "");
                        Engine = preset.Read("Preset", "engine", "");
                        FileOpener = preset.Read("Preset", "defaultFileOpener", "");
                        ImageEditor = preset.Read("Preset", "imageEditor", "");
                        ScriptEditor = preset.Read("Preset", "scriptEditor", "");
                        Plugins = preset.Read("Preset", "plugins", "").Split('|');
                    }
                    SetValue("preset", value);
                }
                else
                {
                    SetValue("preset", "");
                }
            }
        }

        public string[] ProjectPaths
        {
            get { return GetStringArray("gamePaths"); }
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

        public string UIStyle
        {
            get { return GetString("uiStyle", "Dark"); }
            set { SetValue("uiStyle", value); }
        }

        public void Apply()
        {
            StyleSettings.CurrentStyle = UIStyle;
            foreach (var plugin in Core.Plugins)
                plugin.Value.Enabled = Plugins.Contains(plugin.Key);
            PluginManager.Core.Docking.Refresh();
        }
    }
}
