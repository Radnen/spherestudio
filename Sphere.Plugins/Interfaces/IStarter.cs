using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Specifies the interface for an engine starter. Starters handle launching
    /// an engine with the proper command line arguments, etc.
    /// </summary>
    public interface IStarter : IPlugin
    {
        /// <summary>
        /// 'true' if this engine supports configuration.
        /// </summary>
        bool CanConfigure { get; }
        
        /// <summary>
        /// Starts the engine.
        /// </summary>
        /// <param name="gamePath">The pathname of the game or package to launch.</param>
        /// <param name="isPackage">Pass 'true' if gamePath specifies a package.</param>
        void Start(string gamePath, bool isPackage);

        /// <summary>
        /// Launches the engine's configuration program. Throws an error if the
        /// engine doesn't support this.
        /// </summary>
        void Configure();
    }

    /// <summary>
    /// Specifies the interface for an engine starter supporting single-step
    /// debugging.
    /// </summary>
    public interface IDebugStarter : IStarter
    {
        /// <summary>
        /// Starts the engine in single-step debugging mode.
        /// </summary>
        /// <param name="gamePath">The pathname of the game or package to launch.</param>
        /// <param name="isPackage">Pass 'true' if gamePath specifies a package.</param>
        /// <param name="project">The Sphere Studio project hosting the debugger.</param>
        /// <returns></returns>
        IDebugger Debug(string gamePath, bool isPackage, IProject project);
    }
}
