using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Sphere_Editor.Utility;

// This Contains the Settings Dialogue Info
// As well as any other Sphere Editor related
// Information.
namespace Sphere_Editor.Settings
{
    public class SphereSettings : GenSettings
    {
        public string SpherePath
        {
            get { return GetString("sphere_path"); }
            set { SetItem<string>("sphere_path", value); }
        }

        public string ConfigPath
        {
            get { return GetString("config_path"); }
            set { SetItem<string>("config_path", value); }
        }

        public string LastProjectPath
        {
            get { return GetString("last_project_path"); }
            set { SetItem<string>("last_project_path", value); }
        }

        public bool UseSplash
        {
            get { return GetBool("use_splash"); }
            set { SetItem<bool>("use_splash", value); }
        }

        public bool UseScriptUpdate
        {
            get { return GetBool("use_script_update"); }
            set { SetItem<bool>("use_script_update", value); }
        }

        public bool ShowAutoComplete
        {
            get { return GetBool("show_auto_c"); }
            set { SetItem<bool>("show_auto_c", value); }
        }

        public View StartView
        {
            get
            {
                string val = GetString("start_view");
                if (val == string.Empty) return View.Tile;
                else return (View)Enum.Parse(typeof(View), val);
            }
            set { SetItem<View>("start_view", value); }
        }

        public bool AutoOpen
        {
            get { return GetBool("auto_open_project"); }
            set { SetItem<bool>("auto_open_project", value); }
        }

        public bool ShowDelay
        {
            get { return GetBool("show_delay"); }
            set { SetItem<bool>("show_delay", value); }
        }

        public string LabelFont
        {
            get
            {
                string k = GetString("label_font");
                if (k == string.Empty) return "Verdana";
                else return k;
            }
            set { SetItem<string>("label_font", value); }
        }

        // this will set it's settings from the controls of a dialog window.
        public void SetSettings(EditorSettings SettingForm)
        {
            SpherePath = SettingForm.SpherePath;
            SetGamePaths(SettingForm.GamePaths);
            SetPluginList();
            ConfigPath = SettingForm.ConfigPath;
            AutoOpen = SettingForm.AutoStart;
            UseScriptUpdate = SettingForm.UseScriptUpdate;
            LabelFont = SettingForm.LabelFont;
        }

        private void SetGamePaths(string[] list)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (string o in list) builder.Append(o).Append(',');
            if (builder.Length > 0) builder.Remove(builder.Length - 1, 1);
            SetItem<string>("games_path", builder.ToString());
        }

        private void SetPluginList()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (KeyValuePair<string, PluginWrapper> item in Global.plugins)
                if (item.Value.Enabled) builder.Append(item.Value.Name).Append(',');
            if (builder.Length > 0) builder.Remove(builder.Length - 1, 1);
            SetItem<string>("plugins", builder.ToString());
        }

        public string[] GetGamePaths()
        {
            string s = GetString("games_path");
            if (!string.IsNullOrEmpty(s)) return s.Split(',');
            else return new string[0];
        }

        public string[] GetPluginList()
        {
            string s = GetString("plugins");
            if (!string.IsNullOrEmpty(s)) return s.Split(',');
            else return new string[0];
        }

        /// <summary>
        /// Saves to default editor.ini location.
        /// </summary>
        public void SaveSettings()
        {
            SaveSettings(Application.StartupPath + "\\editor.ini");
        }

        /// <summary>
        /// Reads from default editor.ini location.
        /// </summary>
        public bool LoadSettings()
        {
            return LoadSettings(Application.StartupPath + "\\editor.ini");
        }

        /// <summary>
        /// Creates a clone of these editor settings.
        /// </summary>
        /// <returns></returns>
        public SphereSettings Clone()
        {
            return (SphereSettings)Clone(new SphereSettings());
        }
    }
}
