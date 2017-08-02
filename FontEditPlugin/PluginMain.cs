using System.Drawing;

using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain, INewFileOpener
    {
        public string Name { get; } = "Font Importer";
        public string Description { get; } = "Convert TrueType fonts to Sphere .rfn format.";
        public string Version { get; } = Versioning.Version;
        public string Author { get; } = Versioning.Author;

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
