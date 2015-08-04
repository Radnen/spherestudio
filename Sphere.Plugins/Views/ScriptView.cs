using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins.Views
{
    /// <summary>
    /// Specifies the interface for a script editing component.
    /// </summary>
    public class ScriptView : DocumentView
    {
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
        public virtual int[] BreakPoints
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
    }
}
