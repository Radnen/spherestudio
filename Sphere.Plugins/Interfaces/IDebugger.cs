﻿using System;
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
        /// Gets a list of all variables in the current scope and their values.
        /// Complex objects will be reported simply as "[object]".
        /// </summary>
        /// <returns>A dictionary mapping variable names to their values.</returns>
        Task<IReadOnlyDictionary<string, string>> GetVariableList();
        
        /// <summary>
        /// Pauses execution and breaks into the debugger.
        /// </summary>
        Task Pause();
        
        /// <summary>
        /// Detaches the debugger.
        /// </summary>
        Task Detach();

        /// <summary>
        /// Evaluates a JavaScript expression and returns the JSON-encoded result.
        /// </summary>
        /// <param name="expression">The expression to evaluate.</param>
        /// <returns>The JSON-encoded result of evaluating the expression.</returns>
        Task<string> Evaluate(string expression);

        /// <summary>
        /// Runs until the next breakpoint is hit or the target terminates,
        /// whichever comes first.
        /// </summary>
        Task Resume();

        /// <summary>
        /// Sets or clears a breakpoint at a specified location.
        /// </summary>
        /// <param name="filename">The filename containing the breakpoint.</param>
        /// <param name="lineNumber">The line number of the breakpoint.</param>
        /// <param name="isActive">If true, a breakpoint is set. Otherwise, the existing one is cleared.</param>
        Task SetBreakpoint(string filename, int lineNumber, bool isActive);

        /// <summary>
        /// Executes the next statement, stepping into function calls.
        /// </summary>
        Task StepInto();

        /// <summary>
        /// Runs until the current function returns.
        /// </summary>
        Task StepOut();

        /// <summary>
        /// Runs until the current statement finishes executing.
        /// </summary>
        Task StepOver();
    }
}