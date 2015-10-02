using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Sphere.Core.Editor;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    public class WindowstyleEditPlugin : IPluginMain, IFileOpener
    {
        public string Name { get { return "Windowstyle Editor"; } }
        public string Author { get { return "Spherical"; } }
        public string Description { get { return "Sphere Studio default windowstyle editor"; } }
        public string Version { get { return "1.2.0"; } }
        public Icon Icon { get; set; }

        private readonly string[] _extensions = new[] { "rws" };
        private const string _openFileFilters = "*.rws";

        public WindowstyleEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.GridToolIcon.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            PluginManager.RegisterPlugin(this, this, Name);
            PluginManager.RegisterExtensions(this, _extensions);
            PluginManager.IDE.RegisterNewHandler(this, "Windowstyle", Icon);
            PluginManager.IDE.RegisterOpenFileType("Sphere Windowstyles", _openFileFilters);
        }

        public void ShutDown()
        {
            PluginManager.UnregisterExtensions(_extensions);
            PluginManager.UnregisterPlugins(this);
            PluginManager.IDE.UnregisterNewHandler(this);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
        }

        public DocumentView New()
        {
            var view = new WindowstyleEditView();
            return view.NewDocument() ? view : null;
        }
        
        public DocumentView Open(string fileName)
        {
            WindowstyleEditView view = new WindowstyleEditView();
            view.Load(fileName);
            return view;
        }
   }
}
