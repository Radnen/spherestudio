using System;
using System.Collections.Generic;
using System.IO;

namespace Sphere_Editor.SphereObjects
{
    public class Map : IDisposable
    {
        private short _version = 1;
        public short StartX { get; set; }
        public short StartY { get; set; }
        public byte StartLayer { get; set; }

        public List<string> Scripts { get; set; }
        public List<Layer> Layers { get; set; }
        public List<Entity> Entities { get; set; }
        public List<Zone2> Zones { get; set; }

        public int Width
        {
            get { return Layers[0].Width; }
        }

        public int Height
        {
            get { return Layers[0].Height; }
        }

        public Tileset2 Tileset { get; set; }
        public bool ErrorOnLoad { get; private set; }

        public Map()
        {
            Scripts = new List<string>();
            Layers = new List<Layer>();
            Entities = new List<Entity>();
            Zones = new List<Zone2>();
        }

        public void CreateNew(short width, short height, short tile_width, short tile_height, string tileset_path)
        {
            for (int i = 0; i < 9; ++i) Scripts.Add("");

            // create a base layer:
            Layer layer = new Layer();
            layer.CreateNew(width, height);
            Layers.Add(layer);

            // create a starting tile:
            Tileset = new Tileset2();

            if (string.IsNullOrEmpty(tileset_path))
                Tileset.CreateNew(tile_width, tile_height);
            else
            {
                Tileset = Tileset2.FromFile(tileset_path);
                Scripts[0] = Path.GetFileName(tileset_path);
            }
        }

        public bool Load(string filename)
        {
            if (!File.Exists(filename)) return false;

            int num_layers = 0;
            int num_entities = 0;
            int num_strings = 0;
            int num_zones = 0;

            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
            {
                // read header:
                reader.ReadChars(4);
                _version = reader.ReadInt16();
                reader.ReadByte();
                num_layers = reader.ReadByte();
                reader.ReadByte();
                num_entities = reader.ReadInt16();
                StartX = reader.ReadInt16();
                StartY = reader.ReadInt16();
                StartLayer = reader.ReadByte();
                reader.ReadByte();
                num_strings = reader.ReadInt16();
                num_zones = reader.ReadInt16();
                reader.ReadBytes(235);

                // read scripts:
                while (num_strings-- > 0)
                {
                    short length = reader.ReadInt16();
                    Scripts.Add(new string(reader.ReadChars(length)));
                }

                // read layers:
                while (num_layers-- > 0)
                    Layers.Add(Layer.FromBinary(reader));

                // read entities:
                while (num_entities-- > 0)
                    Entities.Add(new Entity(reader));

                // read zones:
                while (num_zones-- > 0)
                    Zones.Add(Zone2.FromBinary(reader));

                // read tileset:
                if (Scripts[0].Length == 0)
                    Tileset = Tileset2.FromBinary(reader);
                else
                {
                    string path = Path.GetDirectoryName(filename) + "\\" + Scripts[0];
                    Tileset = Tileset2.FromFile(path);
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

        public bool Save(string filename)
        {
            if (Scripts.Count == 0 || Scripts[0].Length == 0) return false;
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(filename)))
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
                writer.Write(new byte[235]);

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
                foreach (Zone2 z in Zones) z.Save(writer);

                writer.Flush();
            }

            string path = filename.Substring(0, filename.LastIndexOf("\\") + 1);
            Tileset.Save(path + Scripts[0]);
            
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;
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

        public void ResizeAllLayers(short lw, short lh)
        {
            foreach (Layer lay in Layers) lay.Resize(lw, lh);
        }

        public List<short[,]> CloneAllLayerTiles()
        {
            List<short[,]> list = new List<short[,]>(Layers.Count);
            foreach (Layer lay in Layers) list.Add(lay.CloneTiles());
            return list;
        }
    }
}
