using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sphere.Core.Settings
{
    /// <summary>
    /// A general abstraction for INI-like settings documents
    /// </summary>
    public abstract class GenSettings
    {
        private readonly SortedList<string, string> _items = new SortedList<string, string>();

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
            return _items.ContainsKey(key) ? _items[key] : string.Empty;
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
            return val == string.Empty ? fail : bool.Parse(val);
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
            return val == string.Empty ? 0 : int.Parse(val);
        }

        /// <summary>
        /// Adds the value to the settings object.
        /// </summary>
        /// <typeparam name="T">The type to store.</typeparam>
        /// <param name="key">The key to store object at.</param>
        /// <param name="item">The object to store.</param>
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
            var builder = new System.Text.StringBuilder();
            foreach (string s in items) builder.Append(s).Append(',');
            if (builder.Length > 0) builder.Remove(builder.Length - 1, 1);
            SetItem(key, builder.ToString());
        }

        /// <summary>
        /// Used to get an array of string elements.
        /// </summary>
        /// <param name="key">The key to load from.</param>
        /// <returns>An array of zero or more string elements.</returns>
        public string[] GetArray(string key)
        {
            var s = GetString(key);
            return !string.IsNullOrEmpty(s) ? s.Split(',') : new string[0];
        }

        /// <summary>
        /// Sets these settings to that of another settings list.
        /// </summary>
        /// <param name="settings">The settings object to merge with.</param>
        public void SetSettings(GenSettings settings)
        {
            RootPath = settings.RootPath;
            foreach (var pair in settings._items.Where(pair => pair.Value != null))
                if (pair.Value != null) _items[pair.Key] = pair.Value;
        }

        /// <summary>
        /// Creates a copy of these settings.
        /// </summary>
        /// <param name="settings">The settings to copy.</param>
        /// <returns></returns>
        protected GenSettings Clone(GenSettings settings)
        {
            foreach (var pair in _items)
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
            using (var settings = new StreamWriter(path))
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

        /// <summary>
        /// Loads the settings file.
        /// </summary>
        /// <param name="path">The path to read from.</param>
        /// <returns>True if successful.</returns>
        public bool LoadSettings(string path)
        {
            var editorIni = new FileInfo(path);
            if (!editorIni.Exists) return false;
            using (var settings = editorIni.OpenText())
            {
                RootPath = Path.GetDirectoryName(path);
                while (!settings.EndOfStream)
                {
                    var readLine = settings.ReadLine();
                    if (readLine == null) continue;
                    var lines = readLine.Split(new[] { '=' }, 2);
                    if (lines.Length > 1) _items[lines[0]] = lines[1];
                }
                return true;
            }
        }

    }
}
