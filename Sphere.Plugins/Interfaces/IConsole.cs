using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Specifies the interface for a text console, as used for, e.g.
    /// the build system.
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// Prints text to the console. Newlines must be printed manually.
        /// </summary>
        /// <param name="text">The text to be printed.</param>
        void Print(string text);
    }
}
