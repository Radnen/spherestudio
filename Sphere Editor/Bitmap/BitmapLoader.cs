using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Sphere_Editor.Bitmaps
{
    // used for fast and easy bitmap extraction from a stream.
    // by Andrew Helenius, 2010-2012
    class BitmapLoader
    {
        private Rectangle _rect;
        private FastBitmap _fast_img;
        private Bitmap _image;
        private Bitmap _copy;
        private BitmapData _data;

        public BitmapLoader(int width, int height)
        {
            _rect = new Rectangle(0, 0, width, height);

            _copy = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            _data = this._copy.LockBits(_rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            _image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            _fast_img = new FastBitmap(_image);
        }

        // DIBstream is DIB content saved in a memory stream.
        public static Bitmap BitmapFromDIB(MemoryStream DIBstream)
        {
            BinaryReader reader = new BinaryReader(DIBstream);
            reader.ReadInt32();
            int w = reader.ReadInt32();
            int h = reader.ReadInt32();
            reader.ReadBytes(40);

            BitmapLoader loader = new BitmapLoader(w, h);
            loader.ColorFormat = ColorFormat.FormatARGB;
            Bitmap image = loader.LoadFromStream(reader, (int)reader.BaseStream.Length - 52);
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            loader.Close();
            
            return image;
        }

        public Bitmap LoadFromStream(BinaryReader reader, int amount)
        {
            byte[] bmp_bytes = reader.ReadBytes(amount);
            Marshal.Copy(bmp_bytes, 0, _data.Scan0, amount);
            _fast_img.LockImage();
            unsafe
            {
                byte* ptr = (byte*)_data.Scan0;
                for (int y = 0; y < _copy.Height; ++y)
                {
                    for (int x = 0; x < _copy.Width; ++x)
                    {
                        int value = *(ptr);
                        _fast_img.SetPixel(x, y, Color.FromArgb(*(ptr + 3), value, *(ptr + 1), *(ptr + 2)));
                        ptr += 4;
                    }
                }
            }
            _fast_img.UnlockImage();
            return new Bitmap(_image);
        }

        // must be called to close any opened resources.
        public void Close()
        {
            _copy.UnlockBits(_data);
            _copy.Dispose();
            _image.Dispose();
        }

        public ColorFormat ColorFormat
        {
            get { return _fast_img.ColorFormat; }
            set { _fast_img.ColorFormat = value; }
        }
    }

    class BitmapSaver
    {
        Rectangle rect;
        BitmapData data;
        int size;

        public BitmapSaver(int width, int height)
        {
            this.rect = new Rectangle(0, 0, width, height);
            this.size = width * height;
        }

        public void SaveToStream(Bitmap image, BinaryWriter writer)
        {
            this.data = image.LockBits(this.rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int i = 0; i < this.size; ++i)
                {
                    writer.Write(*(ptr + 2));
                    writer.Write(*(ptr + 1));
                    writer.Write(*(ptr));
                    writer.Write(*(ptr + 3));
                    ptr += 4;
                }
            }
            image.UnlockBits(this.data);
        }
    }
}
