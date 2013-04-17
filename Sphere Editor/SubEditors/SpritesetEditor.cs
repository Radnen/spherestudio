using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sphere.Core.SphereObjects;
using Sphere_Editor.Forms;
using Sphere_Editor.EditorComponents;
using Sphere_Editor.SpritesetComponents;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere_Editor.SubEditors
{
    public partial class SpritesetEditor : EditorObject
    {
        #region attributes
        private Spriteset _sprite = null;
        private int _zoom = 3;
        private DirectionLayout _selected_direction = null;
        private TilesetControl2 _tileset_ctrl = null;
        private FramePanel _selected_frame = null;

        // Dock controls:
        private DockPanel MainDockPanel      = null;
        private DockContent DrawContent      = null;
        private DockContent DirectionContent = null;
        private DockContent ImageContent     = null;
        private DockContent AnimContent      = null;
        private DockContent BaseContent      = null;
        #endregion

        public SpritesetEditor()
        {
            InitializeComponent();
            InitializeDocking();

            _sprite = new Spriteset();
            DirectionAnim.Sprite = _sprite;
            FrameBaseEditor.Sprite = _sprite;
            FrameBaseEditor.Invalidate(true);
        }

        #region dock content
        private void InitializeDocking()
        {
            Controls.Remove(DirectionSplitter); 
            
            SpriteDrawer.Dock = DockStyle.Fill;
            DrawContent = new DockContent();
            DrawContent.Text = "Sprite Drawer";
            DrawContent.DockAreas = DockAreas.Document;
            DrawContent.DockHandler.CloseButtonVisible = false;
            DrawContent.Controls.Add(SpriteDrawer);

            DirectionHolder.Dock = DockStyle.Fill;
            DirectionContent = new DockContent();
            DirectionContent.Text = "Sprite Directions";
            DirectionContent.DockAreas = DockAreas.Document;
            DirectionContent.DockHandler.CloseButtonVisible = false;
            DirectionContent.Controls.Add(DirectionHolder);

            ImagePanel.Dock = DockStyle.Fill;
            ImageContent = new DockContent();
            ImageContent.Text = "Spriteset Images";
            ImageContent.DockAreas = DockAreas.DockLeft | DockAreas.DockRight | DockAreas.Float;
            ImageContent.DockHandler.CloseButtonVisible = false;
            ImageContent.Controls.Add(ImagePanel);

            AnimPanel.Dock = DockStyle.Fill;
            AnimContent = new DockContent();
            AnimContent.Text = "Direction Animation";
            AnimContent.DockAreas = DockAreas.DockLeft | DockAreas.DockRight | DockAreas.Float | DockAreas.DockBottom | DockAreas.DockTop;
            AnimContent.DockHandler.CloseButtonVisible = false;
            AnimContent.Controls.Add(AnimPanel);

            BasePanel.Dock = DockStyle.Fill;
            BaseContent = new DockContent();
            BaseContent.Text = "Base Editor";
            BaseContent.DockAreas = DockAreas.Document | DockAreas.DockTop | DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight;
            BaseContent.DockHandler.CloseButtonVisible = false;
            BaseContent.Controls.Add(BasePanel);

            MainDockPanel = new DockPanel();
            MainDockPanel.DocumentStyle = DocumentStyle.DockingWindow;
            MainDockPanel.Dock = DockStyle.Fill;
            if (System.IO.File.Exists("SpriteEditor.xml"))
            {
                DeserializeDockContent dc = new DeserializeDockContent(GetContent);
                MainDockPanel.LoadFromXml("SpriteEditor.xml", dc);
            }
            else
            {
                DirectionContent.Show(MainDockPanel, DockState.Document);
                BaseContent.Show(DirectionContent.Pane, DockAlignment.Bottom, 0.40);
                DrawContent.Show(BaseContent.PanelPane, BaseContent);
                ImageContent.Show(MainDockPanel, DockState.DockRight);
                AnimContent.Show(ImageContent.Pane, DockAlignment.Bottom, 0.40);
            }

            Controls.Add(MainDockPanel);
        }

        private WeifenLuo.WinFormsUI.Docking.IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == "WeifenLuo.WinFormsUI.Docking.DockContent") return DirectionContent;
            else return null;
        }

        private int _id = -1;
        public IDockContent GetContent(string persist)
        {
            if (persist == "WeifenLuo.WinFormsUI.Docking.DockContent")
            {
                _id++;
                switch (_id)
                {
                    case 0: return DirectionContent;
                    case 1: return BaseContent;
                    case 2: return DrawContent;
                    case 3: return ImageContent;
                    case 4: return AnimContent;
                    default: return new DockContent();
                }
            }
            else return new DockContent();
        }
        #endregion

        public void Init()
        {
            DirectionLayout layout;
            int i = 0;
            foreach (Direction d in _sprite.Directions)
            {
                layout = new DirectionLayout(_sprite, d, this);
                layout.OnFrameClick += new System.EventHandler(layout_OnFrameClick);
                layout.Modified += new System.EventHandler(Modified);
                layout.Zoom = _zoom;
                DirectionHolder.Controls.Add(layout);
                layout.Location = new Point(2, i++ * (layout.Height + 2) + 2);
            }
            ((DirectionLayout)DirectionHolder.Controls[0]).Select(0);
            _selected_frame = ((DirectionLayout)DirectionHolder.Controls[0]).SelectedFrame;
            SpriteDrawer.SetImage((Bitmap)_sprite.GetImage((((DirectionLayout)DirectionHolder.Controls[0]).SelectedFrame.Index)));
            SpriteDrawer.ZoomIn();
            SpriteDrawer.ZoomIn();
            _tileset_ctrl = new TilesetControl2();
            _tileset_ctrl.Tileset = Sphere.Core.SphereObjects.Tileset.FromSpriteset(_sprite);
            //_tileset_ctrl.IsMulti = false;
            //_tileset_ctrl.CanDrag = true;
            _tileset_ctrl.CanInsert = false;
            _tileset_ctrl.ZoomIn();
            _tileset_ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            _tileset_ctrl.TileSelected += new TilesetControl2.SelectedHandler(_tileset_ctrl_TileSelected);
            _tileset_ctrl.TileAdded += new TilesetControl2.TileHandler(_tileset_ctrl_TileAdded);
            _tileset_ctrl.TileRemoved += new TilesetControl2.TileHandler(_tileset_ctrl_TileRemoved);
            ImageHolder.Controls.Add(_tileset_ctrl);
            _tileset_ctrl.Width = ImageHolder.Width - 6;
            DirectionAnim.Sprite = _sprite;
            DirectionAnim.Direction = _sprite.Directions[0];
            FrameBaseEditor.Frame = _sprite.Directions[0].frames[0];
        }

        void _tileset_ctrl_TileSelected(List<short> tiles)
        {
            _selected_frame.Index = tiles[0];
            DirectionHolder.Invalidate(true);
            SpriteDrawer.SetImage(_tileset_ctrl.Tileset.Tiles[tiles[0]].Graphic);
            MakeDirty();
        }

        void _tileset_ctrl_TileRemoved(short startindex, List<Tile> tiles)
        {
            _sprite.RemoveFrameReference(startindex);
            DirectionHolder.Invalidate(true);
            MakeDirty();
        }

        void _tileset_ctrl_TileAdded(short startindex, List<Tile> tiles)
        {
            foreach (Tile t in tiles) _sprite.Images.Add(t.Graphic);
            MakeDirty();
        }

        public override void CreateNew()
        {
            _sprite.MakeNew();
            Init();
        }

        public override void LoadFile(string filename)
        {
            if (_sprite.Load(filename))
            {
                FileName = filename;
                Init();
            }
            else
            {
                MessageBox.Show("Error: Can't load spriteset: " + filename);
                ((DockContent)this.Parent).Close();
            }
        }

        public override void Save()
        {
            if (!IsSaved()) SaveAs();
            else
            {
                Parent.Text = System.IO.Path.GetFileName(FileName);
                _sprite.Save(FileName);
            }
        }

        public override void SaveAs()
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "Spriteset Files (.rss)|*.rss";

            if (Global.CurrentProject.RootPath != null)
                diag.InitialDirectory = Global.CurrentProject.RootPath + "\\spritesets";

            if (diag.ShowDialog() == DialogResult.OK)
            {
                FileName = diag.FileName;
                Save();
            }
        }

        public override void SaveLayout()
        {
            MainDockPanel.SaveAsXml("SpriteEditor.xml");
        }

        public void ResizeAll()
        {
            CallFormResize(false);
        }

        public void RescaleAll()
        {
            CallFormResize(true);
        }

        private void CallFormResize(bool rescale)
        {
            using (SizeForm frm = new SizeForm())
            {
                frm.WidthSize = _sprite.SpriteWidth;
                frm.HeightSize = _sprite.SpriteHeight;
                frm.UseScale = rescale;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _tileset_ctrl.ResizeTileset((short)frm.WidthSize, (short)frm.HeightSize, rescale);
                    for (short i = 0; i < _sprite.Images.Count; ++i)
                    {
                        _sprite.Images[i].Dispose();
                        _sprite.Images[i] = _tileset_ctrl.Tileset.Tiles[i].Graphic;
                    }
                    _sprite.SpriteWidth = (short)frm.WidthSize;
                    _sprite.SpriteHeight = (short)frm.HeightSize;
                }
                SpriteDrawer.SetImage((Bitmap)_sprite.GetImage(_selected_frame.Index));
                UpdateControls();
                MakeDirty();
            }

            // these method were made public to resize the contained image:
            FrameBaseEditor.UpdateCenterFrame();
            DirectionAnim.UpdateAnimPanel();
        }

        public override void Destroy()
        {
            _tileset_ctrl.Dispose();
            _sprite.Dispose();
        }

        private void layout_OnFrameClick(object sender, EventArgs e)
        {
            if (_selected_frame != null) _selected_frame.Selected = false;
            _selected_direction = (DirectionLayout)sender;
            _selected_frame = _selected_direction.SelectedFrame;
            SpriteDrawer.SetImage((Bitmap)_sprite.GetImage(_selected_frame.Index));
            FrameBaseEditor.Frame = _selected_frame.Frame;
            DirectionAnim.Direction = _selected_direction.Direction;
            DirectionAnim.Invalidate(true);
        }

        public override void ZoomIn()
        {
            if (_zoom < 8) _zoom++;
            else return;
            UpdateControls();
        }

        public override void ZoomOut()
        {
            if (_zoom > 1) _zoom--;
            else return;
            UpdateControls();
        }

        public void UpdateControls()
        {
            int i = 0;
            int val = DirectionHolder.VerticalScroll.Value;
            DirectionHolder.VerticalScroll.Value = 0;
            foreach (DirectionLayout l in DirectionHolder.Controls)
            {
                l.Zoom = _zoom;
                l.Location = new Point(2, i++ * (l.Height + 2) + 2);
            }
            DirectionHolder.VerticalScroll.Value = val;
            DirectionHolder.Invalidate();
        }

        public bool CanZoomIn { get { return _zoom < 8; } }
        public bool CanZoomOut { get { return _zoom > 1; } }
        public TilesetControl2 Tileset
        {
            get { return _tileset_ctrl; }
            set { _tileset_ctrl = value; }
        }

        public void AddNewDirection()
        {
            Direction d = new Direction("Direction_" + DirectionHolder.Controls.Count);
            d.frames.Add(new Frame());
            _sprite.Directions.Add(d);
            DirectionLayout layout = new DirectionLayout(_sprite, d, this);
            layout.OnFrameClick += new System.EventHandler(layout_OnFrameClick);
            layout.Modified += new System.EventHandler(Modified);
            layout.Zoom = _zoom;
            DirectionHolder.Controls.Add(layout);
            layout.Location = new Point(2, DirectionHolder.Controls.Count-1 * (layout.Height + 2) + 2);
            MakeDirty();
        }

        public void RemoveDirection(DirectionLayout layout)
        {
            _sprite.Directions.Remove(layout.Direction);
            DirectionHolder.Controls.Remove(layout);
            UpdateControls();
            MakeDirty();
        }

        private void SpriteDrawer_ImageEdited(object sender, EventArgs e)
        {
            Bitmap img = SpriteDrawer.GetImage();
            _sprite.Images[_selected_frame.Index] = img;
            _tileset_ctrl.Tileset.Tiles[_selected_frame.Index].Graphic = img;
            Modified(null, EventArgs.Empty);
            Invalidate(true);
        }

        private void Modified(object sender, EventArgs e)
        {
            MakeDirty();
        }
    }
}
