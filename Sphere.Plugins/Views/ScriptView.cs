using System;
using System.Collections.Generic;
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
        /// Gets or sets the contents of the script view.
        /// </summary>
        public override string Text
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
