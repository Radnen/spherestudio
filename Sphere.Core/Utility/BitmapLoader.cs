using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

// by Andrew Helenius, 2010-2013

namespace Sphere.Core.Utility
{
    /// <summary>
    /// Efficiently loads bitmaps from a filestream.
    /// </summary>
    public class BitmapLoader : IDisposable
    {
        private readonly Rectangle _rect;
        private readonly FastBitmap _fastImg;
        private Bitmap _image;
        private Bitmap _copy;
        private BitmapData _data;

        /// <summary>
        /// Creates a new bitmap loader. Which loads bitmaps from filestreams.
        /// </summary>
        /// <param name="width">The image width in pixels.</param>
        /// <param name="height">the image height in pixels.</param>
        public BitmapLoader(int width, int height)
        {
            _rect = new Rectangle(0, 0, width, height);

            _copy = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            _data = _copy.LockBits(_rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            _image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            _fastImg = new FastBitmap(_image);
        }

        /// <summary>
        /// Generates a bitmap from a DIB object.
        /// </summary>
        /// <param name="DIBstream">A stream representing a DIB object.</param>
        /// <returns>A bitmap object.</returns>
        public static Bitmap BitmapFromDIB(MemoryStream DIBstream)
        {
            BinaryReader reader = new BinaryReader(DIBstream);
            reader.ReadInt32();
            int w = reader.ReadInt32();
            int h = reader.ReadInt32();
            reader.ReadBytes(40);

            using (BitmapLoader loader = new BitmapLoader(w, h))
            {
                loader.ColorFormat = ColorFormat.FormatARGB;
                Bitmap image = loader.LoadFromStream(reader, (int)reader.BaseStream.Length - 52);
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                return image;
            }
        }

        /// <summary>
        /// Creates a bitmap from a filestream.
        /// </summary>
        /// <param name="reader">The System.IO.BinaryReader to use.</param>
        /// <param name="amount">The size in bytes of the image.</param>
        /// <returns>A new bitmap object.</returns>
        public Bitmap LoadFromStream(BinaryReader reader, int amount)
        {
            byte[] bmpBytes = reader.ReadBytes(amount);
            Marshal.Copy(bmpBytes, 0, _data.Scan0, amount);
            _fastImg.LockImage();
            unsafe
            {
                byte* ptr = (byte*)_data.Scan0;
                for (int y = 0; y < _copy.Height; ++y)
                {
                    for (int x = 0; x < _copy.Width; ++x)
                    {
                        int value = *(ptr);
                        _fastImg.SetPixel(x, y, Color.FromArgb(*(ptr + 3), value, *(ptr + 1), *(ptr + 2)));
                        ptr += 4;
                    }
                }
            }
            _fastImg.UnlockImage();
            return new Bitmap(_image);
        }

        /// <summary>
        /// Closes and releases any resources being used.
        /// </summary>
        public void Close()
        {
            if (_copy == null) return;
            _copy.UnlockBits(_data);
            _copy.Dispose();
            _copy = null;
            _image.Dispose();
            _image = null;
        }

        /// <summary>
        /// Gets or sets the color format.
        /// </summary>
        public ColorFormat ColorFormat
        {
            get { return _fastImg.ColorFormat; }
            set { _fastImg.ColorFormat = value; }
        }

        private bool _disposed;

        /// <summary>
        /// Disposes and clears all data.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) Close();

                _image = null;
                _copy = null;
                _data = null;
            }
            _disposed = true;
        }
    }
}
