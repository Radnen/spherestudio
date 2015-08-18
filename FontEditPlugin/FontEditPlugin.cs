using System.Drawing;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    public class FontEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Font Importer"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Convert TTF fonts to .rfn for use with Sphere."; } }
        public string Version { get { return "1.2.0"; } }

        public Icon Icon { get; private set; }

        private const string _openFileFilters = "*.rfn";
        private readonly string[] _extensions = new[] { "rfn" };

        public FontEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.style.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            PluginManager.IDE.RegisterNewHandler(this, "Font", "fonts");
            PluginManager.IDE.RegisterOpenFileType("Sphere Fonts", _openFileFilters);
            PluginManager.RegisterExtensions(this, _extensions);
        }

        public void ShutDown()
        {
            PluginManager.IDE.UnregisterNewHandler(this);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.UnregisterExtensions(_extensions);
        }

        public DocumentView CreateEditView()
        {
            return new FontEditView();
        }

        public DocumentView NewDocument()
        {
            DocumentView view = new FontEditView();
            return view.NewDocument() ? view : null;
        }
        
        public DocumentView OpenDocument(string filepath)
        {
            DocumentView view = new FontEditView();
            view.Load(filepath);
            return view;
        }
    }
}
