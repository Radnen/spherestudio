using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins
{
    /// <summary>
    /// Specifies the interface for an image editing component.
    /// </summary>
    public interface IImageView : IDocumentView
    {
        /// <summary>
        /// Raised when the image data has been modified.
        /// </summary>
        event EventHandler ImageChanged;

        /// <summary>
        /// Gets or sets the image as it is shown in the document.
        /// </summary>
        Bitmap Content { get; set; }

        /// <summary>
        /// Splits the image being edited into tiles and returns the images for each of those tiles.
        /// </summary>
        /// <param name="tileWidth">The width of the tiles.</param>
        /// <param name="tileHeight">The height of the tiles.</param>
        /// <returns>A list of images representing the individual tiles.</returns>
        IList<Bitmap> GetImages(short tileWidth, short tileHeight);
    }
}
