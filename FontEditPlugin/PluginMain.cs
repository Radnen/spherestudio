using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;
using System.Drawing;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain, INewFileOpener
    {
        public string Name { get; } = "Font Importer";
        public string Author { get; } = "Spherical";
        public string Description { get; } = "Convert TrueType fonts to Sphere .rfn format.";
        public string Version { get; } = "1.2.2";

        public string FileTypeName { get; } = "Sphere Font";
        public string[] FileExtensions { get; } = new[] { "rfn" };
        public Bitmap FileIcon { get; } = Properties.Resources.style;

        public void Initialize(ISettings conf) => PluginManager.Register(this, this, Name);

        public void ShutDown() => PluginManager.UnregisterAll(this);

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
