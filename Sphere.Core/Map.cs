using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sphere.Core
{
    /// <summary>
    /// A Sphere map object.
    /// </summary>
    public class Map : IDisposable
    {
        private readonly Encoding ISO_8859_1 = Encoding.GetEncoding("iso-8859-1");
            
        #region Attributes
        private short _version = 1;

        /// <summary>
        /// Gets or sets whether the map wraps around at the edges (i.e. a repeating map)
        /// </summary>
        public bool WrapAround { get; set; }
        
        /// <summary>
        /// Gets or sets the starting x position.
        /// </summary>
        public short StartX { get; set; }

        /// <summary>
        /// Gets or sets the starting y position.
        /// </summary>
        public short StartY { get; set; }

        /// <summary>
        /// Gets or sets the start layer.
        /// </summary>
        public byte StartLayer { get; set; }

        /// <summary>
        /// Gets a list of string used by this Map.
        /// </summary>
        public List<string> Scripts { get; private set; } = new List<string>();

        /// <summary>
        /// Gets or sets a list of layers used by this Map.
        /// </summary>
        public List<Layer> Layers { get; set; } = new List<Layer>();

        /// <summary>
        /// Gets a list of entities used by this Map.
        /// </summary>
        public List<Entity> Entities { get; private set; } = new List<Entity>();

        /// <summary>
        /// Gets a list of zones used by this map.
        /// </summary>
        public List<Zone> Zones { get; private set; } = new List<Zone>();

        /// <summary>
        /// Gets the width of the zero'th layer in the map.
        /// </summary>
        public int Width
        {
            get { return Layers[0].Width; }
        }

        /// <summary>
        /// Gets the height of the zero'th layer in the Map.
        /// </summary>
        public int Height
        {
            get { return Layers[0].Height; }
        }

        /// <summary>
        /// Gets or sets the tileset associated with this map.
        /// </summary>
        public Tileset Tileset { get; set; }

        /// <summary>
        /// Gets if the map had an error while loading.
        /// </summary>
        public bool ErrorOnLoad { get; private set; }
        #endregion

        /// <summary>
        /// Creates a new, empty map.
        /// </summary>
        public Map() { }

        /// <summary>
        /// Creates a new map with values.
        /// </summary>
        /// <param name="width">The width in tiles.</param>
        /// <param name="height">The height in tiles.</param>
        /// <param name="tileWidth">The tilewidth in pixels.</param>
        /// <param name="tileHeight">The tileheight in pixels.</param>
        /// <param name="tilesetPath">The path to the tileset.</param>
        public void CreateNew(short width, short height, short tileWidth, short tileHeight, string tilesetPath)
        {
            for (int i = 0; i < 9; ++i) Scripts.Add("");

            // create a base layer:
            Layer layer = new Layer();
            layer.CreateNew(width, height);
            Layers.Add(layer);

            // create a starting tile:
            Tileset = new Tileset();

            if (string.IsNullOrEmpty(tilesetPath))
                Tileset.CreateNew(tileWidth, tileHeight);
            else
            {
                Tileset = Tileset.FromFile(tilesetPath);
                Scripts[0] = Path.GetFileName(tilesetPath);
            }
        }

        /// <summary>
        /// Loads a map from the given filename.
        /// </summary>
        /// <param name="filename">The filename of the map.</param>
        /// <returns>True if the load was a success.</returns>
        public bool Load(string filename)
        {
            if (!File.Exists(filename)) return false;

            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename), ISO_8859_1))
            {
                // read header:
                reader.ReadChars(4);
                _version = reader.ReadInt16();
                reader.ReadByte();
                int numLayers = reader.ReadByte();
                reader.ReadByte();
                int numEntities = reader.ReadInt16();
                StartX = reader.ReadInt16();
                StartY = reader.ReadInt16();
                if ((StartLayer = reader.ReadByte()) >= numLayers)
                    StartLayer = 0;  // fix up out-of-range layer
                reader.ReadByte();
                int numStrings = reader.ReadInt16();
                int numZones = reader.ReadInt16();
                WrapAround = reader.ReadBoolean();
                reader.ReadBytes(234);

                // read scripts:
                while (numStrings-- > 0)
                {
                    short length = reader.ReadInt16();
                    Scripts.Add(new string(reader.ReadChars(length)));
                }

                // read layers:
                for (int i = 0; i < numLayers; ++i)
                {
                    Layers.Add(Layer.FromBinary(reader));
                }

                // read entities:
                while (numEntities-- > 0)
                {
                    Entity entity = new Entity(reader);
                    if (entity.Layer >= numLayers)
                        entity.Layer = 0;  // fix up out-of-range layer
                    Entities.Add(entity);
                }

                // read zones:
                while (numZones-- > 0)
                {
                    var zone = Zone.FromBinary(reader);
                    if (zone.Layer >= numLayers)
                        zone.Layer = 0;  // fix up out-of-range layer
                    Zones.Add(zone);
                }

                // read tileset:
                if (Scripts[0].Length == 0)
                {
                    Tileset = Tileset.FromBinary(reader);
                }
                else
                {
                    string path = Path.GetDirectoryName(filename) + "\\" + Scripts[0];
                    Tileset = Tileset.FromFile(path);
                }

                // init all layers:
                bool validated = true;
                foreach (Layer layer in Layers)
                {
                    validated = layer.Validate(Tileset.Tiles.Count);
                }
                ErrorOnLoad = !validated;
            }

            return true;
        }

        /// <summary>
        /// Attempts to save the map to the given filename.
        /// </summary>
        /// <param name="filename">The path to save the Map to.</param>
        /// <returns>True if the save was successful.</returns>
        public bool Save(string filename)
        {
            if (Scripts.Count == 0 || Scripts[0].Length == 0) return false;
            using (BinaryWriter writer = new BinaryWriter(File.Create(filename), ISO_8859_1))
            {
                // write header:
                writer.Write(".rmp".ToCharArray());
                writer.Write(_version);
                writer.Write(byte.MinValue);
                writer.Write((byte)Layers.Count);
                writer.Write(byte.MinValue);
                writer.Write((short)Entities.Count);
                writer.Write(StartX);
                writer.Write(StartY);
                writer.Write(StartLayer);
                writer.Write(byte.MinValue);
                writer.Write((short)Scripts.Count);
                writer.Write((short)Zones.Count);
                writer.Write(WrapAround);
                writer.Write(new byte[234]);

                // write scripts:
                foreach (string s in Scripts)
                {
                    writer.Write((short)s.Length);
                    writer.Write(s.ToCharArray());
                }

                // save layers:
                foreach (Layer l in Layers) l.Save(writer);

                // save entities:
                foreach (Entity e in Entities) e.Save(writer);

                // save zones:
                foreach (Zone z in Zones) z.Save(writer);

                writer.Flush();
            }

            string path = filename.Substring(0, filename.LastIndexOf("\\", StringComparison.Ordinal) + 1);
            Tileset.Save(path + Scripts[0]);
            
            return true;
        }

        /// <summary>
        /// Disposes and clears this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    foreach (Entity e in Entities) e.Dispose();
                    if (Tileset != null) Tileset.Dispose();
                    Layers.Clear();
                }
                Layers = null;
                Tileset = null;
                Entities = null;
            }
            _disposed = true;
        }

        /// <summary>
        /// Resizes the map's layers to the new size.
        /// </summary>
        /// <param name="width">The new width in tiles.</param>
        /// <param name="height">The new height in tiles.</param>
        public void ResizeAllLayers(short width, short height)
        {
            foreach (Layer lay in Layers) lay.Resize(width, height);
        }

        /// <summary>
        /// Returns a list of copied tiles of each layer.
        /// </summary>
        /// <returns>A list of cloned layer tiles.</returns>
        public List<short[,]> CloneAllLayerTiles()
        {
            List<short[,]> list = new List<short[,]>(Layers.Count);
            list.AddRange(Layers.Select(lay => lay.CloneTiles()));
            return list;
        }
    }
}
