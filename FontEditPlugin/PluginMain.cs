using System;
using System.Drawing;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain, IFileOpener
    {
        public string Name { get { return "Font Importer"; } }
        public string Author { get { return "Spherical"; } }
        public string Description { get { return "Convert TrueType fonts to Sphere .rfn format."; } }
        public string Version { get { return "1.2.0"; } }

        public Icon Icon { get; private set; }

        private const string _openFileFilters = "*.rfn";
        private readonly string[] _extensions = new[] { "rfn" };

        public PluginMain()
        {
            Icon = Icon.FromHandle(Properties.Resources.style.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            PluginManager.RegisterPlugin(this, this, Name);
            PluginManager.RegisterExtensions(this, _extensions);
            PluginManager.IDE.RegisterNewHandler(this, "Font", Icon);
            PluginManager.IDE.RegisterOpenFileType("Sphere .rfn Fonts", _openFileFilters);
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
            DocumentView view = new FontEditView();
            return view.NewDocument() ? view : null;
        }

        public DocumentView Open(string fileName)
        {
            DocumentView view = new FontEditView();
            view.Load(fileName);
            return view;
        }
    }
}
