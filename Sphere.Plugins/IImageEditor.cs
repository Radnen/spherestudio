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
    public interface IImageEditor
    {
        /// <summary>
        /// Raised when the image data has been modified.
        /// </summary>
        event EventHandler ImageEdited;

        /// <summary>
        /// Gets the image being edited in its present state.
        /// </summary>
        /// <returns></returns>
        Bitmap GetImage();

        /// <summary>
        /// Splits the image being edited into tiles and returns the images for each of those tiles.
        /// </summary>
        /// <param name="tileWidth">The width of the tiles.</param>
        /// <param name="tileHeight">The height of the tiles.</param>
        /// <returns>A list of images representing the individual tiles.</returns>
        IList<Bitmap> GetImages(short tileWidth, short tileHeight);
        
        /// <summary>
        /// Injects a new image wholesale into the editor.
        /// </summary>
        /// <param name="image"></param>
        void SetImage(Bitmap image);
    }
}
