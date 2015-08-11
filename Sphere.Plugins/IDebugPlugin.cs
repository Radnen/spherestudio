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
        /// <param name="project">The debug target.</param>
        /// <returns>An IDebugger object representing the session.</returns>
        Task<IDebugger> Debug(IProject project);
    }
}
