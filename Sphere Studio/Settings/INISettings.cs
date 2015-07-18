using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Sphere.Core;
using Sphere.Plugins;

namespace SphereStudio.Settings
{
    class INISettings : ISettings
    {
        private INI _ini;
        private string _section;

        public INISettings(INI ini, string section)
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
            return _ini.Read(_section, key, defValue);
        }
        
        public string[] GetStringArray(string key)
        {
            return GetString(key, "").Split('|');
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
