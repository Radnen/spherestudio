using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Sphere_Editor.Bitmaps;
using Sphere_Editor.SphereObjects;
using Sphere_Editor.SpritesetComponents;
using Sphere_Editor.SubEditors;

namespace Sphere_Editor.EditorComponents
{
    public partial class TilesetControl : UserControl
    {
        #region private fields
        private List<Tile> tiles = new List<Tile>();
        private List<short> SelectedTiles = new List<short>();
        private List<int> SelectedX = new List<int>(), SelectedY = new List<int>();
        private short[] SelectedIndices = new short[0];
        private Bitmap SelectedMap;
        private short _selection, _zoom;
        private bool _ctrl, _multi_select, _is_multi = true;
        private bool can_drag, do_drag;
        private short tile_width = 16, tile_height = 16;
        private short version = 1, tile_bpp = 32;
        private byte compression, has_obstructions;
        private Pen TileRectPen = new Pen(Color.Black);
        private Pen TileSelPen = new Pen(Color.Blue, 2);
        private int twz = 16, thz = 16;
        private Point drag_start = Point.Empty;
        private bool can_insert = true;
        #endregion

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler TileSelected;

        public TilesetControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Zoom = 1;
        }

        public TilesetControl(BinaryReader stream)
        {
            ReadFromStream(stream);
            InitializeComponent();
            Zoom = 1;
        }

        public static TilesetControl FromSprite(Spriteset sprite)
        {
            TilesetControl tc = new TilesetControl();
            foreach (Bitmap b in sprite.Images) tc.AddTile(new Tile(b));
            tc.SetTileSize((short)sprite.Images[0].Width, (short)sprite.Images[0].Height);
            return tc;
        }

        public List<Bitmap> ToBitmapList()
        {
            List<Bitmap> list = new List<Bitmap>();
            foreach (Tile t in tiles) list.Add(t.Graphic);
            return list;
        }

        public TilesetControl(string fullpath)
        {
            BinaryReader bin = new BinaryReader(File.Open(fullpath, FileMode.Open));
            ReadFromStream(bin);
            bin.Close();
            InitializeComponent();
            Zoom = 1;
        }

        public TilesetControl(string filename, string parent_filename)
        {
            filename = Path.GetDirectoryName(parent_filename) + "\\" + filename;
            BinaryReader bin = new BinaryReader(File.Open(filename, FileMode.Open));
            ReadFromStream(bin);
            bin.Close();
            InitializeComponent();
            Zoom = 1;
        }

        public void Destroy()
        {
            foreach (Tile t in tiles) t.Graphic.Dispose();
            if (SelectedMap != null) SelectedMap.Dispose();
            TileSelPen.Dispose();
            TileRectPen.Dispose();
        }

        public void ReadFromStream(BinaryReader stream)
        {
            // Read Header //
            string sign = new string(stream.ReadChars(4));
            version = stream.ReadInt16();
            short num_tiles = stream.ReadInt16();
            
            SetTileSize(stream.ReadInt16(), stream.ReadInt16());

            tile_bpp = stream.ReadInt16();
            compression = stream.ReadByte();
            has_obstructions = stream.ReadByte();
            stream.ReadBytes(240);
            
            // data preallocated for the loop:
            int bit_size = tile_width * tile_height * (tile_bpp / 8);
            BitmapLoader loader = new BitmapLoader(tile_width, tile_height);
            Tile new_tile;

            while (num_tiles-- > 0)
            {
                new_tile = new Tile(tile_width, tile_height);
                new_tile.Graphic = loader.LoadFromStream(stream, bit_size);
                tiles.Add(new_tile);
            }

            // Read Tile Info Block: //
            foreach (Tile t in tiles)
            {
                stream.ReadByte();
                t.Animated = stream.ReadBoolean();
                t.NextAnim = stream.ReadInt16();
                t.Delay = stream.ReadInt16();
                stream.ReadByte();
                t.Blocked = stream.ReadByte();
                int segments = stream.ReadInt16();
                int amt = stream.ReadInt16();
                stream.ReadBytes(20);
                t.Name = new string(stream.ReadChars(amt));
                while (segments-- > 0)
                {
                    Line l = new Line(stream.ReadInt16(), stream.ReadInt16(), stream.ReadInt16(), stream.ReadInt16());
                    t.Obstructions.Add(l);
                }
            }
            loader.Close();
        }

        public void Save(string filename)
        {
            if (File.Exists(filename)) File.Delete(filename);
            BinaryWriter binwrite = new BinaryWriter(File.OpenWrite(filename));

            // Save Header Data //
            binwrite.Write(".rts".ToCharArray());
            binwrite.Write(version);
            binwrite.Write((short)tiles.Count);
            binwrite.Write(tile_width);
            binwrite.Write(tile_height);
            binwrite.Write(tile_bpp);
            binwrite.Write(compression);
            binwrite.Write(has_obstructions);
            binwrite.Write(new byte[240]);

            // Save Tiles //
            BitmapSaver saver = new BitmapSaver(tile_width, tile_height);
            foreach (Tile t in tiles) saver.SaveToStream(t.Graphic, binwrite);

            // Save Tile Info Block: //
            foreach (Tile t in tiles)
            {
                binwrite.Write(new byte());
                binwrite.Write(t.Animated);
                binwrite.Write(t.NextAnim);
                binwrite.Write(t.Delay);
                binwrite.Write(new byte());
                binwrite.Write(t.Blocked);
                binwrite.Write((short)t.Obstructions.Count);
                binwrite.Write((short)t.Name.Length);
                binwrite.Write(new byte[20]);
                binwrite.Write(t.Name.ToCharArray());
                foreach (Line l in t.Obstructions) 
                {
                    binwrite.Write(l.X1); binwrite.Write(l.Y1);
                    binwrite.Write(l.X2); binwrite.Write(l.Y2);
                }
            }

            binwrite.Flush();
            binwrite.Close();
        }

        #region getters and setters
        public short Selection
        {
            get { return _selection; }
            set
            {
                // select the new tile //
                _selection = value;
                // and remove of anything multi-selected //
                SelectedTiles.Clear();
                SelectedX.Clear();
                SelectedY.Clear();
                SelectedIndices = SelectedTiles.ToArray();
                if (TileSelected != null) TileSelected(this, new EventArgs());
            }
        }

        public List<Tile> Tiles
        {
            get { return this.tiles; }
        }

        public MapEditorControl ParentMap { get; set; }

        public Spriteset Sprite { get; set; }

        public bool CanInsert
        {
            get { return can_insert; }
            set { can_insert = value; }
        }

        public Int16 TileWidth
        {
            get { return tile_width; }
            set { tile_width = value; }
        }

        public Int16 TileHeight
        {
            get { return tile_height; }
            set { tile_height = value; }
        }

        /// <summary>
        /// If true, you can select multiple tiles.
        /// </summary>
        public bool IsMulti
        {
            get { return _is_multi; }
            set { _is_multi = value; }
        }

        /// <summary>
        /// If true, you can drag and drop tiles.
        /// </summary>
        public bool CanDrag
        {
            get { return can_drag; }
            set { can_drag = value; }
        }

        public short Zoom
        {
            get { return _zoom; }
            set { _zoom = value; twz = tile_width * value; thz = tile_height * value; }
        }
        #endregion

        /// <summary>
        /// Add's a blank black tile to the tileset.
        /// </summary>
        public void AddTile()
        {
            tiles.Add(new Tile(tile_width, tile_height));
            UpdateHeight();
        }

        /// <summary>
        /// Add's the tile object to the tileset.
        /// </summary>
        /// <param name="tile">Tile object to add</param>
        public void AddTile(Tile tile)
        {
            tiles.Add(tile);
        }

        public void DeleteTile(int index)
        {
            tiles.RemoveAt(index);
        }

        public void InsertTile(int index)
        {
            tiles.Insert(index, new Tile(tile_width, tile_height));
        }

        public Tile GetCurrentTile()
        {
            return tiles[Selection];
        }

        public Tile GetTile(int num)
        {
            return tiles[num];
        }

        public void SetTileImage(int num, Bitmap img)
        {
            tiles[num].Graphic = img;
        }

        public void SetTileSize(short width, short height)
        {
            tile_height = height;
            tile_width = width;
            Zoom = _zoom;
        }

        public short[] GetSelectedIndices()
        {
            return SelectedIndices;
        }

        public Bitmap GetTileMap()
        {
            return SelectedMap;
        }

        // very important!!
        public void CompileSelectedTiles()
        {
            List<short> list = new List<short>();

            // remove invalid tiles from map:
            while (SelectedTiles.Contains(-1)) SelectedTiles.Remove(-1);

            SelectedTiles.Sort();
            SelectedX.Sort();
            SelectedY.Sort();
            int index = 0;
            int woz = (Width / twz);
            int width = SelectedX[SelectedX.Count - 1] - SelectedX[0] + 1;
            int height = SelectedY[SelectedY.Count - 1] - SelectedY[0] + 1;

            int h = height * tile_height, w = width * tile_width;
            if (SelectedMap != null) SelectedMap.Dispose();
            SelectedMap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(SelectedMap);

            for (int y = SelectedY[0]; y < SelectedY[0] + height; ++y)
            {
                for (int x = SelectedX[0]; x < SelectedX[0] + width; ++x)
                {
                    if (index < SelectedTiles.Count && SelectedTiles[index] != x + y * woz)
                    {
                        SelectedTiles.Insert(index, -1);
                    }
                    index++;
                }
            }

            index = 0;
            for (int y = 0; y < h; y += tile_height)
            {
                for (int x = 0; x < w; x += tile_width)
                {
                    if (index < SelectedTiles.Count && SelectedTiles[index] != -1)
                    {
                        g.DrawImage(tiles[SelectedTiles[index]].Graphic, x, y, tile_width, tile_height);
                        list.Add(SelectedTiles[index]);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Gray, x, y, tile_width, tile_height);
                        list.Add(-1);
                    }
                    ++index;
                }
            }
            g.Dispose();
            SelectedIndices = list.ToArray();
        }

        private void Tileset_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            short index = 0;
            int width = Width / twz * twz;
            int height = (int)Math.Ceiling((float)tiles.Count / (float)(width / twz)) * thz;

            for (int y = 0; y < height; y += thz)
            {
                for (int x = 0; x < width; x += twz)
                {
                    if (index < tiles.Count)
                    {
                        e.Graphics.DrawImage(tiles[index].Graphic, x, y, twz, thz);
                        e.Graphics.DrawRectangle(TileRectPen, x, y, twz, thz);
                        if (_is_multi) MarkSelectedTile(index, x, y, twz, thz, e.Graphics);
                        if (index == Selection && SelectedTiles.Count == 0)
                            e.Graphics.DrawRectangle(TileSelPen, x, y, twz - 1, thz - 1);
                    }
                    ++index;
                }
            }
        }

        private void TilesetControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                int Selected = SelectedTiles.Count;
                if (Selected == 1) Selection = SelectedTiles[0];
                else if (Selected > 1)
                {
                    CompileSelectedTiles();
                    if (TileSelected != null) TileSelected(this, new EventArgs());
                }
                _multi_select = false;
                Refresh();
            }
            if (e.Button == MouseButtons.Right) TilesetContextMenu.Show(this, e.X, e.Y);
        }

        // internal function to grab a single tile under a x,y position //
        private short GetTileIndexAt(int x_pos, int y_pos)
        {
            int width = Width / twz;

            short index = (short)((x_pos / twz) + (y_pos / thz) * width);
            if (index < tiles.Count) return index;
            else return -1; // this means invalid
        }
        
        private void TilesetControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                drag_start = e.Location;
                do_drag = true;
                if (!_ctrl)
                {
                    SelectedTiles.Clear(); // if no ctrl-click, clear the selection.
                    SelectedX.Clear();
                    SelectedY.Clear();
                    SelectedIndices = SelectedTiles.ToArray();
                }
                short Current = GetTileIndexAt(e.X, e.Y);
                if (Current != -1)
                {
                    if (!_is_multi) _selection = Current;
                    if (!SelectedTiles.Contains(Current))
                    {
                        SelectedTiles.Add(Current);
                        SelectedX.Add(e.X / tile_width / Zoom);
                        SelectedY.Add(e.Y / tile_height / Zoom);
                    }
                    else if (_ctrl)
                    {
                        SelectedTiles.Remove(Current);
                        SelectedX.Remove(e.X / tile_width / Zoom);
                        SelectedY.Remove(e.Y / tile_height / Zoom);
                    }
                }
                _multi_select = true;
                Refresh();
            }
        }

        private void TilesetControl_MouseMove(object sender, MouseEventArgs e)
        {
            int w = Width / tile_width * tile_width;
            int h = Height / tile_height * tile_height;
            if (_is_multi && _multi_select && e.X > 0 && e.Y > 0 && e.X < w && e.Y < h)
            {
                short Current = GetTileIndexAt(e.X, e.Y);
                if (Current != -1 && !SelectedTiles.Contains(Current))
                {
                    SelectedTiles.Add(Current);
                    SelectedX.Add(e.X / tile_width / Zoom);
                    SelectedY.Add(e.Y / tile_height / Zoom);
                    Refresh();
                }
            }

            if (CanDrag && do_drag && _selection != -1)
            {
                int xx = drag_start.X - e.X;
                int yy = drag_start.Y - e.Y;
                if (Math.Sqrt(xx * xx + yy * yy) > 4)
                {
                    Frame frame = new Frame();
                    frame.Index = (short)_selection;
                    DoDragDrop(new DataObject("ImageFrame", frame), DragDropEffects.All);
                    do_drag = false;
                }
            }
        }

        private void MarkSelectedTile(short index, int x, int y, int w, int h, Graphics g)
        {
            if (!SelectedTiles.Contains(index)) return;
            Rectangle rect = new Rectangle(x, y, w - 1, h - 1);
            g.FillRectangle(new SolidBrush(Color.FromArgb(80, 0, 0, 255)), rect);
        }

        /// <summary>
        /// Forces the control to adjust its height to its container object.
        /// </summary>
        public void UpdateHeight()
        {
            int width = (int)Math.Floor((float)Width / twz);
            int height = (int)Math.Ceiling((float)tiles.Count / (float)width) * thz;
            if (Parent != null)
            {
                if (height < Parent.Height) Height = Parent.Height;
                else Height = height;
            }
            else Height = height;
        }

        public void ResizeAllTiles(short width, short height)
        {
            SetTileSize(width, height);
            Bitmap img;
            foreach (Tile t in tiles)
            {
                img = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(img);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImageUnscaled(t.Graphic, 0, 0);
                g.Dispose();
                t.Graphic = img;
            }
        }

        public void RescaleAllTiles(short width, short height)
        {
            SetTileSize(width, height);
            Bitmap img;
            foreach (Tile t in tiles)
            {
                img = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(img);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.DrawImage(t.Graphic, 0, 0, width, height);
                g.Dispose();
                t.Graphic = img;
            }
        }

        private void TilesetControl_Resize(object sender, EventArgs e)
        {
            UpdateHeight();
            Refresh();
        }

        #region Drop Down Items
        private void AppendTileItem_Click(object sender, EventArgs e)
        {
            AddTile();
            if (Sprite != null) Sprite.Images.Add(new Bitmap(Sprite.SpriteWidth, Sprite.SpriteHeight));
            Refresh();
        }

        private void ZoomInItem_Click(object sender, EventArgs e)
        {
            if (Zoom < 4) { Zoom <<= 1; ZoomOutItem.Enabled = true; }
            if (Zoom == 4) ZoomInItem.Enabled = false;
            UpdateHeight();
            Refresh();
        }

        private void ZoomOutItem_Click(object sender, EventArgs e)
        {
            if (Zoom > 1) { Zoom >>= 1; ZoomInItem.Enabled = true; }
            if (Zoom == 1) ZoomOutItem.Enabled = false;
            UpdateHeight();
            Refresh();
        }

        private void RestoreZoomItem_Click(object sender, EventArgs e)
        {
            Zoom = 1;
            ZoomOutItem.Enabled = false;
            ZoomInItem.Enabled = true;
            UpdateHeight();
            Refresh();
        }

        private void TilesetContextMenu_Opened(object sender, EventArgs e)
        {
            DeleteTileMenuItem.Enabled = (tiles.Count > 1);
            InsertTileItem.Visible = DuplicateTile.Visible = can_insert;
        }

        private void DeleteTileMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTile(Selection);
            if (ParentMap != null) ParentMap.DoAllLayerAdjustment(Selection, -1);
            if (Sprite != null) Sprite.RemoveBadReference(Selection);

            if (Selection == tiles.Count) Selection--;
            else Selection = Selection; // this is just to refresh the on_selection event.
            Refresh();
        }

        private void InsertTileItem_Click(object sender, EventArgs e)
        {
            InsertTile(Selection);
            if (ParentMap != null) ParentMap.DoAllLayerAdjustment(Selection, 1);
            Selection = Selection;
            Refresh();
        }

        private void DuplicateTile_Click(object sender, EventArgs e)
        {
            Tile NewTile = tiles[Selection].Clone();
            if (Selection < tiles.Count) InsertTile(Selection + 1);
            else AddTile();
            tiles[Selection + 1] = NewTile;
            ParentMap.DoAllLayerAdjustment(Selection, 1);
            Refresh();
        }
        #endregion

        // create a handle for ctrl-key click
        private void TilesetControl_KeyDown(object sender, KeyEventArgs e)
        {
            _ctrl = (e.KeyCode == Keys.ControlKey);
        }

        private void TilesetControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _ctrl = false;
        }

        private void TilesetControl_Load(object sender, EventArgs e)
        {
            UpdateHeight();
        }

        public void ExportAsImage(string filename)
        {
            int index = 0;
            int width = (int)Math.Floor((float)Width / (tile_width * Zoom)) * tile_width;
            int height = (int)Math.Floor((float)Height / (tile_height * Zoom)) * tile_height;
            Bitmap img = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img);

            for (int y = 0; y < height; y += tile_height)
            {
                for (int x = 0; x < width; x += tile_width)
                {
                    if (index < tiles.Count)
                    {
                        g.DrawImage(tiles[index].Graphic, x, y);
                        index++;
                    }
                }
            }
            
            img.Save(filename);
            g.Dispose();
            img.Dispose();
        }

        public void UpdateFromImage(string filename, int tile_width, int tile_height)
        {
            Bitmap img = (Bitmap)Image.FromFile(filename);
            int width = img.Width;
            int height = img.Height;
            int index = 0;

            Rectangle rect;
            for (int y = 0; y < height; y += tile_height)
            {
                for (int x = 0; x < width; x += tile_width)
                {
                    rect = new Rectangle(x, y, tile_width, tile_height);
                    tiles[index].Graphic = img.Clone(rect, PixelFormat.Format32bppArgb);
                    if (Sprite != null) Sprite.Images[index] = tiles[index].Graphic;
                    index++;
                    if (index == tiles.Count) return;
                }
            }
            img.Dispose();
        }
    }
}
