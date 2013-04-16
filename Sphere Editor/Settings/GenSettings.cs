using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Sphere_Editor.Settings
{
    public abstract class GenSettings
    {
        private SortedList<string, string> items = new SortedList<string, string>();

        public string RootPath { get; set; }

        /// <summary>
        /// Attempts to get the string stored at the key.
        /// </summary>
        /// <param name="key">The key to read from.</param>
        /// <returns>A string or string.Empty if it failed.</returns>
        public string GetString(string key)
        {
            if (items.ContainsKey(key)) return items[key];
            else return string.Empty;
        }

        /// <summary>
        /// Attempts to get a bool from the key.
        /// </summary>
        /// <param name="key">The value to read.</param>
        /// <param name="fail">The value to return if it failed.</param>
        /// <returns>The boolean stored at the key.</returns>
        public bool GetBool(string key, bool fail = false)
        {
            string val = GetString(key);
            if (val == string.Empty) return fail;
            else return bool.Parse(val);
        }

        /// <summary>
        /// Attempts to get an int from the key.
        /// </summary>
        /// <param name="key">The key to read from.</param>
        /// <param name="fail">The value to return if it failed.</param>
        /// <returns>The integer stored at the key.</returns>
        public int GetInt(string key, int fail = 0)
        {
            string val = GetString(key);
            if (val == string.Empty) return 0;
            else return int.Parse(val);
        }

        protected void SetItem<T>(string key, T item)
        {
            items[key] = item.ToString();
        }

        public void SetSettings(GenSettings settings)
        {
            foreach (KeyValuePair<string, string> pair in settings.items)
                items[pair.Key] = pair.Value;
        }

        protected GenSettings Clone(GenSettings settings)
        {
            foreach (KeyValuePair<string, string> pair in items)
                settings.items[pair.Key] = pair.Value;
            settings.RootPath = RootPath;
            return settings;
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

        /// <summary>
        /// Saves a custom value into the editor's ini file.
        /// </summary>
        /// <param name="key">The key to save to.</param>
        /// <param name="data">The data serialized as a string.</param>
        public void SaveObject(string key, object data)
        {
            items[key] = data.ToString();
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
                    string[] lines = settings.ReadLine().Split(new char[] { '=' }, 2);
                    if (lines.Length > 1) items[lines[0]] = lines[1];
                }
                return true;
            }
        }

    }
}
