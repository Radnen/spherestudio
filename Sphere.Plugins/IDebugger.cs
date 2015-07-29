using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins
{
    public interface IDebugger
    {
        /// <summary>
        /// Runs until the next breakpoint is hit or the target terminates,
        /// whichever comes first.
        /// </summary>
        void Run();

        /// <summary>
        /// Executes the next statement, stepping into function calls.
        /// </summary>
        void StepInto();

        /// <summary>
        /// Runs until the current function returns.
        /// </summary>
        void StepOut();

        /// <summary>
        /// Runs until the current statement finishes executing.
        /// </summary>
        void StepOver();
    }
}
