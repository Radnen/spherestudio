using System.Drawing;

using Sphere.Core;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain, INewFileOpener
    {
        public string Name { get; } = "Windowstyle Editor";
        public string Description { get; } = "Sphere Studio default windowstyle editor";
        public string Version { get; } = Versioning.Version;
        public string Author { get; } = Versioning.Author;

        public string FileTypeName { get; } = "Sphere Windowstyle";
        public string[] FileExtensions { get; private set; } = new[] { "rws" };
        public Bitmap FileIcon { get; } = Properties.Resources.GridToolIcon;

        public void Initialize(ISettings conf) => PluginManager.Register(this, this, Name);

        public void ShutDown() => PluginManager.UnregisterAll(this);

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
