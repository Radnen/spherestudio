﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Plugins;

namespace MyPlugin
{
    class MyPlugin : IPlugin
    {
        public string Name { get { return "My Cool Plugin"; } }
        public string Author { get { return "Me"; } }
        public string Description { get { return "An awesome plugin, that's really cool!"; } }
        public string Version { get { return "1.5a"; } }
        public Icon Icon { get; set; }
        public IPluginHost Host { get; set; }

        private ToolStripMenuItem my_item;

        public MyPlugin()
        {
            my_item = new ToolStripMenuItem("Print Me");
            my_item.Click += new EventHandler(MyClick);
        }

        /* Custom method shows a .NET message box containing '42'. */
        private void MyClick(object sender, EventArgs args)
        {
            MessageBox.Show("42");
        }

        /* Here we talk to the host, adding a menu item */
        public void Initialize()
        {
           Host.AddMenuItem("NewMenu", my_item);
        }

        /* Here we talk to the host, removing the item */
        public void Destroy()
        {
            Host.RemoveMenuItem("NewMenu");
        }
    }
}