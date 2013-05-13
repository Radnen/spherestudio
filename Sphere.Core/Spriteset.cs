using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Sphere.Core.Utility;

namespace Sphere.Core
{
    /// <summary>
    /// A Sphere spriteset object
    /// </summary>
    public class Spriteset : IDisposable
    {
        private short _version = 3;
        private short _frameWidth = 16, _frameHeight = 32;

        private Base _spriteBase = new Base();
        private readonly List<Direction> _directions = new List<Direction>();
        private List<Bitmap> _images = new List<Bitmap>();

        /// <summary>
        /// Populates this spriteset with default info.
        /// </summary>
        public void MakeNew()
        {
            _images.Add(new Bitmap(_frameWidth, _frameHeight));
            _directions.Add(new Direction("north"));
            _directions.Add(new Direction("northeast"));
            _directions.Add(new Direction("east"));
            _directions.Add(new Direction("southeast"));
            _directions.Add(new Direction("south"));
            _directions.Add(new Direction("southwest"));
            _directions.Add(new Direction("west"));
            _directions.Add(new Direction("northwest"));
            foreach (Direction d in _directions) d.Frames.Add(new Frame());
        }

        private void Purge()
        {
            _version = 3;
            _frameWidth = _frameHeight = 0;
            _spriteBase = new Base();
            _directions.Clear();
            foreach (Bitmap b in _images) b.Dispose();
            _images.Clear();
        }

        /// <summary>
        /// Attempts to load the spriteset from the given filename.
        /// </summary>
        /// <param name="filename">The filename of the Spriteset to load.</param>
        /// <returns>True if successful.</returns>
        public bool Load(String filename)
        {
            if (!File.Exists(filename)) return false;
            using (BinaryReader stream = new BinaryReader(File.OpenRead(filename)))
            {

                // purge anything already inside this object:
                Purge();

                // start reading the header //
                string sig = new string(stream.ReadChars(4));
                if (sig != ".rss") return false;

                _version = stream.ReadInt16();
                short numImages = stream.ReadInt16();
                _frameWidth = stream.ReadInt16();
                _frameHeight = stream.ReadInt16();
                short numDirs = stream.ReadInt16();

                // read sprite base //
                _spriteBase.X1 = stream.ReadInt16();
                _spriteBase.Y1 = stream.ReadInt16();
                _spriteBase.X2 = stream.ReadInt16();
                _spriteBase.Y2 = stream.ReadInt16();

                // reserved //
                stream.ReadBytes(106);
                switch (_version)
                {
                    case 3:
                        BitmapLoader loader = new BitmapLoader(_frameWidth, _frameHeight);
                        int amt = _frameWidth * _frameHeight * 4;
                        while (numImages-- > 0) _images.Add(loader.LoadFromStream(stream, amt));
                        loader.Close();

                        while (numDirs-- > 0)
                        {
                            short numFrames = stream.ReadInt16();
                            stream.ReadBytes(6);
                            short length = stream.ReadInt16();
                            string name = new String(stream.ReadChars(length)).Substring(0, length - 1);
                            Direction dir = new Direction(name);
                            while (numFrames-- > 0)
                            {
                                Frame f = new Frame {Index = stream.ReadInt16(), Delay = stream.ReadInt16()};
                                dir.Frames.Add(f);
                                stream.ReadBytes(4);
                            }
                            _directions.Add(dir);
                        }
                        break;
                }
            }
            return true;
        }

        /// <summary>
        /// Saves the Spriteset to the filename.
        /// </summary>
        /// <param name="filename">The filename to store the spriteset.</param>
        public void Save(string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(filename)))
            {
                // save header data:
                writer.Write(".rss".ToCharArray());
                writer.Write(_version);
                writer.Write((short)_images.Count);
                writer.Write(_frameWidth);
                writer.Write(_frameHeight);
                writer.Write((short)_directions.Count);

                // save the sprite base:
                writer.Write(_spriteBase.X1);
                writer.Write(_spriteBase.Y1);
                writer.Write(_spriteBase.X2);
                writer.Write(_spriteBase.Y2);

                //reserved:
                writer.Write(new byte[106]);

                switch (_version)
                {
                    case 3:
                        BitmapSaver saver = new BitmapSaver(_frameWidth, _frameHeight);
                        for (short i = 0; i < _images.Count; ++i) saver.SaveToStream(Images[i], writer);
                        foreach (Direction d in _directions)
                        {
                            writer.Write((short)d.Frames.Count);
                            writer.Write(new byte[6]);
                            writer.Write((short)(d.Name.Length + 1));
                            writer.Write((d.Name + "\0").ToCharArray());
                            foreach (Frame f in d.Frames)
                            {
                                writer.Write(f.Index);
                                writer.Write(f.Delay);
                                writer.Write(new byte[4]);
                            }
                        }
                        break;
                }

                writer.Flush();
            }
        }

        private bool _disposed;

        /// <summary>
        /// Disposes and clears this object.
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
                if (disposing)
                {
                    if (_images != null)
                    {
                        foreach (Bitmap b in _images) b.Dispose();
                        _images.Clear();
                    }
                }

                _images = null;
            }
            _disposed = true;
        }

        /// <summary>
        /// Removes the frame from the spriteset and its image array.
        /// </summary>
        /// <param name="reference"></param>
        public void RemoveFrameReference(int reference)
        {
            foreach (Direction d in _directions)
            {
                foreach (Frame f in d.Frames)
                {
                    if (f.Index == reference) f.Index = 0;
                    if (f.Index > reference) f.Index--;
                }
            }
            _images.RemoveAt(reference);
        }

        /// <summary>
        /// Attempts to grab an image by using a direction and frame.
        /// </summary>
        /// <param name="direction">The name of the direction to get an image from.</param>
        /// <param name="frame">The frame in the direction to use.</param>
        /// <returns>null if it can't find an image or the System.Drawing.Image.</returns>
        public Image GetImage(string direction, int frame = 0)
        {
            Direction dir = _directions.FirstOrDefault(d => d.Name.Equals(direction));
            return dir == null ? null : _images[dir.Frames[frame].Index];
        }

        /// <summary>
        /// Gets or sets the spritesets width in pixels.
        /// </summary>
        public short SpriteWidth
        {
            get { return _frameWidth; }
            set { _frameWidth = value; }
        }

        /// <summary>
        /// Gets or sets the spritesets height in pixels.
        /// </summary>
        public short SpriteHeight
        {
            get { return _frameHeight; }
            set { _frameHeight = value; }
        }

        /// <summary>
        /// Returns an image based on the given index.
        /// </summary>
        /// <param name="index">The image index to use.</param>
        /// <returns>The System.Drawing.Image at the index.</returns>
        public Image GetImage(int index)
        {
            return _images[index];
        }

        /// <summary>
        /// Gets or sets the sprite Base of this Spriteset.
        /// </summary>
        public Base SpriteBase
        {
            get { return _spriteBase; }
            set { _spriteBase = value; }
        }

        /// <summary>
        /// Gets the list of directions for this spriteset.
        /// </summary>
        public List<Direction> Directions
        {
            get { return _directions; }
        }

        /// <summary>
        /// Gets the image list of this spriteset.
        /// </summary>
        public List<Bitmap> Images
        {
            get { return _images; }
        }

        /// <summary>
        /// Returns an array of the directions in this spriteset.
        /// </summary>
        /// <returns>A string[] of the directions.</returns>
        public string[] GetDirections()
        {
            string[] dirs = new string[_directions.Count];
            for (int i = 0; i < _directions.Count; ++i)
                dirs[i] = _directions[i].Name;
            return dirs;
        }
    }

    /// <summary>
    /// Represents the base to a spriteset object:
    /// </summary>
    public class Base
    {
        /// <summary>
        /// The upper-left x location.
        /// </summary>
        public short X1 = 0;
        
        /// <summary>
        /// The upper-left y location.
        /// </summary>
        public short Y1 = 15;
        
        /// <summary>
        /// The lower-right x location.
        /// </summary>
        public short X2 = 15;

        /// <summary>
        /// the lower-right y location.
        /// </summary>
        public short Y2 = 31;

        /// <summary>
        /// Gets the height of the spriteset Base.
        /// </summary>
        public int Height
        {
            get { return Y2 - Y1; }
        }

        /// <summary>
        /// Gets the width of the spriteset Base.
        /// </summary>
        public int Width
        {
            get { return X2 - X1; }
        }

        /// <summary>
        /// Returns the base as a .NET retcangle object. Or constructs a base from a .NET rectangle.
        /// </summary>
        public Rectangle Rectangle
        {
            get { return new Rectangle(X1, Y1, Width, Height); }
            set
            {
                X1 = (short)value.X;
                Y1 = (short)value.Y;
                X2 = (short)(value.X + value.Width);
                Y2 = (short)(value.Y + value.Height);
            }
        }
    }

    /// <summary>
    /// A frame of a spriteset direction.
    /// </summary>
    public class Frame
    {
        /// <summary>
        /// Creates a new, empty frame.
        /// </summary>
        public Frame() { Delay = 8; }

        /// <summary>
        /// Gets or sets the delay of this Frame.
        /// </summary>
        public short Delay { get; set; }

        /// <summary>
        /// Gets or sets the index of this Frame.
        /// </summary>
        public short Index { get; set; }
    }

    /// <summary>
    /// A representation of a spriteset direction.
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// The frames used witnin this Direction.
        /// </summary>
        public List<Frame> Frames { get; set; }

        /// <summary>
        /// Creates a new direction with the given name.
        /// </summary>
        /// <param name="name">Name of the direction.</param>
        public Direction(string name)
        {
            Frames = new List<Frame>();
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name of this Direction.
        /// </summary>
        public string Name { get; set; }
    }
}
