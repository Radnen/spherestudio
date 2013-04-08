using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Sphere_Editor.Settings
{
    public class GenSettings
    {
        private SortedList<string, string> items = new SortedList<string, string>();

        public string RootPath { get; set; }

        protected string GetString(string key)
        {
            if (items.ContainsKey(key)) return items[key];
            else return string.Empty;
        }

        protected bool GetBool(string key)
        {
            string val = GetString(key);
            if (val == string.Empty) return false;
            else return bool.Parse(val);
        }

        protected int GetInt(string key)
        {
            string val = GetString(key);
            if (val == string.Empty) return 0;
            else return int.Parse(val);
        }

        protected void SetItem<T>(string key, T item)
        {
            items[key] = item.ToString();
        }

        public virtual void SaveSettings(string path)
        {
            using (StreamWriter settings = new StreamWriter(path))
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    string key = items.Keys[i];
                    settings.WriteLine(key + "=" + items[key]);
                }
                settings.Flush();
            }
        }

        // loads the editor settings such as sphere engine path or config path.
        // essentially this will allow the editor to be used from anywhere on the os.
        public bool LoadSettings(string path)
        {
            FileInfo editorINI = new FileInfo(path);
            if (!editorINI.Exists) return false;
            using (StreamReader settings = editorINI.OpenText())
            {
                RootPath = Path.GetDirectoryName(path);
                while (!settings.EndOfStream)
                {
                    string[] lines = settings.ReadLine().Split('=');
                    if (lines.Length > 1) items[lines[0]] = lines[1];
                }
                return true;
            }
        }

    }
}
