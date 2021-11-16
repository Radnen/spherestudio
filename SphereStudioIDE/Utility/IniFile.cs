using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SphereStudio.Ide.Utility
{
    /// <summary>
    /// Represents an INI format settings file.
    /// </summary>
    public class IniFile : IDisposable
    {
        private string m_fileName;
        private Dictionary<string, Dictionary<string, string>> m_sections;

        /// <summary>
        /// Constructs an IniFile object referencing the specified .ini file.
        /// </summary>
        /// <param name="fileName">The fully qualified .ini file path.</param>
        /// <param name="autoSave">
        /// Whether to save the file automatically after a value is written. If this is false,
        /// Save() must be called to persist the changes.
        /// </param>
        public IniFile(string fileName, bool autoSave = true)
        {
            m_fileName = fileName;
            AutoSave = autoSave;

            m_sections = new Dictionary<string, Dictionary<string, string>>();
            m_sections.Add("", new Dictionary<string, string>());
            Dictionary<string, string> section = m_sections[""];
            if (File.Exists(m_fileName))
            {
                using (StreamReader file = File.OpenText(m_fileName))
                {
                    Regex sectionRegex = new Regex(@"^\[(.*)\]$");
                    Regex itemRegex = new Regex(@"^(.*)=(.*)$");
                    while (!file.EndOfStream)
                    {
                        string line = file.ReadLine().Trim();
                        var isSection = sectionRegex.Match(line);
                        var isItem = itemRegex.Match(line);
                        if (isSection.Success)
                        {
                            string name = isSection.Groups[1].Value;
                            if (!(m_sections.ContainsKey(name)))
                                m_sections.Add(name, new Dictionary<string, string>());
                            section = m_sections[name];
                        }
                        else if (isItem.Success)
                        {
                            string name = isItem.Groups[1].Value;
                            string value = isItem.Groups[2].Value;
                            section.Add(name, value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Releases any resources held by the INI object.
        /// </summary>
        public void Dispose()
        {
            // nothing to dispose at present.
        }

        /// <summary>
        /// Gets or sets whether to save the INI file automatically when a
        /// value is changed.
        /// </summary>
        public bool AutoSave { get; set; }

        /// <summary>
        /// Reads a string from the INI file.
        /// </summary>
        /// <param name="section">The [section] to read from.</param>
        /// <param name="key">The name of the setting to read.</param>
        /// <param name="defValue">A default string to return if the key isn't found.</param>
        /// <returns>The value read from the INI file, or `defValue` if the key doesn't exist.</returns>
        public string Read(string section, string key, string defValue)
        {
            if (m_sections.ContainsKey(section) && m_sections[section].ContainsKey(key))
                return m_sections[section][key];
            else
                return defValue;
        }
        
        /// <summary>
        /// Saves the current values to the INI file.
        /// </summary>
        /// <returns>true if the save succeeded, otherwise false.</returns>
        public bool Save()
        {
            return SaveAs(m_fileName);
        }

        /// <summary>
        /// Saves the current values to a specified INI file.
        /// </summary>
        /// <param name="filepath">The fully qualified path of the file to save.</param>
        /// <returns>true if the save succeeded, otherwise false.</returns>
        public bool SaveAs(string filepath)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));
                using (StreamWriter file = new StreamWriter(filepath))
                {
                    var sections = from section in m_sections
                                   where section.Value.Count > 0
                                   select section.Key;
                    foreach (string name in sections)
                    {
                        file.WriteLine(string.Format("[{0}]", name));
                        var itemNames = from itemName in m_sections[name].Keys
                                        orderby itemName ascending
                                        select itemName;
                        foreach (string itemName in itemNames)
                        {
                            file.WriteLine(string.Format("{0}={1}",
                                itemName,
                                m_sections[name][itemName]));
                        }
                        file.WriteLine();
                    }
                }
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        /// <summary>
        /// Writes a string to the INI file.
        /// </summary>
        /// <param name="section">The [section] to write.</param>
        /// <param name="key">The name of the setting to write.</param>
        /// <param name="value">The value of the setting.</param>
        public void Write(string section, string key, string value)
        {
            value = value ?? "";
            if (!m_sections.ContainsKey(section))
            {
                m_sections.Add(section, new Dictionary<string, string>());
            }
            m_sections[section][key] = value;
            if (AutoSave)
            {
                Save();
            }
        }
    }
}
