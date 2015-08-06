using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins.Interfaces
{
    public interface IDebugger
    {
        /// <summary>
        /// Gets the fully qualified path of the source file currently being
        /// executed in the debugger.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets the line number to be executed next by the debugger.
        /// </summary>
        int LineNumber { get; }

        /// <summary>
        /// Gets whether the debug target is currently executing.
        /// </summary>
        bool Running { get; }

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
        /// Gets a list of all variables in the current scope and their JSON-encoded
        /// values.
        /// </summary>
        /// <returns>A dictionary mapping variable names to their values.</returns>
        IReadOnlyDictionary<string, string> GetVariables();
        
        /// <summary>
        /// Pauses execution and breaks into the debugger.
        /// </summary>
        void BreakNow();
        
        /// <summary>
        /// Detaches the debugger.
        /// </summary>
        void Detach();

        /// <summary>
        /// Evaluates a JavaScript expression and returns the result.
        /// </summary>
        /// <param name="expression">The expression to evaluate.</param>
        /// <returns>The result of evaluating the expression.</returns>
        object Evaluate(string expression);
        
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
