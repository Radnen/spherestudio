using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Core.Editor;
using Sphere.Plugins;
using SphereStudio.Plugins.Components;
using SphereStudio.Plugins.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SphereStudio.Plugins
{
    partial class SpritesetEditView : DocumentView
    {
        #region attributes
        private readonly Spriteset _sprite;
        private int _zoom = 3;
        private DirectionLayout _selectedDirection;
        private TilesetControl2 _tilesetCtrl;
        private FramePanel _selectedFrame;

        // Dock controls:
        private DockPanel _mainDockPanel;
        private DockContent _drawContent;
        private DockContent _directionContent;
        private DockContent _imageContent;
        private DockContent _animContent;
        private DockContent _baseContent;
        #endregion

        public SpritesetEditView()
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
            _drawContent = new DockContent {Text = @"Sprite Drawer", DockAreas = DockAreas.Document};
            _drawContent.DockHandler.CloseButtonVisible = false;
            _drawContent.Controls.Add(SpriteDrawer);

            DirectionHolder.Dock = DockStyle.Fill;
            _directionContent = new DockContent {Text = @"Sprite Directions", DockAreas = DockAreas.Document};
            _directionContent.DockHandler.CloseButtonVisible = false;
            _directionContent.Controls.Add(DirectionHolder);

            ImagePanel.Dock = DockStyle.Fill;
            _imageContent = new DockContent
                {
                    Text = @"Spriteset Images",
                    DockAreas = DockAreas.DockLeft | DockAreas.DockRight | DockAreas.Float
                };
            _imageContent.DockHandler.CloseButtonVisible = false;
            _imageContent.Controls.Add(ImagePanel);

            AnimPanel.Dock = DockStyle.Fill;
            _animContent = new DockContent
                {
                    Text = @"Direction Animation",
                    DockAreas =
                        DockAreas.DockLeft | DockAreas.DockRight | DockAreas.Float | DockAreas.DockBottom |
                        DockAreas.DockTop
                };
            _animContent.DockHandler.CloseButtonVisible = false;
            _animContent.Controls.Add(AnimPanel);

            BasePanel.Dock = DockStyle.Fill;
            _baseContent = new DockContent
                {
                    Text = @"Base Editor",
                    DockAreas =
                        DockAreas.Document | DockAreas.DockTop | DockAreas.DockBottom | DockAreas.DockLeft |
                        DockAreas.DockRight
                };
            _baseContent.DockHandler.CloseButtonVisible = false;
            _baseContent.Controls.Add(BasePanel);

            _mainDockPanel = new DockPanel {DocumentStyle = DocumentStyle.DockingWindow, Dock = DockStyle.Fill};
            if (File.Exists("SpriteEditor.xml"))
            {
                DeserializeDockContent dc = GetContent;
                _mainDockPanel.LoadFromXml("SpriteEditor.xml", dc);
            }
            else
            {
                _directionContent.Show(_mainDockPanel, DockState.Document);
                _baseContent.Show(_directionContent.Pane, DockAlignment.Bottom, 0.40);
                _drawContent.Show(_baseContent.PanelPane, _baseContent);
                _imageContent.Show(_mainDockPanel, DockState.DockRight);
                _animContent.Show(_imageContent.Pane, DockAlignment.Bottom, 0.40);
            }

            Controls.Add(_mainDockPanel);
        }

        private int _id = -1;
        public IDockContent GetContent(string persist)
        {
            if (persist == "WeifenLuo.WinFormsUI.Docking.DockContent")
            {
                _id++;
                switch (_id)
                {
                    case 0: return _directionContent;
                    case 1: return _baseContent;
                    case 2: return _drawContent;
                    case 3: return _imageContent;
                    case 4: return _animContent;
                    default: return new DockContent();
                }
            }
            return new DockContent();
        }

        #endregion

        public void Init()
        {
            int i = 0;
            foreach (Direction d in _sprite.Directions)
            {
                DirectionLayout layout = new DirectionLayout(_sprite, d, this);
                layout.OnFrameClick += layout_OnFrameClick;
                layout.Modified += Modified;
                layout.Zoom = _zoom;
                DirectionHolder.Controls.Add(layout);
                layout.Location = new Point(2, i++ * (layout.Height + 2) + 2);
            }
            ((DirectionLayout)DirectionHolder.Controls[0]).Select(0);
            _selectedFrame = ((DirectionLayout)DirectionHolder.Controls[0]).SelectedFrame;
            SpriteDrawer.Content = (Bitmap)_sprite.GetImage((((DirectionLayout)DirectionHolder.Controls[0]).SelectedFrame.Index));
            SpriteDrawer.ZoomIn();
            SpriteDrawer.ZoomIn();
            _tilesetCtrl = new TilesetControl2 {Tileset = Sphere.Core.Tileset.FromSpriteset(_sprite), CanInsert = false};
            _tilesetCtrl.ZoomIn();
            _tilesetCtrl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            _tilesetCtrl.TileSelected += _tileset_ctrl_TileSelected;
            _tilesetCtrl.TileAdded += _tileset_ctrl_TileAdded;
            _tilesetCtrl.TileRemoved += _tileset_ctrl_TileRemoved;
            ImageHolder.Controls.Add(_tilesetCtrl);
            _tilesetCtrl.Width = ImageHolder.Width - 6;
            DirectionAnim.Sprite = _sprite;
            DirectionAnim.Direction = _sprite.Directions[0];
            FrameBaseEditor.Frame = _sprite.Directions[0].Frames[0];
        }

        void _tileset_ctrl_TileSelected(List<short> tiles)
        {
            _selectedFrame.Index = tiles[0];
            DirectionHolder.Invalidate(true);
            SpriteDrawer.Content = _tilesetCtrl.Tileset.Tiles[tiles[0]].Graphic;
            IsDirty = true;
        }

        void _tileset_ctrl_TileRemoved(short startindex, List<Tile> tiles)
        {
            _sprite.RemoveFrameReference(startindex);
            DirectionHolder.Invalidate(true);
            IsDirty = true;
        }

        void _tileset_ctrl_TileAdded(short startindex, List<Tile> tiles)
        {
            foreach (Tile t in tiles) _sprite.Images.Add(t.Graphic);
            IsDirty = true;
        }

        public override string[] FileExtensions
        {
            get { return new[] { "rss" }; }
        }
        
        public override bool NewDocument()
        {
            _sprite.MakeNew();
            Init();
            return true;
        }

        public override void Load(string filepath)
        {
            if (_sprite.Load(filepath))
            {
                Init();
            }
            else
            {
                MessageBox.Show(@"Error: Can't load spriteset: " + filepath);
                ((DockContent)Parent).Close();
            }
        }

        public override void Save(string filepath)
        {
            _sprite.Save(filepath);
        }

        public override void Activate()
        {
            SpritesetEditPlugin.ShowMenus(true);
        }

        public override void Deactivate()
        {
            SpritesetEditPlugin.ShowMenus(false);
        }






        public void SaveLayout()
        {
            _mainDockPanel.SaveAsXml("SpriteEditor.xml");
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
                    _tilesetCtrl.ResizeTileset((short)frm.WidthSize, (short)frm.HeightSize, rescale);
                    for (short i = 0; i < _sprite.Images.Count; ++i)
                    {
                        _sprite.Images[i].Dispose();
                        _sprite.Images[i] = _tilesetCtrl.Tileset.Tiles[i].Graphic;
                    }
                    _sprite.SpriteWidth = (short)frm.WidthSize;
                    _sprite.SpriteHeight = (short)frm.HeightSize;
                }
                SpriteDrawer.Content = (Bitmap)_sprite.GetImage(_selectedFrame.Index);
                UpdateControls();
                IsDirty = true;
            }

            // these method were made public to resize the contained image:
            FrameBaseEditor.UpdateCenterFrame();
            DirectionAnim.UpdateAnimPanel();
        }

        private void layout_OnFrameClick(object sender, EventArgs e)
        {
            if (_selectedFrame != null) _selectedFrame.Selected = false;
            _selectedDirection = (DirectionLayout)sender;
            _selectedFrame = _selectedDirection.SelectedFrame;
            SpriteDrawer.Content = (Bitmap)_sprite.GetImage(_selectedFrame.Index);
            FrameBaseEditor.Frame = _selectedFrame.Frame;
            DirectionAnim.Direction = _selectedDirection.Direction;
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
            get { return _tilesetCtrl; }
            set { _tilesetCtrl = value; }
        }

        public void AddNewDirection()
        {
            Direction d = new Direction("Direction_" + DirectionHolder.Controls.Count);
            d.Frames.Add(new Frame());
            _sprite.Directions.Add(d);
            DirectionLayout layout = new DirectionLayout(_sprite, d, this);
            layout.OnFrameClick += layout_OnFrameClick;
            layout.Modified += Modified;
            layout.Zoom = _zoom;
            DirectionHolder.Controls.Add(layout);
            layout.Location = new Point(2, DirectionHolder.Controls.Count-1 * (layout.Height + 2) + 2);
            IsDirty = true;
        }

        public void RemoveDirection(DirectionLayout layout)
        {
            _sprite.Directions.Remove(layout.Direction);
            DirectionHolder.Controls.Remove(layout);
            UpdateControls();
            IsDirty = true;
        }

        private void SpriteDrawer_ImageChanged(object sender, EventArgs e)
        {
            Bitmap img = SpriteDrawer.Content;
            _sprite.Images[_selectedFrame.Index] = img;
            _tilesetCtrl.Tileset.Tiles[_selectedFrame.Index].Graphic = img;
            Modified(sender, e);
            Invalidate(true);
        }

        private void Modified(object sender, EventArgs e)
        {
            IsDirty = true;
        }
    }
}
