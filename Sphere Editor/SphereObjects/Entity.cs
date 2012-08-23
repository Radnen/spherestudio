using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Drawing;

namespace Sphere_Editor.SphereObjects
{
    public class Entity : IDisposable
    {
        #region attributes
        public short X { get; set; }
        public short Y { get; set; }
        public short Layer { get; set; }
        public string Name { get; set; }
        public string Spriteset { get;  set; }
        public string Function { get; set; }
        public List<string> Scripts { get; private set; }
        public Spriteset Sprite { get; set; }
        public Image Graphic { get; set; }
        public bool Visible { get; set; }
        private short _type;
        #endregion

        public Entity()
        {
            Graphic = new Bitmap(Sphere_Editor.Properties.Resources.person);
            Sprite = new Spriteset();
            Scripts = new List<string>();
            for (int i = 0; i < 5; ++i) Scripts.Add("");
        }

        public Entity(BinaryReader stream)
        {
            X = stream.ReadInt16();
            Y = stream.ReadInt16();
            Layer = stream.ReadInt16();
            Scripts = new List<string>();
            _type = stream.ReadInt16();
            stream.ReadBytes(8);

            short len;
            switch (_type)
            {
                case 1: // player:
                    len = stream.ReadInt16();
                    Name = new string(stream.ReadChars(len));
                    len = stream.ReadInt16();
                    Spriteset = new string(stream.ReadChars(len));
                    Sprite = new Spriteset();
                    int scripts = stream.ReadInt16();

                    // read the person script data
                    for (int i = 0; i < scripts; ++i)
                    {
                        len = stream.ReadInt16();
                        Scripts.Add(new string(stream.ReadChars(len)));
                    }

                    stream.ReadBytes(16); // reserved
                    Graphic = new Bitmap(Sphere_Editor.Properties.Resources.person);
                    //LoadSpriteset();
                break;
                case 2: // trigger:
                    len = stream.ReadInt16();
                    Function = new string(stream.ReadChars(len));
                    Graphic = new Bitmap(Sphere_Editor.Properties.Resources.trigger);
                break;
            }
        }

        internal void Save(BinaryWriter binwrite)
        {
            // Header Data //
            binwrite.Write(X);
            binwrite.Write(Y);
            binwrite.Write(Layer);
            binwrite.Write(_type);
            binwrite.Write(new byte[8]);

            // Type Data //
            if (_type == 1)
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

        // utility function to determine the spriteset:
        public void LoadSpriteset()
        {
            bool loaded = Sprite.Load(Global.CurrentProject.Path + "/spritesets/" + Spriteset);
            if (Graphic != null) Graphic.Dispose();
            if (loaded)
            {
                Image temp = Sprite.GetImage("south", 0);
                if (temp != null) Graphic = new Bitmap(temp);
                else Graphic = new Bitmap(Sprite.Images[0]);
            }
            else Graphic = new Bitmap(Sphere_Editor.Properties.Resources.person);
        }

        public void DrawSprite(Graphics g, int tile_width, int tile_height, int off_x, int off_y, int zoom)
        {
            if (!Visible) return;
            int x_off = 0, y_off = 0;
            if (_type == 1)
            {
                x_off = Sprite.SpriteBase.x1;
                y_off = Sprite.SpriteBase.y1;
            }
            int x = (X / tile_width * tile_width) - x_off;
            int y = (Y / tile_height * tile_height) - y_off;
            g.DrawImage(Graphic, x * zoom - off_x, y * zoom - off_y, Graphic.Width * zoom, Graphic.Height * zoom);
        }

        public void Draw(Graphics g, int tile_width, int tile_height, ref Point offset, int zoom)
        {
            if (!Visible) return;
            int x = offset.X + (X / tile_width) * tile_width * zoom;
            int y = offset.Y + (Y / tile_height) * tile_height * zoom;
            g.DrawImage(Graphic, x, y, Graphic.Width * zoom, Graphic.Height * zoom);
        }

        public void FigureOutName(List<Entity> others)
        {
            string base_name = Path.GetFileNameWithoutExtension(Spriteset);
            string name = base_name + 1;

            int num = 1;
            for (int i = 0; i < others.Count; ++i)
            {
                if (others[i].Name == name)
                {
                    num++;
                    name = base_name + num;
                    i = 0;
                }
            }

            Name = name;
        }

        public Entity Copy()
        {
            Entity ent = new Entity();
            ent.X = X;
            ent.Y = Y;
            ent.Layer = Layer;
            ent._type = _type;
            ent.Visible = Visible;
            if (_type == 1)
            {
                string[] strings = new string[5];
                Scripts.CopyTo(strings);
                ent.Name = Name;
                ent.Scripts.Clear();
                ent.Scripts.AddRange(strings);
                ent.Spriteset = Spriteset;
                ent.LoadSpriteset();
            }
            else
            {
                ent.Function = Function;
                ent.Graphic = Sphere_Editor.Properties.Resources.trigger;
            }
            return ent;
        }

        public short Type
        {
            get { return _type; }
            set
            {
                _type = value;
                if (_type == 1) Graphic = Sphere_Editor.Properties.Resources.person;
                else Graphic = Sphere_Editor.Properties.Resources.trigger;
            }
        }

        private bool _disposed;
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
                    if (Sprite != null) Sprite.Dispose();
                    if (Graphic != null) Graphic.Dispose();
                }

                Graphic = null;
                Sprite = null;
            }
            _disposed = true;
        }
    }
}
