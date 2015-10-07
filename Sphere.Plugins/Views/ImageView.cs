using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins.Views
{
    /// <summary>
    /// Provides a base class for an image editing component.
    /// </summary>
    [ToolboxItem(false)]
    public class ImageView : DocumentView
    {
        public override bool IsDirty
        {
            get { return base.IsDirty; }
            protected set
            {
                if (value && ImageChanged != null)
                    ImageChanged(this, EventArgs.Empty);
                base.IsDirty = value;
            }
        }
        
        /// <summary>
        /// Raised when the image data has been modified.
        /// </summary>
        public event EventHandler ImageChanged;

        /// <summary>
        /// Gets or sets the image as it is shown in the document.
        /// </summary>
        public virtual Bitmap Content
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Splits the image being edited into tiles and returns the images for each of those tiles.
        /// </summary>
        /// <param name="tileWidth">The width of the tiles.</param>
        /// <param name="tileHeight">The height of the tiles.</param>
        /// <returns>A list of images representing the individual tiles.</returns>
        public virtual IList<Bitmap> GetImages(short tileWidth, short tileHeight)
        {
            throw new NotImplementedException();
        }
    }
}
