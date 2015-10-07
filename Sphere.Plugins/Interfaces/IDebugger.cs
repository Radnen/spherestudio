using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins.Interfaces
{
    /// <summary>
    /// Specifies the interface for a single-step debugger.
    /// </summary>
    public interface IDebugger
    {
        /// <summary>
        /// Gets the fully qualified path of the source file currently being
        /// executed.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets the line number of the next instruction to be executed.
        /// </summary>
        int LineNumber { get; }

        /// <summary>
        /// Gets whether the debug target is currently executing.
        /// </summary>
        bool Running { get; }

        /// <summary>
        /// Fires when the debugger is successfully attached.
        /// </summary>
        event EventHandler Attached;

        /// <summary>
        /// Fires when the debugger is detached.
        /// </summary>
        event EventHandler Detached;
        
        /// <summary>
        /// Fires when execution pauses (e.g. at a breakpoint).
        /// </summary>
        event EventHandler Paused;

        /// <summary>
        /// Fires when execution resumes.
        /// </summary>
        event EventHandler Resumed;

        /// <summary>
        /// Attaches the debugger.
        /// </summary>
        /// <returns>true if the debugger was successfully attached.</returns>
        Task<bool> Attach();

        /// <summary>
        /// Detaches the debugger.
        /// </summary>
        Task Detach();

        /// <summary>
        /// Pauses execution and breaks into the debugger.
        /// </summary>
        Task Pause();

        /// <summary>
        /// Runs until the next breakpoint is hit or the target terminates,
        /// whichever comes first.
        /// </summary>
        Task Resume();

        /// <summary>
        /// Sets or clears a breakpoint at a specified location.
        /// </summary>
        /// <param name="fileName">The filename containing the breakpoint.</param>
        /// <param name="lineNumber">The line number of the breakpoint.</param>
        /// <param name="isSet">If true, a breakpoint is set. Otherwise, the existing one is cleared.</param>
        Task SetBreakpoint(string fileName, int lineNumber, bool isSet);

        /// <summary>
        /// Executes the next line of code, stepping into function calls.
        /// </summary>
        Task StepInto();

        /// <summary>
        /// Runs until the current function returns.
        /// </summary>
        Task StepOut();

        /// <summary>
        /// Executes the next line of code.
        /// </summary>
        Task StepOver();
    }
}
