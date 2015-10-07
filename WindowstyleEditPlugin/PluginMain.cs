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
    public class PluginMain : IPluginMain, INewFileOpener
    {
        public string Name { get { return "Windowstyle Editor"; } }
        public string Author { get { return "Spherical"; } }
        public string Description { get { return "Sphere Studio default windowstyle editor"; } }
        public string Version { get { return "1.2.0"; } }

        public PluginMain()
        {
            FileTypeName = "Sphere Windowstyle";
            FileExtensions = new[] { "rws" };
            FileIcon = Properties.Resources.GridToolIcon;
        }

        public void Initialize(ISettings conf)
        {
            PluginManager.Register(this, this, Name);
        }

        public void ShutDown()
        {
            PluginManager.UnregisterAll(this);
        }

        public string FileTypeName { get; private set; }
        public string[] FileExtensions { get; private set; }
        public Bitmap FileIcon { get; private set; }

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
