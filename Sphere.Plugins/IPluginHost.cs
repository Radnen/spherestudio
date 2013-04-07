using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere.Plugins
{
    public interface IPluginHost
    {
        void DockControl(Control ctrl, string name, DockAreas areas, DockAlignment align);
    }
}
