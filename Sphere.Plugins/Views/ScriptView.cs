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
        public event EventHandler<BreakpointChangedEventArgs> BreakpointChanged;
        
        /// <summary>
        /// Gets or sets the active line, used while debugging.
        /// </summary>
        public virtual int ActiveLine
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets  the error line, used to point out script errors
        /// during debugging.
        /// </summary>
        public virtual int ErrorLine
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

        /// <summary>
        /// Moves the cursor to a specified line number, used when debugging.
        /// </summary>
        /// <param name="lineNumber">The line number to navigate to.</param>
        public virtual void GoToLine(int lineNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fires a BreakpointChanged event for this ScriptView.
        /// </summary>
        /// <param name="e"></param>
        protected void OnBreakpointChanged(BreakpointChangedEventArgs e)
        {
            if (BreakpointChanged != null) BreakpointChanged(this, e);
        }
    }

    /// <summary>
    /// Contains data for a BreakpointChanged event.
    /// </summary>
    public class BreakpointChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes data for a BreakpointSet event.
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <param name="isActive"></param>
        public BreakpointChangedEventArgs(int lineNumber, bool isActive)
        {
            LineNumber = lineNumber;
            Active = isActive;
        }

        /// <summary>
        /// If Active is true, the breakpoint is set. Otherwise it is cleared.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// The line number containing the breakpoint.
        /// </summary>
        public int LineNumber { get; private set; }
    }
}
