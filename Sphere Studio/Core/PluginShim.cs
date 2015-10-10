using System;
using System.IO;
using System.Reflection;

using SphereStudio;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio
{
    class PluginShim
    {
        private bool _isEnabled = false;

        public PluginShim(string fileName, string handle)
        {
            Handle = handle;
            Assembly assembly = Assembly.LoadFrom(fileName);
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetInterface("IPluginMain") != null)
                {
                    Main = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null) as IPluginMain;
                    break;
                }
            }
        }

        public PluginShim(IPluginMain main, string handle)
        {
            Handle = handle;
            Main = main;
        }

        public IPluginMain Main { get; private set; }
        public string Handle { get; private set; }

        public bool Enabled
        {
            get { return _isEnabled; }
            set { if (value) Activate(); else Deactivate(); }
        }

        public void Activate()
        {
            if (!_isEnabled)
            {
                ISettings conf = new IniSettings(Core.MainIniFile, Handle);
                Main.Initialize(conf);
                _isEnabled = true;
            }
        }

        public void Deactivate()
        {
            if (_isEnabled)
            {
                Main.ShutDown();
                PluginManager.UnregisterAll(Main);
                _isEnabled = false;
            }
        }
    }
}
