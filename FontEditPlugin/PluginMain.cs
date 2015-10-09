using System;
using System.Drawing;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain, INewFileOpener
    {
        public string Name { get { return "Font Importer"; } }
        public string Author { get { return "Spherical"; } }
        public string Description { get { return "Convert TrueType fonts to Sphere .rfn format."; } }
        public string Version { get { return "1.2.0"; } }

        public string FileTypeName { get; private set; }
        public string[] FileExtensions { get; private set; }
        public Bitmap FileIcon { get; private set; }

        public void Initialize(ISettings conf)
        {
            FileTypeName = "Sphere Font";
            FileExtensions = new[] { "rfn" };
            FileIcon = Properties.Resources.style;

            PluginManager.Register(this, this, Name);
        }

        public void ShutDown()
        {
            PluginManager.UnregisterAll(this);
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
