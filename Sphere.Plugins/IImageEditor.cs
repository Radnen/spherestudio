using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins
{
    /// <summary>
    /// Defines a Sphere Studio image editor.
    /// </summary>
    public interface IImageEditor
    {
        event EventHandler ImageEdited;
        
        Bitmap GetImage();

        List<Bitmap> GetImages(short tileWidth, short tileHeight);
        
        void SetImage(Bitmap image);
    }
}
