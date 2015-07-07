using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Plugins;

using Ini.Net;

namespace SphereStudio.Settings
{
    public class INISettings : ISettings
    {
        private IniFile _ini;
        private string _section;

        public INISettings(string filename, string section = "INI")
        {
            string pathstr = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Sphere Studio\Settings");
            Directory.CreateDirectory(pathstr);
            _ini = new IniFile(Path.Combine(pathstr, filename));
            _section = section;
        }

        public void SetValue(string key, object value)
        {
            if (value is IEnumerable<string>)
            {
                string valuestr = "";
                foreach (object item in (value as Array))
                {
                    if (valuestr != "") valuestr += ",";
                    valuestr += item.ToString();
                }
                _ini.WriteString(_section, key, valuestr);
            }
            else
            {
                _ini.WriteString(_section, key, value.ToString());
            }
        }

        public bool GetBoolean(string key, bool defValue)
        {
            if (_ini.KeyExists(_section, key))
                return _ini.ReadBoolean(_section, key);
            else
                return defValue;
        }
        
        public double GetFloat(string key, double defValue)
        {
            if (_ini.KeyExists(_section, key))
                return _ini.ReadFloat(_section, key);
            else
                return defValue;
        }
        
        public int GetInteger(string key, int defValue)
        {
            if (_ini.KeyExists(_section, key))
                return _ini.ReadInteger(_section, key);
            else
                return defValue;
        }
        
        public string GetString(string key, string defValue)
        {
            if (_ini.KeyExists(_section, key))
                return _ini.ReadString(_section, key);
            else
                return defValue;
        }
        
        public string[] GetStringArray(string key)
        {
            if (_ini.KeyExists(_section, key))
            {
                string cs = _ini.ReadString(_section, key);
                return cs.Split(',');
            }
            else
                return new string[0];
        }
    }
}
