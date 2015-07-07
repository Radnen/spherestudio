using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Plugins;

using Ini.Net;

namespace SphereStudio
{
    public class INI : ISettings
    {
        private string _filename;
        private IniFile _ini;

        public INI(string filename)
        {
            _filename = filename;
            string pathstr = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Sphere Studio\Settings", filename);
            Directory.CreateDirectory(Path.GetDirectoryName(pathstr));
            _ini = new IniFile(pathstr);
        }

        public void SetValue(string key, object value)
        {
            if (value is Array)
            {
                string valuestr = "";
                foreach (object item in (value as Array))
                {
                    if (valuestr != "") valuestr += ",";
                    valuestr += item.ToString();
                }
                _ini.WriteString(_filename, key, valuestr);
            }
            else
            {
                _ini.WriteString(_filename, key, value.ToString());
            }
        }

        public bool GetBoolean(string key, bool defValue)
        {
            if (_ini.KeyExists(_filename, key))
                return _ini.ReadBoolean(_filename, key);
            else
                return defValue;
        }
        
        public double GetFloat(string key, double defValue)
        {
            if (_ini.KeyExists(_filename, key))
                return _ini.ReadFloat(_filename, key);
            else
                return defValue;
        }
        
        public int GetInteger(string key, int defValue)
        {
            if (_ini.KeyExists(_filename, key))
                return _ini.ReadInteger(_filename, key);
            else
                return defValue;
        }
        
        public string GetString(string key, string defValue)
        {
            if (_ini.KeyExists(_filename, key))
                return _ini.ReadString(_filename, key);
            else
                return defValue;
        }
    }
}
