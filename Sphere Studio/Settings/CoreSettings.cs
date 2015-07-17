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

namespace SphereStudio.Settings
{
    class CoreSettings : INISettings
    {
        public CoreSettings(INI ini):
            base(ini, "Sphere Studio")
        {
            Preset = GetString("preset", "");
        }
        
        public bool AutoOpenProject
        {
            get { return GetBoolean("autoOpenProject", false); }
            set { SetValue("autoOpenProject", value); }
        }

        public bool AutoScriptHeader
        {
            get { return GetBoolean("autoScriptHeader", false); }
            set { SetValue("autoScriptHeader", value); }
        }

        public bool AutoStartPage
        {
            get { return GetBoolean("autoStartPage", true); }
            set { SetValue("autoStartPage", value); }
        }

        public string DefaultEditor
        {
            get {
                string value = GetString("defaultEditor", "");
                return string.IsNullOrWhiteSpace(value) ? null : value;
            }
            set
            {
                Preset = null;
                SetValue("defaultEditor", value ?? "");
            }
        }

        public string EngineConfigPath
        {
            get { return GetString("engineConfigPath", ""); }
            set { Preset = null; SetValue("engineConfigPath", value); }
        }
        
        public string EnginePath
        {
            get { return GetString("enginePath", ""); }
            set { Preset = null; SetValue("enginePath", value); }
        }
        
        public string EnginePath64
        {
            get { return GetString("enginePath64", ""); }
            set { Preset = null; SetValue("enginePath64", value); }
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
                    using (INI preset = new INI(path, false))
                    {
                        EngineConfigPath = preset.Read("Preset", "engineConfigPath", "");
                        EnginePath = preset.Read("Preset", "enginePath", "");
                        EnginePath64 = preset.Read("Preset", "enginePath64", "");
                        DefaultEditor = preset.Read("Preset", "defaultEditor", "");
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

        public string TestPlatform
        {
            get { return GetString("testPlatform", Environment.Is64BitOperatingSystem ? "x64" : "x86"); }
            set { SetValue("testPlatform", value); }
        }

        public string UIStyle
        {
            get { return GetString("uiStyle", "Dark"); }
            set { SetValue("uiStyle", value); }
        }

        public void Apply()
        {
            StyleSettings.CurrentStyle = UIStyle;
            foreach (var plugin in Global.Plugins)
            {
                if (Plugins.Contains(plugin.Key))
                    plugin.Value.Activate();
                else
                    plugin.Value.Deactivate();
            }
        }
    }
}
