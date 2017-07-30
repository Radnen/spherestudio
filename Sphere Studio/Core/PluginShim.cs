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
        private bool m_isEnabled = false;

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
            get { return m_isEnabled; }
            set { if (value) Activate(); else Deactivate(); }
        }

        public void Activate()
        {
            if (!m_isEnabled)
            {
                ISettings conf = new IniSettings(Core.MainIniFile, Handle);
                Main.Initialize(conf);
                m_isEnabled = true;
            }
        }

        public void Deactivate()
        {
            if (m_isEnabled)
            {
                m_isEnabled = false;
                Main.ShutDown();
                PluginManager.UnregisterAll(Main);
            }
        }
    }
}
