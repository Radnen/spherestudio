using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sphere.Core;

// This Contains the Settings Dialogue Info
// As well as any other Sphere Editor related
// Information.
namespace Sphere.Core.Settings
{
    /// <summary>
    /// A settings document representing the Sphere Studio Editor.
    /// </summary>
    public class SphereSettings : GenSettings
    {
        /// <summary>
        /// Gets or sets the Sphere engine.exe filepath.
        /// </summary>
        public string SpherePath
        {
            get { return GetString("sphere_path"); }
            set { SetItem<string>("sphere_path", value); }
        }

        /// <summary>
        /// Gets or sets the Sphere config.exe path.
        /// </summary>
        public string ConfigPath
        {
            get { return GetString("config_path"); }
            set { SetItem<string>("config_path", value); }
        }

        /// <summary>
        /// Gets or sets the path of the last loaded project.
        /// </summary>
        public string LastProjectPath
        {
            get { return GetString("last_project_path"); }
            set { SetItem<string>("last_project_path", value); }
        }

        /// <summary>
        /// Gets or sets whether or not to update script headers.
        /// </summary>
        public bool UseScriptUpdate
        {
            get { return GetBool("use_script_update"); }
            set { SetItem<bool>("use_script_update", value); }
        }

        /// <summary>
        /// Gets or sets whether or not to show script autocomplete.
        /// </summary>
        public bool ShowAutoComplete
        {
            get { return GetBool("show_auto_c"); }
            set { SetItem<bool>("show_auto_c", value); }
        }

        /// <summary>
        /// Gets or sets the start page's view.
        /// </summary>
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

        /// <summary>
        /// Gets or sets whether or not to automatically open the last opened project.
        /// </summary>
        public bool AutoOpen
        {
            get { return GetBool("auto_open_project"); }
            set { SetItem<bool>("auto_open_project", value); }
        }

        /// <summary>
        /// Gets or sets whether or not to show delay in the spriteset editor.
        /// </summary>
        public bool ShowDelay
        {
            get { return GetBool("show_delay"); }
            set { SetItem<bool>("show_delay", value); }
        }

        /// <summary>
        /// Gets or sets the font used in editor labels.
        /// </summary>
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
