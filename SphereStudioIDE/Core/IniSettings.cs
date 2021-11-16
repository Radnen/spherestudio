using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using SphereStudio;
using SphereStudio.Base;
using SphereStudio.Ide.Utility;

namespace SphereStudio.Ide
{
    class IniSettings : ISettings
    {
        private IniFile _ini;
        private string _section;

        public IniSettings(IniFile ini, string section)
        {
            _ini = ini;
            _section = section;
        }

        public void SetValue(string key, object value)
        {
            value = value ?? "";
            
            string valuestr = value is IEnumerable<string>
                ? string.Join("|", value as IEnumerable<string>)
                : value.ToString();
            _ini.Write(_section, key, valuestr);
        }

        public bool GetBoolean(string key, bool defValue)
        {
            return Convert.ToBoolean(GetString(key, defValue.ToString()));
        }

        public double GetFloat(string key, double defValue)
        {
            return Convert.ToDouble(GetString(key, defValue.ToString()));
        }

        public int GetInteger(string key, int defValue)
        {
            return Convert.ToInt32(GetString(key, defValue.ToString()));
        }

        public string GetString(string key, string defValue)
        {
            return _ini.Read(_section, key, defValue ?? "");
        }
        
        public string[] GetStringArray(string key, string[] defValues)
        {
            string values = _ini.Read(_section, key, null);
            if (values == null && defValues != null)
                return defValues;
            return !string.IsNullOrEmpty(values)
                ? values.Split('|') : new string[0];
        }

        public bool Save()
        {
            return _ini.Save();
        }

        public virtual bool SaveAs(string filepath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filepath));
            return _ini.SaveAs(filepath);
        }
    }
}
