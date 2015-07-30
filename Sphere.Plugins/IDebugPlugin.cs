using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Plugins.Interfaces;

namespace Sphere.Plugins
{
    public interface IDebugPlugin : IPlugin
    {
        /// <summary>
        /// Starts a debugging session for a project.
        /// </summary>
        /// <param name="project"></param>
        IDebugger Start(IProject project);
    }
}
