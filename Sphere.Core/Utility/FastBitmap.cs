using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Sphere.Core.Utility
{
    /// <summary>
    /// Used to efficiently and quickly manipulate bitmaps.
    /// </summary>
    unsafe public class FastBitmap
    {
        Rectangle bounds;
        int width;
        Bitmap image;
        BitmapData imageData;

        byte* pBase;
        PixelData* pixelData;
        ColorFormat c_format = ColorFormat.FormatABGR;

        /// <summary>
        /// Creates a FastBitmap wrapper for an image object.
        /// </summary>
        /// <param name="img">The image object to wrap.</param>
        public FastBitmap(Bitmap img)
        {
            image = img;
        }

        /// <summary>
        /// Locks the image to get it ready for fast manipluations.
        /// </summary>
        public void LockImage()
        {
            bounds = new Rectangle(Point.Empty, image.Size);
            width = (int)(bounds.Width * sizeof(PixelData));
            if (width % 4 != 0) width = ((width >> 2) + 1) << 2;

            imageData = image.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            pBase = (byte*)imageData.Scan0.ToPointer();
        }

        /// <summary>
        /// Gets a pixel at the x/y location.
        /// </summary>
        /// <param name="x">The x pixel location.</param>
        /// <param name="y">The y pixel location.</param>
        /// <returns>The Color at the x/y location.</returns>
        /// <exception cref="Exception">Invalid color format.</exception>
        public Color GetPixel(int x, int y)
        {
            pixelData = (PixelData*)(pBase + y * width + x * sizeof(PixelData));

            switch (c_format)
            {
                case ColorFormat.FormatABGR:
                    return Color.FromArgb(pixelData->a, pixelData->b, pixelData->g, pixelData->r);
                case ColorFormat.FormatARGB:
                    return Color.FromArgb(pixelData->a, pixelData->r, pixelData->g, pixelData->b);
                case ColorFormat.FormatBGRA:
                    return Color.FromArgb(pixelData->b, pixelData->g, pixelData->r, pixelData->a);
                case ColorFormat.FormatRGBA:
                    return Color.FromArgb(pixelData->r, pixelData->g, pixelData->b, pixelData->a);
            }

            throw new Exception("Invalid color format.");
        }

        /// <summary>
        /// Sets a pixel at the x/y location to the new color.
        /// </summary>
        /// <param name="x">The x pixel location.</param>
        /// <param name="y">The y pixel location.</param>
        /// <param name="color">The color to set the pixel to.</param>
        public void SetPixel(int x, int y, Color color)
        {
            PixelData* pixel = (PixelData*)(pBase + y * width + x * sizeof(PixelData));            
            switch (c_format) {
                case ColorFormat.FormatABGR:
                    pixel->a = color.A; pixel->r = color.B;
                    pixel->g = color.G; pixel->b = color.R;
                    break;
                case ColorFormat.FormatARGB:
                    pixel->a = color.A; pixel->r = color.R;
                    pixel->g = color.G; pixel->b = color.B;
                    break;
                case ColorFormat.FormatBGRA:
                    pixel->a = color.B; pixel->r = color.G;
                    pixel->g = color.R; pixel->b = color.A;
                    break;
                case ColorFormat.FormatRGBA:
                    pixel->a = color.R; pixel->r = color.G;
                    pixel->g = color.B; pixel->b = color.A;
                    break;
            }
        }

        private void SetAlpha(int x, int y, byte alpha)
        {
            PixelData* pixel = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
            pixel->a = alpha;
        }

        private void ToGray(int x, int y)
        {
            PixelData* pixel = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
            pixel->r = pixel->g;
            pixel->b = pixel->g;
        }

        /// <summary>
        /// Unlocks the image.
        /// </summary>
        public void UnlockImage()
        {
            image.UnlockBits(imageData);
        }

        /// <summary>
        /// Creates a clone of the wrapped image object.
        /// </summary>
        /// <returns>A copy of the image object.</returns>
        public Bitmap Clone()
        {
            return image.Clone(bounds, PixelFormat.Format32bppArgb);
        }

        /// <summary>
        /// Grabs a sub-section clone of the wrapped image.
        /// </summary>
        /// <param name="rect">The rectangle to cut from.</param>
        /// <param name="format">The PixelFomat to use.</param>
        /// <returns>A sub-bitmap object.</returns>
        public Bitmap Clone(Rectangle rect, PixelFormat format)
        {
            return image.Clone(rect, format);
        }

        /// <summary>
        /// Grabs a sub-section clone of the wrapped image.
        /// </summary>
        /// <param name="rect">The rectangle to cut from.</param>
        /// <param name="format">The PixelFomat to use.</param>
        /// <returns>A sub-bitmap object.</returns>
        public Bitmap Clone(RectangleF rect, PixelFormat format)
        {
            return image.Clone(rect, format);
        }

        /// <summary>
        /// Gets the width of the wrapped Image.
        /// </summary>
        public int Width { get { return image.Width; } }

        /// <summary>
        /// Gets the height of the wrapped Image.
        /// </summary>
        public int Height { get { return image.Height; } }

        /// <summary>
        /// Gets or sets the image wrapped by this.
        /// </summary>
        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }

        /// <summary>
        /// Gets or sets the Color format used by this.
        /// </summary>
        public ColorFormat ColorFormat
        {
            get { return c_format; }
            set { c_format = value; }
        }

        /// <summary>
        /// Replaces an old color with a new color.
        /// </summary>
        /// <param name="old_c">The color in the image to edit.</param>
        /// <param name="new_c">The color to replace with.</param>
        public void ReplaceColor(Color old_c, Color new_c)
        {
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    if (ColorsEqual(GetPixel(x, y), old_c)) SetPixel(x, y, new_c);
                }
            }
        }

        /// <summary>
        /// Converts the image to a grayscale representation.
        /// </summary>
        public void Grayscale()
        {
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x) ToGray(x, y);
            }
        }

        /// <summary>
        /// Sets all transparency to max value.
        /// </summary>
        public void FlattenAlpha()
        {
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x) SetAlpha(x, y, 255);
            }
        }

        /// <summary>
        /// Replaces the colors of a particular area:
        /// </summary>
        /// <param name="x">start x</param>
        /// <param name="y">start y</param>
        /// <param name="new_color">color to replace with</param>
        /// <returns>rectangle of the affetced area.</returns>
        public Rectangle FloodFill(int x, int y, Color new_color)
        {
            Color old_color = GetPixel(x, y);
            if (ColorsEqual(old_color, new_color)) return Rectangle.Empty;
            Rectangle edit_region = new Rectangle(x, y, 0, 0);
            
            Stack<Point> points = new Stack<Point>();
            points.Push(new Point(x, y));
            SetPixel(x, y, new_color);

            while (points.Count > 0)
            {
                Point pt = points.Pop();
                if (pt.X > 0) CheckFloodPoint(points, pt.X - 1, pt.Y, old_color, new_color);
                if (pt.Y > 0) CheckFloodPoint(points, pt.X, pt.Y - 1, old_color, new_color);
                if (pt.X < Width - 1) CheckFloodPoint(points, pt.X + 1, pt.Y, old_color, new_color);
                if (pt.Y < Height - 1) CheckFloodPoint(points, pt.X, pt.Y + 1, old_color, new_color);

                // grow the edit region:
                if (pt.X < edit_region.X) { edit_region.Width += edit_region.X - pt.X; edit_region.X = pt.X; }
                else if (pt.X > edit_region.Right) { edit_region.Width = pt.X - edit_region.X; }

                if (pt.Y < edit_region.Y) { edit_region.Height += edit_region.Y - pt.Y; edit_region.Y = pt.Y; }
                else if (pt.Y > edit_region.Bottom) { edit_region.Height = pt.Y - edit_region.Y; }
            }

            return edit_region;
        }

        private void CheckFloodPoint(Stack<Point> points, int x, int y, Color old_c, Color new_c)
        {
            if (ColorsEqual(GetPixel(x, y), old_c))
            {
                points.Push(new Point(x, y));
                SetPixel(x, y, new_c);
            }
        }

        /// <summary>
        /// Determines if two colors equal.
        /// </summary>
        /// <param name="col1">The color to compare.</param>
        /// <param name="col2">The color to compare against.</param>
        /// <returns>True if they field-wise match.</returns>
        public static bool ColorsEqual(Color col1, Color col2)
        {
            return (col1.A == col2.A && col1.R == col2.R &&
                    col1.G == col2.G && col1.B == col2.B);
        }

        /// <summary>
        /// Draws another bitmap into this image using straight-up pixel data.
        /// Not as fast as the Graphics.DrawImage();
        /// </summary>
        /// <param name="img">The source image.</param>
        /// <param name="x">x location in pixels.</param>
        /// <param name="y">y location in pixels.</param>
        public void DrawImage(Bitmap img, int x, int y)
        {
            FastBitmap fast_source = new FastBitmap(img);
            fast_source.LockImage();
            for (int yy = 0; yy < image.Height; ++yy)
                for (int xx = 0; xx < image.Width; ++xx)
                {
                    if (x + xx >= Width || y + yy >= Height) break;
                    SetPixel(x + xx, y + yy, fast_source.GetPixel(xx, yy));
                }
            fast_source.UnlockImage();
        }
    }

    /// <summary>
    /// Pixel data of an image.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PixelData
    {
        /// <summary>
        /// Red component.
        /// </summary>
        public byte r;
        
        /// <summary>
        /// Green component.
        /// </summary>
        public byte g;
        
        /// <summary>
        /// Blue component.
        /// </summary>
        public byte b;

        /// <summary>
        /// Alpha component
        /// </summary>
        public byte a;
    }

    /// <summary>
    /// A color format for loading/saving color data.
    /// </summary>
    public enum ColorFormat
    {
        /// <summary>
        /// ARGB style.
        /// </summary>
        FormatARGB = 0,
        
        /// <summary>
        /// RGBA style.
        /// </summary>
        FormatRGBA = 1,
        
        /// <summary>
        /// BGRA style.
        /// </summary>
        FormatBGRA = 2,

        /// <summary>
        /// ABGR style.
        /// </summary>
        FormatABGR = 3,
    }
}
