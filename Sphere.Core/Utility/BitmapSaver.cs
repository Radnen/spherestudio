using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Sphere.Core.Utility
{
    /// <summary>
    /// Saves bitmap to a filestream.
    /// </summary>
    public class BitmapSaver
    {
        private Rectangle _rect;
        private BitmapData _data;
        private int _size;

        /// <summary>
        /// Creates a bitmap saver, which saves bitmaps to filestreams.
        /// </summary>
        /// <param name="width">The image width in pixels.</param>
        /// <param name="height">The image height in pixels.</param>
        public BitmapSaver(int width, int height)
        {
            _rect = new Rectangle(0, 0, width, height);
            _size = width * height;
        }

        /// <summary>
        /// Saves the image to a filestream.
        /// </summary>
        /// <param name="image">The image to save.</param>
        /// <param name="writer">The System.IO.BinaryWriter to use.</param>
        public void SaveToStream(Bitmap image, BinaryWriter writer)
        {
            _data = image.LockBits(_rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* ptr = (byte*)_data.Scan0;
                for (int i = 0; i < _size; ++i)
                {
                    writer.Write(*(ptr + 2));
                    writer.Write(*(ptr + 1));
                    writer.Write(*(ptr));
                    writer.Write(*(ptr + 3));
                    ptr += 4;
                }
            }
            image.UnlockBits(_data);
        }
    }
}
