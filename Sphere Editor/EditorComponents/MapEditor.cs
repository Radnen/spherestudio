using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere_Editor.Forms;
using Sphere_Editor.SphereObjects;

namespace Sphere_Editor.EditorComponents
{
    public partial class MapEditorControl : UserControl
    {
        public static Pen zone_pen = new Pen(Color.Red);
        public static Brush zone_brush = new SolidBrush(Color.FromArgb(25, Color.Red));
        public List<Layer> Layers = new List<Layer>();
        public List<Entity> Entities = new List<Entity>();
        public TilesetControl Tileset = new TilesetControl();
        public AutosetEditor Autoset = null;
        public ToolStripStatusLabel TileStatusLabel = null;
        public ToolStripStatusLabel EntityStatusLabel = null;

        #region private data
        private Pen TileRectPen = new Pen(Color.Yellow);
        private Pen ToolPen = new Pen(Color.Blue, 4);
        private bool _ctrl = false; // ctrl-click handler
        private int cur_pos; // current position in undo history
        private int cur_x; // this is for current mouse 'x' position
        private int cur_y; // this is for current mouse 'y' position
        private int tool_x; // this is for tool origin 'x'
        private int tool_y; // this is for tool origin 'y'
        private int _layer, _h, _w, x_off, y_off; // current layer, ...
        private int _zoom = 1; // current zoom level
        private int base_width; // base width
        private int base_height; // base height
        private int tool_num; // 0 = pencil, 1 = line, 2 = rect, 3 = fill, 4, 5, 6 = autotile
        private List<List<Layer>> LayerHistory = new List<List<Layer>>();
        private Control dummy;
        private short tile_width = 16, tile_height = 16;
        private bool _paint = false, _copied_ent = false, _new_ent = false;
        private short[] stamp_map = new short[0];
        private int stamp_width = 1, stamp_height = 1;
        private int twz = 16; // tile width * zoom.
        private int thz = 16; // tile height * zoom. These get precaculated for performance.
        private int start_x, start_y;
        private int last_x, last_y;
        private int last_x_off, last_y_off;
        private string file_name = "";
        private Entity selected_ent = null;
        #endregion

        public event EventHandler LayerChanged;
        public event EventHandler StartChanged;
        public event EventHandler MapEdited;

        #region Map Header
        public class Header
        {
            Int16 version = 1;
            byte layers = 0;
            Int16 num_entities = 0;
            Int16 start_x = 0;
            Int16 start_y = 0;
            Int16 start_layer = 0;
            Int16 start_direction = 0;
            Int16 num_strings = 9;
            Int16 num_zones = 0;
            public List<string> Scripts = new List<string>(9);

            public Header() { }

            public Int16 VersionNum
            {
                get { return version; }
                set { version = value; }
            }

            public byte LayerNum
            {
                get { return layers; }
                set { layers = value; }
            }

            public Int16 EntityNum
            {
                get { return num_entities; }
                set { num_entities = value; }
            }

            public Int16 StartX
            {
                get { return start_x; }
                set { start_x = value; }
            }

            public Int16 StartY
            {
                get { return start_y; }
                set { start_y = value; }
            }

            public Int16 StartLayer
            {
                get { return start_layer; }
                set { start_layer = value; }
            }

            public Int16 StartDirection
            {
                get { return start_direction; }
                set { start_direction = value; }
            }

            public Int16 StringNum
            {
                get { return num_strings; }
                set { num_strings = value; }
            }

            public Int16 ZoneNum
            {
                get { return num_zones; }
                set { num_zones = value; }
            }
        }
        #endregion

        private Header header = new Header();

        #region getters and setters
        public Header MapHeader
        {
            get { return header; }
        }

        public short StartLayer
        {
            get { return header.StartLayer; }
            set { header.StartLayer = value; }
        }

        public short TileWidth
        {
            get { return tile_width; }
            set { tile_width = value; }
        }

        public short TileHeight
        {
            get { return tile_height; }
            set { tile_height = value; }
        }

        public int ToolNum
        {
            get { return tool_num; }
            set { tool_num = value; }
        }

        public int LayerNum
        {
            get { return _layer; }
            set { _layer = value; }
        }

        public int BaseHeight
        {
            get { return base_height; }
            set { base_height = value; }
        }

        public int BaseWidth
        {
            get { return base_width; }
            set { base_width = value; }
        }

        public int ZoomLevel
        {
            get { return _zoom; }
        }

        public string Filename
        {
            get { return file_name; }
        }

        /// <summary>
        /// True if you can undo; false if not.
        /// </summary>
        public bool IsUndoable
        {
            get { return (cur_pos > 0); }
        }

        /// <summary>
        /// True if you can redo; false if not.
        /// </summary>
        public bool IsRedoable
        {
            get { return (cur_pos < LayerHistory.Count - 1); }
        }
        #endregion

        public MapEditorControl()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            // a work-around for the autoscroll:
            dummy = new Control("test", 0, 0, 0, 0);
            dummy.Enabled = false;
            Controls.Add(dummy);
            InitializeComponent();
            Tileset.ParentMap = this;
        }

        #region scroll stuff
        // used to ignore dummy nodes movement:
        protected override Point ScrollToControl(Control activeControl)
        {
            return DisplayRectangle.Location;
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            if (se.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                last_x_off = x_off;
                x_off = (se.NewValue / _zoom);
            }
            else
            {
                last_y_off = y_off;
                y_off = (se.NewValue / _zoom);
            }
            if (last_x_off != x_off || last_y_off != y_off)
            {
                foreach (Layer l in Layers) l.UpdateTileOffset(x_off, y_off);
                UpdateAllLayers();
            }
            else Refresh();
        }
        
        public void UpdateScrollbars()
        {
            int x = (Layers[0].Width - Width / twz);
            int y = (Layers[0].Height - Height / thz);

            AutoScrollMinSize = new System.Drawing.Size(Width-19, Height-19);
            AutoScrollMargin = new System.Drawing.Size(x * _zoom, y * _zoom);

            HorizontalScroll.SmallChange = 1 * _zoom;
            HorizontalScroll.LargeChange = 5 * _zoom;
            VerticalScroll.SmallChange = 1 * _zoom;
            VerticalScroll.LargeChange = 5 * _zoom;
        }

        private void UpdateControlSize()
        {
            Width = Math.Min(Parent.Width, _w);
            Height = Math.Min(Parent.Height, _h);
            foreach (Layer l in Layers) l.UpdateDrawingWindow(Width + twz, Height + thz);
            UpdateAllLayers();
        }

        /// <summary>
        /// Positions the object in the middle of its container.
        /// Also toggles scrollbars where apropriate.
        /// </summary>
        public void UpdateControl()
        {
            UpdateControlSize();
            if (Width < Parent.Width && Height < Parent.Height)
                Location = new Point(Parent.Width / 2 - Width / 2, Parent.Height / 2 - Height / 2);
            else if (Width < Parent.Width)
                Location = new Point(Parent.Width / 2 - Width / 2, 0);
            else if (Height < Parent.Height)
                Location = new Point(0, Parent.Height / 2 - Height / 2);
            else Location = Point.Empty;
            UpdateScrollbars();
            Invalidate(true);
        }
        #endregion

        #region load and save
        public void LoadMap(string filename)
        {
            if (!File.Exists(filename)) return;
            BinaryReader binread = new BinaryReader(File.OpenRead(filename));

            this.file_name = filename;

            // Read header data //
            string signature = new string(binread.ReadChars(4));
            header.VersionNum = binread.ReadInt16();
            binread.ReadByte(); // obsolete
            header.LayerNum = binread.ReadByte();
            binread.ReadByte(); // reserved
            header.EntityNum = binread.ReadInt16();
            header.StartX = binread.ReadInt16(); // I forgot that it saved -
            header.StartY = binread.ReadInt16(); // with player coords.
            header.StartLayer = binread.ReadByte();
            header.StartDirection = binread.ReadByte();
            header.StringNum = binread.ReadInt16();
            header.ZoneNum = binread.ReadInt16();
            binread.ReadBytes(235); // reserved

            // Read script data:
            int i = header.StringNum;
            while(i-- > 0)
            {
                short length = binread.ReadInt16();
                header.Scripts.Add(new string(binread.ReadChars(length)));
            }

            // Create layers:
            Layer lay;
            i = header.LayerNum;
            while(i-- > 0)
            {
                lay = new Layer(binread);
                base_width = Math.Max(base_width, lay.Width);
                base_height = Math.Max(base_height, lay.Height);
                Layers.Add(lay);
            }

            // Create entities:
            i = header.EntityNum;
            while(i-- > 0) Entities.Add(new Entity(binread));

            // Create Zones:
            Zone newzone;
            i = header.ZoneNum;
            while(i-- > 0)
            {
                newzone = new Zone(binread);
                newzone.LayerName = "Zone: " + i;
                newzone.Deleted += new Zone.EventHandler(myzone_Deleted);
                newzone.Enabled = false;
                Controls.Add(newzone);
            }

            // Load Tileset:
            if (header.Scripts[0].Length == 0) Tileset = new TilesetControl(binread);
            else Tileset = new TilesetControl(header.Scripts[0], filename);
            Tileset.ParentMap = this;
            SetTileSize(Tileset.TileWidth, Tileset.TileHeight);
            _w = Layers[0].Width * twz;
            _h = Layers[0].Height * thz;

            bool remove = false;
            foreach (Layer l in Layers)
                for (i = 0; i < l.Tiles.Length; ++i)
                    if (l.Tiles[i] >= Tileset.Tiles.Count)
                    {
                        l.Tiles[i] = 0;
                        remove = true;
                    }
            
            if (remove) MessageBox.Show("Caution:\nInvalid tile references were removed. Please check for changes.");

            LayerHistory.Add(CloneAllLayers());
            binread.Close();
        }

        public bool SaveMap(string filename)
        {
            // Separate the Tiles //
            if (header.Scripts[0] == string.Empty)
            {
                SaveFileDialog diag = new SaveFileDialog();
                diag.InitialDirectory = Global.CurrentProject.Path + "\\maps";
                diag.Filter = "Tileset Files (.rts)|*.rts";
                MessageBox.Show("This tileset has not been saved... You must specify a save location.", "Unsaved Tileset");
                if (diag.ShowDialog() == DialogResult.OK) header.Scripts[0] = Path.GetFileName(diag.FileName);
                else
                {
                    MessageBox.Show("Can't save map without external tileset.");
                    return false;
                }
            }

            BinaryWriter binwrite = new BinaryWriter(File.OpenWrite(filename));
            file_name = filename;

            // Write Header Data //
            binwrite.Write(".rmp".ToCharArray());
            binwrite.Write(header.VersionNum);
            binwrite.Write(byte.MinValue);
            binwrite.Write((byte)Layers.Count);
            binwrite.Write(byte.MinValue);
            binwrite.Write((short)Entities.Count);
            binwrite.Write(header.StartX);
            binwrite.Write(header.StartY);
            binwrite.Write((byte)header.StartLayer);
            binwrite.Write((byte)header.StartDirection);
            binwrite.Write((short)header.Scripts.Count);
            binwrite.Write((short)(Controls.Count-1));
            binwrite.Write(new byte[235]);

            // Write Script Data //
            foreach (string s in header.Scripts)
            {
                binwrite.Write((short)s.Length);
                binwrite.Write(s.ToCharArray());
            }

            // Save Layers //
            foreach (Layer l in Layers) l.Save(binwrite);

            // Save Entities //
            foreach (Entity e in Entities) e.Save(binwrite);

            // Save Zones //
            foreach (Control c in Controls)
            {
                if (c is Zone) ((Zone)c).Save(binwrite);
            }

            binwrite.Flush();
            binwrite.Close();

            // Save Tileset - Not w/ Map any Longer //
            string path = filename.Substring(0, filename.LastIndexOf("\\")+1);
            Tileset.Save(path + header.Scripts[0]);
            return true;
        }
        #endregion

        #region layer methods
        public void SetLayerTile(int x, int y)
        {
            Layers[_layer].SetTile(x, y, Tileset.Selection);
        }

        /// <summary>
        /// Adds a blank layer to the map
        /// </summary>
        /// <param name="name"> The name of the layer </param>
        public Layer AddLayer(string name)
        {
            StringInputForm form = new StringInputForm();
            form.Input = name;
            if (form.ShowDialog() == DialogResult.OK) name = form.Input;
            Layer lay = new Layer(name, (short)BaseWidth, (short)BaseHeight, tile_width, tile_height);
            lay.Zoom = _zoom;
            lay.UpdateDrawingWindow(Width, Height);
            Layers.Add(lay);
            if (Layers.Count > 1) UpdateAllLayers();
            ResetHistory();
            return lay;
        }

        /// <summary>
        /// Adds a Layer from a stream object. In this case a Binary Reader.
        /// </summary>
        /// <param name="stream"> The stream in which to extrapolate the layer data from </param>
        public void AddLayer(BinaryReader stream)
        {
            Layers.Add(new Layer(stream));
            if (Layers.Count > 1) UpdateAllLayers();
            ResetHistory();
        }

        /// <summary>
        /// Removes a layer from the map.
        /// </summary>
        /// <param name="index">Index number of layer to remove.</param>
        public void RemoveLayer(short index)
        {
            // remove layer.
            Layers.RemoveAt(index);

            // remove of all of the entities on that layer
            for (int i = 0; i < Entities.Count; ++i)
                if (Entities[i].Layer == index) { Entities.RemoveAt(i); i--; }
            
            ResetHistory();
        }

        /// <summary>
        /// Sets the size of the drawing portion of the map:
        /// </summary>
        /// <param name="width">width in tiles</param>
        /// <param name="height">height in tiles</param>
        public void SetSize(int width, int height)
        {
            base_width = width;
            base_height = height;
            UpdateControl();
        }

        public void SetTileSize(short width, short height)
        {
            tile_width = width;
            tile_height = height;
            Tileset.SetTileSize(width, height);

            // set zoomed tile size:
            twz = width * _zoom;
            thz = height * _zoom;

            Width = base_width * width;
            Height = base_height * height;

            // set zoomed start x/y:
            start_x = header.StartX / tile_width * twz;
            start_y = header.StartY / tile_height * thz;

            // set each layers tile size //
            foreach (Layer l in Layers) { l.SetTileSize(width, height); l.Zoom = _zoom; }
            if (Parent != null) UpdateControl();
        }

        public void SetTileSize(short width, short height, bool rescale)
        {
            SetTileSize(width, height);

            if (!rescale) Tileset.ResizeAllTiles(width, height);
            else Tileset.RescaleAllTiles(width, height);

            UpdateAllLayers();
            UpdateControl();
        }

        /// <summary>
        /// Returns a shallow clone of the layers.
        /// </summary>
        /// <returns>The "new" set of layers.</returns>
        private List<Layer> CloneAllLayers()
        {
            List<Layer> list = new List<Layer>();
            foreach (Layer lay in Layers) list.Add(lay.Clone());
            return list;
        }

        /// <summary>
        /// Cheap reset of the undo chain. Sorry, I'm lazy to not make something
        /// More beneficial. Something that restores destroyed layers.
        /// </summary>
        private void ResetHistory()
        {
            LayerHistory.Clear();
            cur_pos = 0;
            LayerHistory.Add(CloneAllLayers());
        }

        /// <summary>
        /// Draws the previously stored layer set and sets the current undo position.
        /// </summary>
        public void UndoAction()
        {
            if (cur_pos > 0) cur_pos--;
            List<Layer> LastLayers = LayerHistory[cur_pos];

            for (int i = 0; i < Layers.Count; ++i)
                for (int t = 0; t < Layers[i].Tiles.Length; ++t)
                    Layers[i].Tiles[t] = LastLayers[i].Tiles[t];
            
            UpdateAllLayers();
        }

        /// <summary>
        /// Restores the next stored layer and ests the current undo position.
        /// </summary>
        public void RedoAction()
        {
            if (cur_pos < LayerHistory.Count - 1) cur_pos++;
            List<Layer> NextLayers = LayerHistory[cur_pos];
            
            for (int i = 0; i < Layers.Count; ++i)
                for (int t = 0; t < Layers[i].Tiles.Length; ++t)
                    Layers[i].Tiles[t] = NextLayers[i].Tiles[t];
            
            UpdateAllLayers();
        }

        /// <summary>
        /// "Redraws" the current layer image, but does not draw it to screen.
        /// </summary>
        private void UpdateCurrentLayer()
        {
            Layers[_layer].UpdateLayer(Tileset, false);
        }

        /// <summary>
        /// Forces all layers to "redraw" and draws them to screen.
        /// </summary>
        public void UpdateAllLayers()
        {
            foreach (Layer lay in Layers) lay.UpdateLayer(Tileset, true);
            Refresh();
        }

        /// <summary>
        /// Handles adjustment of tile insertion and deletion.
        /// </summary>
        /// <param name="startIndex">The index to begin modifying.</param>
        /// <param name="count">The amount to modify by, either + or -.</param>
        public void DoAllLayerAdjustment(int startIndex, short count)
        {
            foreach (Layer lay in Layers) lay.DoAdjustment(startIndex, count);
            UpdateAllLayers();
        }

        // This will make all the layers the same width and height.
        public void ResizeAllLayers(short width, short height)
        {
            foreach (Layer lay in Layers) { lay.ResizeLayer(width, height); lay.Zoom = _zoom; }
            UpdateAllLayers();
            SetSize(width, height);
        }
        #endregion

        public void SetStampMap(short[] indicies, int map_w, int map_h)
        {
            stamp_map = indicies;
            stamp_width = map_w;
            stamp_height = map_h;
        }

        private void MapEditorControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            // Draw Layers //
            foreach (Layer l in Layers) l.DrawLayer(e.Graphics);
            
            // Draw Start Position //
            e.Graphics.DrawImage(Sphere_Editor.Properties.Resources.startpos, start_x - x_off * twz, start_y - y_off * thz, twz, thz);

            // Draw Entities And Zones //
            DrawEntities(e.Graphics);

            if (tool_num < 4 || tool_num == 6)
            {
                int x = (cur_x - x_off) * twz;
                int y = (cur_y - y_off) * thz;
                DrawTileSelector(e.Graphics, TileRectPen, x, y);
            }
            
            // Draw the tool graphic //
            if (_paint || tool_num == 6) DrawTool(e.Graphics);
        }

        private void DrawTileSelector(Graphics g, Pen pen, int mid_x, int mid_y)
        {
            if (stamp_map.Length == 0) g.DrawRectangle(pen, mid_x, mid_y, twz, thz);
            else
            {
                int index = 0;
                int swtxz = mid_x - (stamp_width >> 1) * twz;
                int shtyz = mid_y - (stamp_height >> 1) * thz;

                int w = stamp_width * twz;
                int h = stamp_height * thz;

                for (int y = 0; y < h; y += thz)
                {
                    for (int x = 0; x < w; x += twz)
                    {
                        if (stamp_map[index] != -1)
                            g.DrawRectangle(pen, swtxz + x, shtyz + y, twz, thz);
                        ++index;
                    }
                }
            }

        }

        #region mouse methods
        private void MapEditorControl_MouseMove(object sender, MouseEventArgs e)
        {
            // Limit the drawing to only the client size
            if (e.X > 0 && e.X < Width && e.Y > 0 && e.Y < Height)
            {
                last_x = cur_x; last_y = cur_y;
                cur_x = e.X / twz + x_off; cur_y = e.Y / thz + y_off;
                if (tool_num == 7)
                {
                    if (!_paint && !_new_ent) selected_ent = GetEntityAt(cur_x, cur_y);
                    if (selected_ent != null)
                    {
                        Cursor = Cursors.SizeAll;
                        if (_paint || _new_ent)
                        {
                            if (!_new_ent && _ctrl && !_copied_ent)
                            {
                                selected_ent = selected_ent.Copy();
                                Entities.Add(selected_ent);
                                _copied_ent = true;
                            }
                            selected_ent.X = (short)((cur_x) * tile_width + (tile_width / 2));
                            selected_ent.Y = (short)((cur_y) * tile_height + (tile_height / 2));
                        }
                    }
                    else Cursor = Cursors.Default;
                    InvalidateSelectorArea();
                }
                else if (last_x != cur_x || last_y != cur_y)
                {
                    if (TileStatusLabel != null)
                        TileStatusLabel.Text = "Tile: (" + cur_x + ", " + cur_y + ")";
                    if (_paint && tool_num == 0)
                    {
                        if (stamp_map.Length == 0)
                            DrawTileLine(last_x, last_y, cur_x, cur_y);
                        else StampMap();
                        UpdateCurrentLayer();
                        InvalidateSelectorArea();
                    }
                    else InvalidateSelectorArea();
                }
            }
        }

        // this will set the drawing for tools and initialize a start
        // position for the tool to be drawn.
        private void MapEditorControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool_num == 7 && e.Button == MouseButtons.Left) _paint = true;
            else if (e.Button == MouseButtons.Left && Layers[_layer].Visible && !_ctrl)
            {
                if (tool_num < 4 || tool_num == 6)
                {
                    // remove anything ahead in the redo queue
                    while (LayerHistory.Count - 1 > cur_pos)
                        LayerHistory.RemoveAt(LayerHistory.Count - 1);

                    // Add an array of current layer settings
                    LayerHistory.Add(CloneAllLayers()); cur_pos++;
                }
                tool_x = e.X / twz + x_off;
                tool_y = e.Y / thz + y_off;
                if (tool_num == 0)
                {
                    if (stamp_map.Length == 0) SetLayerTile(cur_x, cur_y);
                    else StampMap();
                    UpdateCurrentLayer();
                }
                _paint = true;
                InvalidateSelectorArea();
            }
        }

        // this will unset the drawing for tools.
        // and if a tool was drawn, it'll do it.
        private void MapEditorControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _paint = _copied_ent = false;
                if (_new_ent) { _new_ent = false; tool_num = 0; Cursor = Cursors.Default; }
                if (tool_num == 7) selected_ent = null;
                else if (_ctrl) SelectTileItem_Click(null, null);
                else
                {
                    DoTool();
                    if (tool_num < 4 || tool_num == 6) LayerHistory[LayerHistory.Count - 1] = CloneAllLayers();
                    Refresh();
                }
            }
        }
        #endregion

        #region tool methods
        // Invalidates a 3x3 area, size of the selector. This dramatically
        // increases drawing preformance, since I reduce the blit size and
        // a 3x3 area covers all possible direction motions. I used integer math as much as possible.
        private void InvalidateSelectorArea()
        {
            //Invalidate();
            if (tool_num > 0) // don't invalidate the other tools selector area.
            {
                Invalidate();
                return;
            }
            if (stamp_map.Length == 0) // single selection block
            {
                Rectangle r = new Rectangle(0, 0, twz + 1, thz + 1);
                r.X = (last_x - x_off) * twz - 1;
                r.Y = (last_y - y_off) * thz - 1;
                Invalidate(r);
                r.X = (cur_x - x_off) * twz - 1;
                r.Y = (cur_y - y_off) * thz - 1;
                Invalidate(r);
            }
            else // stamp block
            {
                int x = (last_x - x_off) * twz - stamp_width * twz - 1;
                int y = (last_y - y_off) * thz - stamp_height * thz - 1;
                int w = stamp_width * twz;
                int h = stamp_height * thz;
                Rectangle r = new Rectangle(x, y, (w << 1) + w + 1, (h << 1) + h + 1);
                Invalidate(r);
            }//*/
        }

        // Stamps the stamp map at (x, y):
        private void StampMap()
        {
            int swtxz = cur_x - (stamp_width >> 1);
            int shtyz = cur_y - (stamp_height >> 1);
            int width = base_width * tile_width;
            int index = 0, tile = 0, xx = 0;

            for (int y = 0; y < stamp_height; ++y)
            {
                for (int x = 0; x < stamp_width; ++x)
                {
                    if (stamp_map[index] != -1)
                    {
                        xx = (swtxz + x);
                        tile = xx + (shtyz + y) * base_width;
                        
                        // Check for validity:
                        if (tile < 0 || xx < 0) continue;
                        else if (xx >= width) continue;
                        else if (tile >= Layers[_layer].Tiles.Length) continue;

                        Layers[_layer].Tiles[tile] = stamp_map[index];
                        Layers[_layer].Dirty[tile] = true;
                    }
                    ++index;
                }
            }
        }

        // Found in the paint event. Draws a representation of the tool's
        // selection area. Not all tools are drawn, however.
        private void DrawTool(Graphics g)
        {
            // define some coordinate integers
            int tx = (tool_x - x_off) * twz;
            int ty = (tool_y - y_off) * thz;
            int cx = (cur_x - x_off) * twz;
            int cy = (cur_y - y_off) * thz;
            Color dark = Color.FromArgb(127, Color.Black);
            Color col = Color.FromArgb(127, Color.Blue);
            Rectangle rec = new Rectangle(tx, ty, cx - tx + twz, cy - ty + thz);
            switch (tool_num)
            {
                case 1:
                    g.DrawRectangle(TileRectPen, tx, ty, twz, thz);
                    g.DrawLine(ToolPen, new Point(tx+twz/2, ty+thz/2), new Point(cx+twz/2, cy+thz/2));
                break;
                case 2:
                    rec.Width -= 2; rec.Height -= 2;
                    g.DrawRectangle(TileRectPen, tx, ty, twz, thz);
                    g.FillRectangle(new SolidBrush(col), rec);
                    g.DrawRectangle(ToolPen, rec);
                break;
                case 4:
                    g.FillRectangle(zone_brush, rec);
                    g.DrawRectangle(zone_pen, rec);
                break;
                case 6:
                    g.DrawRectangle(new Pen(dark), cx - (twz >> 1), cy - (thz >> 1), (twz << 1) + 1, (thz << 1) + 1);
                break;
            }
        }

        // based off of the tile information, it'll perform the
        // current tools action.
        private void DoTool()
        {
            switch (tool_num)
            {
                case 1: // pen (as a line)
                    DrawTileLine(tool_x, tool_y, cur_x, cur_y);
                    break;
                case 2: // rectangle
                    int boxWidth = cur_x - tool_x + 1;
                    int boxHeight = cur_y - tool_y + 1;
                    for (int y = 0; y < boxHeight; ++y)
                    {
                        for (int x = 0; x < boxWidth; ++x)
                        {
                            SetLayerTile(tool_x + x, tool_y + y);
                        }
                    }
                    break;
                case 3: // flood fill
                    FloodTiles(cur_x, cur_y);
                    break;
                case 4: // zone drawer
                    int cx = cur_x * tile_width + tile_width;
                    int cy = cur_y * tile_height + tile_height;
                    int tx = tool_x * tile_width;
                    int ty = tool_y * tile_height;

                    Zone myzone = new Zone(tx, ty, cx - tx, cy - ty, _layer);
                    myzone.LayerName = "Zone: " + Controls.Count;
                    myzone.Snap = tile_width;
                    myzone.Zoom = _zoom;
                    myzone.Deleted += new Zone.EventHandler(myzone_Deleted);
                    Controls.Add(myzone);
                    Controls[Controls.Count - 1].BringToFront();
                    break;
                case 6: // auto-tile
                    if (Autoset == null || !Autoset.CanCenter) return;
                    if (Layers[_layer].GetTileAt(cur_x, cur_y) == Autoset.CenterTile) return;
                    DoAutoStamp(cur_x - 1, cur_y - 1);
                    break;
            }
            UpdateCurrentLayer();
        }

        private void DoAutoStamp(int cx, int cy)
        {
            short[,] field = new short[5, 5];
            for (short y = 0; y < 5; ++y)
                for (short x = 0; x < 5; ++x)
                {
                    if ((cx - 1) + x < 0 || (cy - 1) + y < 0) field[x, y] = -1;
                    else if ((cx - 1) + x > base_width - 1 || (cy - 1) + y > base_height - 1) field[x, y] = -1;
                    else field[x, y] = Layers[_layer].GetTileAt((cx - 1) + x, (cy - 1) + y);
                }
            short[,] stamp = Autoset.CreateBigStamp(field);
            for (short y = 0; y < 3; ++y)
                for (short x = 0; x < 3; ++x)
                {
                    if (stamp[x, y] == -1 || cx + x < 0 || cy + y < 0) continue;
                    if (cx + x > base_width - 1 || cy + y > base_height - 1) continue;
                    Layers[_layer].SetTile(cx + x, cy + y, stamp[x, y]);
                }
            if (field[1, 1] == Autoset.CenterTiles[8]) DoAutoStamp(cx - 1, cy - 1);
            if (field[3, 1] == Autoset.CenterTiles[6]) DoAutoStamp(cx + 1, cy - 1);
            if (field[1, 3] == Autoset.CenterTiles[2]) DoAutoStamp(cx - 1, cy + 1);
            if (field[3, 3] == Autoset.CenterTiles[0]) DoAutoStamp(cx + 1, cy + 1);
        }

        #region line tool
        // This is using Bresenhams algorithm. (Because why the hell not?)
        private void DrawTileLine(int x0, int y0, int x1, int y1)
        {
            short tile = Tileset.Selection;
            short width = Layers[_layer].Width;
            int dx = x1 - x0, dy = y1 - y0;
            int stepx, stepy;

            if (dy < 0) { dy = -dy; stepy = -width; } else { stepy = width; }
            if (dx < 0) { dx = -dx; stepx = -1; } else { stepx = 1; }
            
            dx <<= 1; dy <<= 1;
            y0 *= width; y1 *= width;

            Layers[_layer].SetTile(x0 + y0, tile);
            if (dx > dy)
            {
                int fraction = dy - (dx >> 1);
                while (x0 != x1)
                {
                    if (fraction >= 0)
                    {
                        y0 += stepy;
                        fraction -= dx;
                    }
                    x0 += stepx;
                    fraction += dy;
                    if (x0 < Layers[_layer].Width) Layers[_layer].SetTile(x0 + y0, tile);
                }
            }
            else
            {
                int fraction = dx - (dy >> 1);
                while (y0 != y1)
                {
                    if (fraction >= 0)
                    {
                        x0 += stepx;
                        fraction -= dy;
                    }
                    y0 += stepy;
                    fraction += dx;
                    if (x0 < Layers[_layer].Width) Layers[_layer].SetTile(x0 + y0, tile);
                }
            }
        }
        #endregion

        #region fl00d tool
        /// <summary>
        /// Implemented using a virtual stack, rather than by recursion.
        /// </summary>
        /// <param name="x">X position of where to start.</param>
        /// <param name="y">Y position of where to start.</param>
        private void FloodTiles(int x, int y)
        {
            int old_index = Layers[_layer].GetTileAt(x, y);
            if (old_index == Tileset.Selection) return;

            Stack<Point> points = new Stack<Point>();
            points.Push(new Point(x, y));
            Layers[_layer].SetTile(x, y, Tileset.Selection);

            while (points.Count > 0)
            {
                Point pt = points.Pop();
                if (pt.X > 0) CheckFloodPoint(points, pt.X - 1, pt.Y, old_index);
                if (pt.Y > 0) CheckFloodPoint(points, pt.X, pt.Y - 1, old_index);
                if (pt.X < Layers[_layer].Width - 1) CheckFloodPoint(points, pt.X + 1, pt.Y, old_index);
                if (pt.Y < Layers[_layer].Height - 1) CheckFloodPoint(points, pt.X, pt.Y + 1, old_index);
            }
        }

        private void CheckFloodPoint(Stack<Point> points, int x, int y, int old_index)
        {
            if (Layers[_layer].GetTileAt(x, y) == old_index)
            {
                points.Push(new Point(x, y));
                Layers[_layer].SetTile(x, y, Tileset.Selection);
            }
        }
        #endregion
        #endregion

        void myzone_Deleted(object sender, EventArgs e)
        {
            Controls.RemoveAt(0);
            for (int i = 0; i < Controls.Count; ++i)
                if (Controls[i].GetType().Name == "Zone")
                    ((Zone)Controls[i]).LayerName = "Zone: " + (Controls.Count - 1 - i);
        }

        private void DrawEntities(Graphics g)
        {
            for (int i = 0; i < Entities.Count; ++i)
                Entities[i].DrawSprite(g, tile_width, tile_height, x_off * twz, y_off * thz, _zoom);
        }

        /// <summary>
        /// Set's the zoom of the map.
        /// </summary>
        /// <param name="num">The level of zoom.</param>
        public void SetZoomLevel(int num)
        {
            _zoom = num;
            foreach (Layer lay in Layers) lay.Zoom = num;
            for (int i = 0; i < Controls.Count; ++i)
                if (Controls[i].GetType().Name == "Zone")
                    ((Zone)Controls[i]).Zoom = num;

            // set zoomed tile size:
            twz = tile_width * num;
            thz = tile_height * num;
            _w = Layers[0].Width * tile_width * num;
            _h = Layers[0].Height * tile_height * num;

            // set zomed start x/y:
            start_x = (header.StartX / tile_width) * twz;
            start_y = (header.StartY / tile_height) * thz;

            // update control
            UpdateControl();
            x_off = HorizontalScroll.Value / _zoom;
            y_off = VerticalScroll.Value / _zoom;
            foreach (Layer l in Layers) l.UpdateTileOffset(x_off, y_off);
            UpdateAllLayers();
        }

        private Entity GetEntityAt(int x, int y)
        {
            foreach (Entity ent in Entities)
            {
                int ex = ent.X / tile_width;
                int ey = ent.Y / tile_height;
                if (ex == x && ey == y) return ent;
            }
            return null;
        }

        #region context menu items
        private void MapContextStrip_Opened(object sender, EventArgs e)
        {
            EditEntityItem.Enabled = CopyEntityItem.Enabled = GetEntityAt(cur_x, cur_y) != null;
            DeleteEntityItem.Enabled = EditEntityItem.Enabled;
            PasteEntityItem.Enabled = Global.CopiedEnt != null;
            SelectLayerItem.DropDownItems.Clear();
            ToolStripMenuItem item;
            foreach (Layer l in Layers)
            {
                int num = Layers.IndexOf(l);
                item = new ToolStripMenuItem(l.Name);
                item.Name = num + l.Name;
                item.Click += new EventHandler(LayerSubItemClick);
                if (_layer == num) item.BackColor = Color.LightBlue;
                SelectLayerItem.DropDownItems.Insert(0, (ToolStripItem)item);
            }
        }
        
        private void SelectTileItem_Click(object sender, EventArgs e)
        {
            Tileset.Selection = Layers[_layer].GetTileAt(cur_x, cur_y);
            Tileset.Refresh();
        }

        private void StartLocationItem_Click(object sender, EventArgs e)
        {
            header.StartX = (short)(cur_x * _zoom * (tile_width / _zoom) + (tile_width / 2));
            header.StartY = (short)(cur_y * _zoom * (tile_height / _zoom) + (tile_height / 2));
            start_x = header.StartX / tile_width * twz;
            start_y = header.StartY / tile_height * thz;
            header.StartLayer = (short)_layer;
            if (StartChanged != null) StartChanged(this, new EventArgs());
            Refresh();
        }

        private void PersonItem_Click(object sender, EventArgs e)
        {
            PersonForm personform = new PersonForm(Entities);
            foreach (Layer l in Layers) personform.AddString(l.Name);
            personform.SelectedIndex = _layer;
            personform.Person.X = (short)((cur_x) * tile_width + (tile_width / 2));
            personform.Person.Y = (short)((cur_y) * tile_height + (tile_height / 2));
            if (personform.ShowDialog() == DialogResult.OK)
            {
                Entities.Add(personform.Person);
                if (MapEdited != null) MapEdited(this, new EventArgs());
                Refresh();
            }
        }

        void LayerSubItemClick(object sender, EventArgs e)
        {
            int i = SelectLayerItem.DropDown.Items.Count;
            string name = ((ToolStripItem)sender).Name;
            while (i-- > 0)
            {
                if (SelectLayerItem.DropDown.Items[i].Name == name) break;
            }
            LayerNum = SelectLayerItem.DropDown.Items.Count-1-i;
            if (LayerChanged != null) LayerChanged(this, new EventArgs());
        }

        // handle the case for both entities and players:
        private void EditEntityItem_Click(object sender, EventArgs e)
        {
            Entity ent = GetEntityAt(cur_x, cur_y);
            if (ent.Type == 1)
            {
                PersonForm form = new PersonForm(ent, Entities);
                foreach (Layer l in Layers) form.AddString(l.Name);
                form.SelectedIndex = (int)ent.Layer;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Entities[Entities.IndexOf(ent)] = form.Person;
                    UpdateAllLayers();
                    if (MapEdited != null) MapEdited(this, new EventArgs());
                }
            }
            else if (ent.Type == 2)
            {
                TriggerForm form = new TriggerForm(ent);
                foreach (Layer l in Layers) form.AddString(l.Name);
                form.SelectedIndex = ent.Layer;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Entities[Entities.IndexOf(ent)] = form.Trigger;
                    UpdateAllLayers();
                    if (MapEdited != null) MapEdited(this, new EventArgs());
                }
            }
        }

        private void DeleteEntityItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this entity?", "Deletion",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                Entity ent = GetEntityAt(cur_x, cur_y);
                Entities.RemoveAt(Entities.IndexOf(ent));
                if (MapEdited != null) MapEdited(this, new EventArgs());
                Refresh();
            }
        }

        private void TriggerItem_Click(object sender, EventArgs e)
        {
            TriggerForm form = new TriggerForm();
            foreach (Layer l in Layers) form.AddString(l.Name);
            form.SelectedIndex = _layer;
            form.Trigger.X = (short)(cur_x * tile_width + (tile_width >> 1));
            form.Trigger.Y = (short)(cur_y * tile_height + (tile_height >> 1));
            if (form.ShowDialog() == DialogResult.OK)
            {
                Entities.Add(form.Trigger);
                if (MapEdited != null) MapEdited(this, new EventArgs());
                Refresh();
            }
        }
        #endregion

        private void MapEditorControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _ctrl = true;
                if (tool_num != 7) Cursor = Cursors.Hand;
            }
        }

        private void MapEditorControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _ctrl = false;
                if (tool_num != 7) Cursor = Cursors.Default;
            }
        }

        private void MapEditorControl_Leave(object sender, EventArgs e)
        {
            _ctrl = false;
            Cursor = Cursors.Default;
        }

        private void MapEditorControl_MouseLeave(object sender, EventArgs e)
        {
            Refresh();
        }

        private void MapEditorControl_Enter(object sender, EventArgs e)
        {
            _ctrl = false;
            Cursor = Cursors.Default;
        }

        private void CopyEntityItem_Click(object sender, EventArgs e)
        {
            Global.CopiedEnt = GetEntityAt(cur_x, cur_y).Copy();
        }

        private void PasteEntityItem_Click(object sender, EventArgs e)
        {
            selected_ent = Global.CopiedEnt.Copy();
            Entities.Add(selected_ent);
            tool_num = 7;
            _new_ent = true;
        }
    }
}
