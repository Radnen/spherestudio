using System;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Plugins;

namespace SphereStudio.Plugins
{
    public class MyPlugin : IPlugin
    {
        public string Name { get { return "My Cool Plugin"; } }
        public string Author { get { return "Me"; } }
        public string Description { get { return "An awesome plugin, that's really cool!"; } }
        public string Version { get { return "1.5a"; } }
        public Icon Icon { get; set; }
        public IIDE Host { get; set; }

        private readonly ToolStripMenuItem _myItem;

        public MyPlugin()
        {
            _myItem = new ToolStripMenuItem("Print Me");
            _myItem.Click += MyClick;
        }

        /* Custom method shows a .NET message box containing '42'. */
        private void MyClick(object sender, EventArgs args)
        {
            MessageBox.Show("42");
        }

        /* Here we talk to the host, adding a menu item */
        public void Initialize()
        {
           Host.AddMenuItem("NewMenu", _myItem);
        }

        /* Here we talk to the host, removing the item */
        public void Destroy()
        {
            Host.RemoveMenuItem("NewMenu");
        }
    }
}
