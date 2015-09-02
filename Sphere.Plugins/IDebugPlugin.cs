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
        /// <param name="project">The project used to host the debug session.</param>
        /// <param name="gamePath">The full path of the unpacked Sphere game to debug.</param>
        /// <returns>An IDebugger object representing the session.</returns>
        IDebugger Debug(IProject project, string gamePath);
    }
}
