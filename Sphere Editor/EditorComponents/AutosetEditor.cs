using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sphere_Editor.EditorComponents
{
    public partial class AutosetEditor : UserControl
    {
        private List<short> middle_tiles = new List<short>();
        private List<short> inner = new List<short>();
        private short center_tile = -1;
        private bool center_okay, corner_okay;
        private TilesetControl tileset = null;
        private List<short> sides = new List<short>();
        private List<short> corners = new List<short>();
        private List<short> border = new List<short>();
        private List<short> all = new List<short>();
        private bool[,] ignore;
        private short[,] stamp = new short[3, 3];

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler OnUse;

        public AutosetEditor()
        {
            InitializeComponent();
        }

        public AutosetEditor(TilesetControl reference_set)
        {
            this.tileset = reference_set;
        }

        #region getters and setters
        public TilesetControl Tileset
        {
            get { return tileset; }
            set { tileset = value; }
        }

        public short CenterTile
        {
            get { return center_tile; }
            set { center_tile = value; }
        }

        public List<short> CenterTiles
        {
            get { return middle_tiles; }
            set { middle_tiles = value; }
        }

        public List<short> CornerTiles
        {
            get { return inner; }
            set { inner = value; }
        }

        public bool CanCorner
        {
            get { return corner_okay; }
        }

        public bool CanCenter
        {
            get { return center_okay; }
        }
        #endregion

        private void CenterPieces_Paint(object sender, PaintEventArgs e)
        {
            int index = 0;
            if (middle_tiles.Count == 0) return;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            for (int y = 0; y < 3; ++y)
            {
                for (int x = 0; x < 3; ++x)
                {
                    if (index < middle_tiles.Count)
                        e.Graphics.DrawImage(tileset.Tiles[middle_tiles[index]].Graphic, x * 32, y * 32, 32, 32);
                    index++;
                }
            }
            if (center_okay) e.Graphics.DrawImageUnscaled(Sphere_Editor.Properties.Resources.check, 76, 76);
        }

        private void CornerButton_Click(object sender, EventArgs e)
        {
            if (inner.Count == 4) return;
            List<short> indicies = new List<short>(tileset.GetSelectedIndices());
            if (indicies.Count != 0)
            {
                while (indicies.Contains(-1)) indicies.Remove(-1);
                inner.AddRange(indicies);
                while (inner.Count > 4) inner.RemoveAt(inner.Count - 1);
            }
            else inner.Add(tileset.Selection);
            corner_okay = inner.Count == 4;
            UseButton.Enabled = (center_okay && corner_okay);
            CornerPieces.Refresh();
        }

        private void CornerPieces_Paint(object sender, PaintEventArgs e)
        {
            int index = 0;
            if (inner.Count == 0) return;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            for (int y = 0; y < 2; ++y)
            {
                for (int x = 0; x < 2; ++x)
                {
                    if (index < inner.Count)
                        e.Graphics.DrawImage(tileset.Tiles[inner[index]].Graphic, x * 32, y * 32, 32, 32);
                    index++;
                }
            }
            if (corner_okay) e.Graphics.DrawImageUnscaled(Sphere_Editor.Properties.Resources.check, 44, 44);
        }

        private void UseButton_Click(object sender, EventArgs e)
        {
            all.Clear();
            all.AddRange(middle_tiles);
            all.AddRange(inner);
            if (OnUse != null) OnUse(this, new EventArgs());
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            middle_tiles.Clear();
            inner.Clear();
            CenterPieces.Refresh();
            CornerPieces.Refresh();
            corner_okay = center_okay = UseButton.Enabled = false;
        }

        private void CenterButton_Click(object sender, EventArgs e)
        {
            if (middle_tiles.Count == 9) return;
            List<short> indicies = new List<short>(tileset.GetSelectedIndices());
            if (indicies.Count != 0)
            {
                while (indicies.Contains(-1)) indicies.Remove(-1);
                middle_tiles.AddRange(indicies);
                while (middle_tiles.Count > 9) middle_tiles.RemoveAt(middle_tiles.Count - 1);
            }
            else middle_tiles.Add(tileset.Selection);
            if (middle_tiles.Count == 9)
            {
                center_tile = middle_tiles[4];
                sides.Clear(); corners.Clear(); border.Clear();
                sides.AddRange(new short[4] { middle_tiles[1], middle_tiles[3], middle_tiles[5], middle_tiles[7] });
                corners.AddRange(new short[4] { middle_tiles[0], middle_tiles[2], middle_tiles[6], middle_tiles[8] });
                border.AddRange(middle_tiles);
                border.RemoveAt(4);
            }
            center_okay = (middle_tiles.Count == 9);
            UseButton.Enabled = (center_okay && corner_okay);
            CenterPieces.Refresh();
        }

        private void CenterPieces_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            middle_tiles.Clear();
            CenterPieces.Refresh();
            UseButton.Enabled = center_okay = false;
        }

        private void CornerPieces_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            inner.Clear();
            CornerPieces.Refresh();
            UseButton.Enabled = corner_okay = false;
        }

        public short[,] CreateBigStamp(short[,] field)
        {
            ignore = CreateIgnoreStamp(field);
            short i = 0;
            field[2, 2] = stamp[1, 1] = center_tile;
            for (short y = 1; y < 4; ++y)
                for (short x = 1; x < 4; ++x)
                {
                    if (!all.Contains(field[x, y])) field[x, y] = middle_tiles[i];
                    i++;
                }

            field[2, 1] = DoSideCenter(field, 2, 1, 0);
            field[1, 2] = DoSideCenter(field, 1, 2, 1);
            field[3, 2] = DoSideCenter(field, 3, 2, 2);
            field[2, 3] = DoSideCenter(field, 2, 3, 3);
            stamp[0, 0] = field[1, 1] = DoCorner(field, 1, 1, 0);
            stamp[2, 0] = field[3, 1] = DoCorner(field, 3, 1, 1);
            stamp[0, 2] = field[1, 3] = DoCorner(field, 1, 3, 2);
            stamp[2, 2] = field[3, 3] = DoCorner(field, 3, 3, 3);
            stamp[1, 0] = DoSide(field, 2, 1, 0);
            stamp[0, 1] = DoSide(field, 1, 2, 1);
            stamp[2, 1] = DoSide(field, 3, 2, 2);
            stamp[1, 2] = DoSide(field, 2, 3, 3);

            for (short y = 0; y < 3; ++y)
                for (short x = 0; x < 3; ++x)
                    if (ignore[x, y]) stamp[x, y] = -1;

            return stamp;
        }

        public bool[,] CreateIgnoreStamp(short[,] field)
        {
            bool[,] ignore = new bool[3, 3];
            short at = field[2, 2];
            if (field[2, 1] == center_tile) ignore[0, 0] = ignore[1, 0] = ignore[2, 0] = true;
            if (field[1, 2] == center_tile) ignore[0, 0] = ignore[0, 1] = ignore[0, 2] = true;
            if (field[2, 3] == center_tile) ignore[0, 2] = ignore[1, 2] = ignore[2, 2] = true;
            if (field[3, 2] == center_tile) ignore[2, 0] = ignore[2, 1] = ignore[2, 2] = true;
            if (at == inner[0] && field[2, 3] == inner[3]) ignore[1, 2] = true;
            if (at == inner[1] && field[2, 3] == inner[2]) ignore[1, 2] = true;
            if (at == inner[3] && field[1, 2] == inner[0]) ignore[0, 1] = true;
            if (at == inner[1] && field[1, 2] == inner[2]) ignore[0, 1] = true;
            if (at == inner[0] && field[3, 2] == inner[3]) ignore[2, 1] = true;
            if (at == inner[2] && field[3, 2] == inner[1]) ignore[2, 1] = true;
            if (at == inner[2] && field[2, 1] == inner[1]) ignore[1, 0] = true;
            if (at == inner[3] && field[2, 1] == inner[0]) ignore[1, 0] = true;
            return ignore;
        }

        public short DoCorner(short[,] field, short x_pos, short y_pos, short type)
        {
            short at = field[x_pos, y_pos];           
            if (at == center_tile || inner.Contains(at)) return center_tile;

            short l = field[x_pos - 1, y_pos], r = field[x_pos + 1, y_pos];
            short t = field[x_pos, y_pos - 1], b = field[x_pos, y_pos + 1];

            if (at == sides[0]) return (x_pos == 1) ? inner[0] : inner[1];
            if (at == sides[1]) return (y_pos == 1) ? inner[0] : inner[2];
            if (at == sides[2]) return (y_pos == 1) ? inner[1] : inner[3];
            if (at == sides[3]) return (x_pos == 1) ? inner[2] : inner[3];

            if ((type == 0 || type == 1) && b == center_tile) return sides[0];
            if ((type == 0 || type == 2) && r == center_tile) return sides[1];
            if ((type == 1 || type == 3) && l == center_tile) return sides[2];
            if ((type == 2 || type == 3) && t == center_tile) return sides[3];
            return at;
        }

        public short DoSideCenter(short[,] field, short x_pos, short y_pos, short type)
        {
            short at = field[x_pos, y_pos];
            if (at == sides[3 - type]) return center_tile;

            short l = field[x_pos - 1, y_pos], r = field[x_pos + 1, y_pos];
            short t = field[x_pos, y_pos - 1], b = field[x_pos, y_pos + 1];

            if (inner.Contains(at))
            {
                if ((type == 2 && l == center_tile) || (type == 1 && r == center_tile)) return center_tile;
                if ((type == 3 && t == center_tile) || (type == 0 && b == center_tile)) return center_tile;
            }
            return at;
        }

        public short DoSide(short[,] field, short x_pos, short y_pos, short type)
        {
            short at = field[x_pos, y_pos];
            if (at == center_tile) return center_tile;
            short l = field[x_pos - 1, y_pos], r = field[x_pos + 1, y_pos];
            short t = field[x_pos, y_pos - 1], b = field[x_pos, y_pos + 1];

            if (type == 1 && (at == sides[0] || (at == corners[1] && l == inner[1] || l == sides[0]))) return inner[0];
            if (type == 2 && (at == sides[0] || (at == corners[0] && r == inner[0] || r == sides[0]))) return inner[1];
            if (type == 1 && (at == sides[3] || (at == corners[3] && l == inner[3] || l == sides[3]))) return inner[2];
            if (type == 2 && (at == sides[3] || (at == corners[2] && r == inner[2] || r == sides[3]))) return inner[3]; 

            if (type == 0 && (at == sides[1] || (at == corners[2] && t == inner[2] || t == sides[1]))) return inner[0];
            if (type == 0 && (at == sides[2] || (at == corners[3] && t == inner[3] || t == sides[2]))) return inner[1];
            if (type == 3 && (at == sides[1] || (at == corners[0] && b == inner[0] || b == sides[1]))) return inner[2];
            if (type == 3 && (at == sides[2] || (at == corners[1] && b == inner[1] || b == sides[2]))) return inner[3];

            if ((t == corners[0] || t == sides[1]) && (l == corners[0] || l == sides[0])) return inner[0];
            if ((t == corners[1] || t == sides[2]) && (r == corners[1] || r == sides[0])) return inner[1];
            if ((b == corners[2] || b == sides[1]) && (l == corners[2] || l == sides[3])) return inner[2];
            if ((b == corners[3] || b == sides[2]) && (r == corners[3] || r == sides[3])) return inner[3];

            if (type == 0 && b == center_tile) return sides[0];
            if (type == 1 && r == center_tile) return sides[1];
            if (type == 2 && l == center_tile) return sides[2];
            if (type == 3 && t == center_tile) return sides[3];
            return at;
       }
    }
}
