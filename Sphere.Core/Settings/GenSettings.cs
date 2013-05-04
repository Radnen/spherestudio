using System.Collections.Generic;
using System.IO;

namespace Sphere.Core.Settings
{
    /// <summary>
    /// A general abstraction for INI-like settings documents
    /// </summary>
    public abstract class GenSettings
    {
        private SortedList<string, string> _items = new SortedList<string, string>();

        /// <summary>
        /// Gets the path where this settings file is stored.
        /// </summary>
        public virtual string RootPath { get; protected set; }

        /// <summary>
        /// Attempts to get the string stored at the key.
        /// </summary>
        /// <param name="key">The key to read from.</param>
        /// <returns>A string or string.Empty if it failed.</returns>
        public string GetString(string key)
        {
            if (_items.ContainsKey(key)) return _items[key];
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
            _items[key] = item.ToString();
        }

        /// <summary>
        /// Used to store a string array to a single key element.
        /// </summary>
        /// <param name="key">Key to store at.</param>
        /// <param name="items">The string array to store.</param>
        public void StoreArray(string key, IEnumerable<string> items)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (string s in items) builder.Append(s).Append(',');
            if (builder.Length > 0) builder.Remove(builder.Length - 1, 1);
            SetItem<string>(key, builder.ToString());
        }

        /// <summary>
        /// Used to get an array of string elements.
        /// </summary>
        /// <param name="key">The key to load from.</param>
        /// <returns>An array of zero or more string elements.</returns>
        public string[] GetArray(string key)
        {
            string s = GetString(key);
            if (!string.IsNullOrEmpty(s)) return s.Split(',');
            else return new string[0];
        }

        /// <summary>
        /// Sets these settings to that of another settings list.
        /// </summary>
        /// <param name="settings">The settings object to merge with.</param>
        public void SetSettings(GenSettings settings)
        {
            RootPath = settings.RootPath;
            foreach (KeyValuePair<string, string> pair in settings._items)
                _items[pair.Key] = pair.Value;
        }

        protected GenSettings Clone(GenSettings settings)
        {
            foreach (KeyValuePair<string, string> pair in _items)
                settings._items[pair.Key] = pair.Value;
            settings.RootPath = RootPath;
            return settings;
        }

        /// <summary>
        /// Saves these settings to file.
        /// </summary>
        /// <param name="path">Filepath to store the settings.</param>
        public virtual void SaveSettings(string path)
        {
            using (StreamWriter settings = new StreamWriter(path))
            {
                for (int i = 0; i < _items.Count; ++i)
                {
                    string key = _items.Keys[i];
                    settings.WriteLine(key + "=" + _items[key]);
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
            _items[key] = data.ToString();
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
                    if (lines.Length > 1) _items[lines[0]] = lines[1];
                }
                return true;
            }
        }

    }
}
