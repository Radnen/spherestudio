using System;
using System.ComponentModel;
using System.Drawing;

namespace Sphere.Plugins.Views
{
    /// <summary>
    /// Provides a base class for an image editing component.
    /// </summary>
    [ToolboxItem(false)]
    public class ImageView : DocumentView
    {
        /// <summary>
        /// Gets or sets whether the image has been modified.
        /// </summary>
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
        /// Splits the image editor content into tiles and returns the tile bitmaps
        /// in an array.
        /// </summary>
        /// <param name="tileWidth">The width of the tiles.</param>
        /// <param name="tileHeight">The height of the tiles.</param>
        /// <returns>An array of tile bitmaps.</returns>
        public virtual Bitmap[] GetImages(short tileWidth, short tileHeight)
        {
            throw new NotImplementedException();
        }
    }
}
