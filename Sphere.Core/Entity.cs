using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace Sphere.Core
{
    /// <summary>
    /// A representation of an entity.
    /// </summary>
    public class Entity : IDisposable
    {
        #region attributes
        /// <summary>
        /// Gets or sets the x location of this Entity in pixels.
        /// </summary>
        public short X { get; set; }

        /// <summary>
        /// Gets or sets the y location of this Entity in pixels.
        /// </summary>
        public short Y { get; set; }

        /// <summary>
        /// Gets or sets the layer index of this Entity.
        /// </summary>
        public short Layer { get; set; }

        /// <summary>
        /// Gets or sets the name of this entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the spriteset filename of this entity.
        /// </summary>
        public string Spriteset { get;  set; }

        /// <summary>
        /// Gets or sets the JS function of this Entity.
        /// </summary>
        public string Function { get; set; }

        /// <summary>
        /// Gets the list of string associated with this Entity.
        /// </summary>
        public List<string> Scripts { get; private set; }

        /// <summary>
        /// Gets or sets the visibility of this Entity.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the Entity.EntityType of this Entity.
        /// </summary>
        public EntityType Type { get; set; }

        private Image _graphic;
        private bool _disposed;
        #endregion

        /// <summary>
        /// A Sphere entity type.
        /// </summary>
        public enum EntityType
        {
            /// <summary>
            /// A Sphere Person type.
            /// </summary>
            Person = 1,

            /// <summary>
            /// A Sphere Trigger type.
            /// </summary>
            Trigger = 2
        };

        /// <summary>
        /// Creates a new Entity with the supplied type.
        /// </summary>
        /// <param name="type">The Entity.EntityType to use.</param>
        public Entity(EntityType type)
        {
            Type = type;
            Scripts = new List<string>();
            for (int i = 0; i < 5; ++i) Scripts.Add("");
            if (type == EntityType.Person)
                _graphic = new Bitmap(Properties.Resources.person);
            else
                _graphic = new Bitmap(Properties.Resources.trigger);
        }

        /// <summary>
        /// Creates a new entity that was embedded next in the stream
        /// </summary>
        /// <param name="stream">The System.IO.BinaryReader to use.</param>
        public Entity(BinaryReader stream)
        {
            X = stream.ReadInt16();
            Y = stream.ReadInt16();
            Layer = stream.ReadInt16();
            Scripts = new List<string>();
            Type = (EntityType)stream.ReadInt16();
            stream.ReadBytes(8);

            short len;
            if (Type == EntityType.Person)
            {
                len = stream.ReadInt16();
                Name = new string(stream.ReadChars(len));
                len = stream.ReadInt16();
                Spriteset = new string(stream.ReadChars(len));
                int scripts = stream.ReadInt16();

                // read the person script data
                for (int i = 0; i < scripts; ++i)
                {
                    len = stream.ReadInt16();
                    Scripts.Add(new string(stream.ReadChars(len)));
                }

                stream.ReadBytes(16); // reserved
                _graphic = new Bitmap(Properties.Resources.person);
            }
            else
            {
                len = stream.ReadInt16();
                Function = new string(stream.ReadChars(len));
                _graphic = new Bitmap(Properties.Resources.trigger);
            }
        }

        /// <summary>
        /// Saves the entity, embedding it into a file stream.
        /// </summary>
        /// <param name="binwrite">The System.IO.BinaryWriter to use.</param>
        public void Save(BinaryWriter binwrite)
        {
            // Header Data //
            binwrite.Write(X);
            binwrite.Write(Y);
            binwrite.Write(Layer);
            binwrite.Write((short)Type);
            binwrite.Write(new byte[8]);

            // Type Data //
            if (Type == EntityType.Person)
            {
                binwrite.Write((short)Name.Length);
                binwrite.Write(Name.ToCharArray());
                binwrite.Write((short)Spriteset.Length);
                binwrite.Write(Spriteset.ToCharArray());

                binwrite.Write((short)Scripts.Count);
                foreach (string s in Scripts)
                {
                    binwrite.Write((short)s.Length);
                    binwrite.Write(s.ToCharArray());
                }
                binwrite.Write(new byte[16]);
            }
            else
            {
                binwrite.Write((short)Function.Length);
                binwrite.Write(Function.ToCharArray());
            }
        }

        /// <summary>
        /// Get an image representation of this trigger / person
        /// </summary>
        /// <param name="rootpath">The root path of the project to find the spriteset.</param>
        /// <returns>A System.Draw.Bitmap representing the entity.</returns>
        public Image GetSSImage(string rootpath)
        {
            if (Type == EntityType.Trigger) return Properties.Resources.trigger;
            using (var s = new Spriteset())
            {
                if (s.Load(rootpath + "/spritesets/" + Spriteset))
                {
                    Image img = s.GetImage("south");
                    if (img == null && s.Images.Count > 0) img = s.Images[0];
                    if (img != null)
                    {
                        return s.Images.Count == 0 ? Properties.Resources.person : new Bitmap(img);
                    }
                }
                return Properties.Resources.person;
            }
        }

        /// <summary>
        /// Draws this Entity onto a System.Drawing.Graphics object.
        /// </summary>
        /// <param name="g">The System.Drawing.Graphics object to use.</param>
        /// <param name="tileWidth">The tile width for the map.</param>
        /// <param name="tileHeight">The tile height for the map.</param>
        /// <param name="offset">The x/y offset to draw at.</param>
        /// <param name="zoom">The zoom factor of the map.</param>
        public void Draw(Graphics g, int tileWidth, int tileHeight, ref Point offset, int zoom)
        {
            if (!Visible) return;
            int x = offset.X + (X / tileWidth) * tileWidth * zoom;
            int y = offset.Y + (Y / tileHeight) * tileHeight * zoom;
            g.DrawImage(_graphic, x, y, _graphic.Width * zoom, _graphic.Height * zoom);
        }

        /// <summary>
        /// Used along with a list of others, it makes a unique name for this entity.
        /// </summary>
        /// <param name="others">A List of other types</param>
        public void FigureOutName(List<Entity> others)
        {
            string baseName = Path.GetFileNameWithoutExtension(Spriteset);
            string name = baseName + 1;

            int num = 1;
            for (int i = 0; i < others.Count; ++i)
            {
                if (others[i].Name == name)
                {
                    num++;
                    name = baseName + num;
                    i = 0;
                }
            }

            Name = name;
        }

        /// <summary>
        /// Creates a perfect copy of this entity.
        /// </summary>
        /// <returns>A copy of the Entity.</returns>
        public Entity Copy()
        {
            Entity ent = new Entity(Type) {X = X, Y = Y, Layer = Layer, Visible = Visible};
            if (Type == EntityType.Person)
            {
                string[] strings = new string[5];
                Scripts.CopyTo(strings);
                ent.Name = Name;
                ent.Scripts.Clear();
                ent.Scripts.AddRange(strings);
                ent.Spriteset = Spriteset;
                ent._graphic = new Bitmap(Properties.Resources.person);
            }
            else if (Type == EntityType.Trigger)
            {
                ent.Function = Function;
                ent._graphic = new Bitmap(Properties.Resources.trigger);
            }
            return ent;
        }

        /// <summary>
        /// Dispose and close this object.
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
                    if (_graphic != null) _graphic.Dispose();
                }

                _graphic = null;
            }
            _disposed = true;
        }

        /// <summary>
        /// Gets a list of sprite directions fgor this person object:
        /// </summary>
        /// <param name="rootpath">The root path to find the spriteset with.</param>
        /// <returns>A list of spriteset directions.</returns>
        public string[] GetSpriteDirections(string rootpath)
        {
            using (Spriteset s = new Spriteset())
            {
                if (s.Load(rootpath + "/spritesets/" + Spriteset))
                {
                    return s.GetDirections();
                }
            }
            return null;
        }
    }
}
