using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins.Views
{
    /// <summary>
    /// Provides a base class for a script editing component.
    /// </summary>
    [ToolboxItem(false)]
    public class ScriptView : DocumentView
    {
        /// <summary>
        /// Fires when a breakpoint is added or removed.
        /// </summary>
        public event EventHandler<BreakpointSetEventArgs> BreakpointSet;
        
        /// <summary>
        /// Gets or sets the active line, used while debugging.
        /// </summary>
        public virtual int ActiveLine
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a list of the line numbers of all breakpoints
        /// set in this script view.
        /// </summary>
        public virtual int[] Breakpoints
        {
            get { return new int[0]; }
            set { }
        }

        /// <summary>
        /// Gets or sets the contents of the script view.
        /// </summary>
        public override string Text
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public virtual void GoToLine(int lineNumber)
        {
            throw new NotImplementedException();
        }

        protected void OnBreakpointSet(BreakpointSetEventArgs e)
        {
            if (BreakpointSet != null) BreakpointSet(this, e);
        }
    }

    /// <summary>
    /// Contains data for a BreakpointSet event.
    /// </summary>
    public class BreakpointSetEventArgs : EventArgs
    {
        public BreakpointSetEventArgs(int lineNumber, bool isActive)
        {
            LineNumber = lineNumber;
            Active = isActive;
        }

        /// <summary>
        /// If Active is true, the breakpoint was set. Otherwise it was cleared.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// The line number containing the breakpoint.
        /// </summary>
        public int LineNumber { get; private set; }
    }
}
