using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

// This Contains the Settings Dialogue Info
// As well as any other Sphere Editor related
// Information.
namespace Sphere_Editor.Settings
{
    public class SphereSettings
    {
        SortedList<string, string> items = new SortedList<string, string>();

        private string GetKeyData(string key)
        {
            if (items.ContainsKey(key)) return items[key];
            else return string.Empty;
        }

        private bool GetBool(string key)
        {
            string val = GetKeyData(key);
            if (val == string.Empty) return false;
            else return bool.Parse(val);
        }

        public string SpherePath
        {
            get { return GetKeyData("sphere_path"); }
            set { items["sphere_path"] = value; }
        }

        public string GamesPath
        {
            get { return GetKeyData("games_path"); }
            set { items["games_path"] = value; }
        }

        public string ConfigPath
        {
            get { return GetKeyData("config_path"); }
            set { items["config_path"] = value; }
        }

        public string LastProjectPath
        {
            get { return GetKeyData("last_project_path"); }
            set { items["last_project_path"] = value; }
        }

        public bool UseDockForm
        {
            get { return GetBool("use_docking"); }
            set { items["use_docking"] = value.ToString(); }
        }

        public bool UseSplash
        {
            get { return GetBool("use_splash"); }
            set { items["use_splash"] = value.ToString(); }
        }

        public bool UseScriptUpdate
        {
            get { return GetBool("use_script_update"); }
            set { items["use_script_update"] = value.ToString(); }
        }

        public bool ShowAutoComplete
        {
            get { return GetBool("show_auto_c"); }
            set { items["show_auto_c"] = value.ToString(); }
        }

        public View StartView
        {
            get
            {
                string val = GetKeyData("start_view");
                if (val == string.Empty) return View.Tile;
                else return (View)Enum.Parse(typeof(View), val);
            }
            set { items["start_view"] = value.ToString(); }
        }

        public bool AutoOpen
        {
            get { return GetBool("auto_open_project"); }
            set { items["auto_open_project"] = value.ToString(); }
        }

        public bool ShowDelay
        {
            get { return GetBool("show_delay"); }
            set { items["show_delay"] = value.ToString(); }
        }

        public string LabelFont
        {
            get
            {
                string k = GetKeyData("label_font");
                if (k == string.Empty) return "Verdana";
                else return k;
            }
            set { items["label_font"] = value; }
        }

        // this will set it's settings from the controls of a dialog window.
        public void SetSettings(EditorSettings SettingForm)
        {
            SpherePath = SettingForm.SpherePath;
            GamesPath = SettingForm.GamePath;
            ConfigPath = SettingForm.ConfigPath;
            UseDockForm = SettingForm.UseDockForm;
            AutoOpen = SettingForm.AutoStart;
            UseScriptUpdate = SettingForm.UseScriptUpdate;
            LabelFont = SettingForm.LabelFont;
        }

        // store the editor settings to an editor.ini file.
        public void SaveSettings()
        {
            StreamWriter settings = new StreamWriter(Application.StartupPath+"\\editor.ini");
            for (int i = 0; i < items.Count; ++i)
            {
                string key = items.Keys[i];
                settings.WriteLine(key + "=" + items[key]);
            }
            settings.Flush();
            settings.Close();
        }

        // loads the editor settings such as sphere engine path or config path.
        // essentially this will allow the editor to be used from anywhere on the os.
        public bool LoadSettings()
        {
            FileInfo editorINI = new FileInfo(Application.StartupPath + "\\editor.ini");
            if (!editorINI.Exists) return false;
            StreamReader settings = editorINI.OpenText();
            while (!settings.EndOfStream)
            {
                string[] lines = settings.ReadLine().Split('=');
                items[lines[0]] = lines[1];
            }
            settings.Close();
            return true;
        }

        // returns text to load into an API Textbox.
        public string LoadAPI()
        {
            FileInfo apitxt = new FileInfo(Application.StartupPath + "\\docs\\api.txt");
            if (!apitxt.Exists) return "";
            StreamReader text = apitxt.OpenText();
            string Text = text.ReadToEnd();
            text.Close();
            return Text;
        }
    }
}
