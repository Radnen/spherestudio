using System.Drawing;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.Plugins
{
    public class DuktapeDebugPlugin : IDebugPlugin
    {
        public string Name { get { return "minisphere Debugger"; } }
        public string Author { get { return "Lord English"; } }
        public string Description { get { return "A stepping debugger for minisphere"; } }
        public string Version { get { return "1.6.0"; } }

        public Icon Icon { get; private set; }

        public void Initialize(ISettings conf)
        {

        }

        public void ShutDown()
        {

        }

        public IDebugger Start(IProject project)
        {
            string exePath = PluginManager.IDE.EnginePath;
            var args = string.Format(@"--debug --game ""{0}""\game.sgm", project.RootPath);
            var client = new DuktapeClient();
            client.Connect("localhost", 812);
            return client;
        }
    }
}
