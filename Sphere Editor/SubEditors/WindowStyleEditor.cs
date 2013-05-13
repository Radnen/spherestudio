using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Core.Editor;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere_Editor.SubEditors
{
    public partial class WindowStyleEditor : EditorObject
    {
        #region attributes
        private Windowstyle _style;
        private bool _move;
        private int _tx, _ty;
        private int _windH, _windW;
        private int _id = -1;
        
        /* Docking Data */
        private DockContent _styleContent;
        private DockContent _imageContent;
        private DockPanel _styleDockPanel;
        #endregion

        public WindowStyleEditor()
        {
            InitializeComponent();
            InitializeDocking();
        }

        private void InitializeDocking()
        {
            Controls.Remove(MainSplitter);

            WindowHolder.Dock = DockStyle.Fill;
            StyleDrawer.Dock = DockStyle.Fill;
            _styleContent = new DockContent {Text = @"WindowStyle Preview"};
            _styleContent.Controls.Add(WindowHolder);
            _styleContent.Controls.Add(StyleStatusStrip);
            _styleContent.Controls.Add(StyleToolStrip);
            StyleStatusStrip.SendToBack();
            StyleToolStrip.BringToFront();

            _imageContent = new DockContent {Text = @"WindowStyle Image Editor"};
            _imageContent.Controls.Add(StyleDrawer);
            _styleContent.CloseButtonVisible = _imageContent.CloseButtonVisible = false;

            _styleDockPanel = new DockPanel {Dock = DockStyle.Fill, DocumentStyle = DocumentStyle.DockingWindow};
            if (File.Exists("WindowEditor.xml"))
            {
                DeserializeDockContent dc = GetContent;
                _styleDockPanel.LoadFromXml("WindowEditor.xml", dc);
            }
            else
            {
                _styleContent.Show(_styleDockPanel, DockState.Document);
                _imageContent.Show(_styleContent.Pane, DockAlignment.Bottom, 0.40);
            }

            Controls.Add(_styleDockPanel);
            _styleDockPanel.BringToFront();
        }

        public override void SaveLayout()
        {
            _styleDockPanel.SaveAsXml("WindowEditor.xml");
        }

        public IDockContent GetContent(string persist)
        {
            if (persist == "WeifenLuo.WinFormsUI.Docking.DockContent")
            {
                _id++;
                switch (_id)
                {
                    case 0: return _styleContent;
                    case 1: return _imageContent;
                    default: return new DockContent();
                }
            }
            return new DockContent();
        }

        public override void CreateNew()
        {
            _style = new Windowstyle {Grid = true};
            InitWindow();
        }

        public override void LoadFile(string filename)
        {
            FileName = filename;
            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
            {
                _style = new Windowstyle(reader);
            }
            _style.Grid = true;
            InitWindow();
        }

        public override void Copy() { StyleDrawer.Copy(); }
        public override void Paste() { StyleDrawer.Paste(); }
        public override void Undo() { StyleDrawer.Undo(); }
        public override void Redo() { StyleDrawer.Redo(); }

        private void InitWindow()
        {
            _style.GeneratePreview(WindowPanel.Width, WindowPanel.Height);
            StyleDrawer.SetImage(_style.Images[0]);
            StyleDrawer.ZoomIn();
            _windW = WindowPanel.Width;
            _windH = WindowPanel.Height;
        }

        private void CenterInContainer()
        {
            int x = (WindowHolder.Width >> 1) - (WindowPanel.Width >> 1);
            int y = (WindowHolder.Height >> 1) - (WindowPanel.Height >> 1);
            WindowPanel.Location = new Point(x, y);
        }

        private void StyleDrawer_ImageEdited(object sender, EventArgs e)
        {
            _style.Images[_style.Selected] = StyleDrawer.GetImage();
            _style.GeneratePreview(_windW, _windH);
            WindowPanel.Invalidate();
            MakeDirty();
        }

        public override void Save()
        {
            if (!IsSaved()) SaveAs();
            else
            {
                Parent.Text = Path.GetFileName(FileName);
                _style.Save(FileName);
            }
        }

        public override void SaveAs()
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.Filter = @"WindowStyle Files (.rws)|*.rws";

                if (Global.CurrentProject.RootPath != null)
                    diag.InitialDirectory = Global.CurrentProject.RootPath + "\\windowstyles";

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    FileName = diag.FileName;
                    Save();
                }
            }
        }

        public override void ZoomIn() { ZoomInItem_Click(null, EventArgs.Empty); }
        public override void ZoomOut() { ZoomOutItem_Click(null, EventArgs.Empty); }

        private void WindowStyleEditor_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void TestPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_style == null) return;
            _style.DrawWindow(e.Graphics);
        }

        private void TestPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_move)
            {
                WindowPanel.Top -= (_ty - e.Y);
                WindowPanel.Left -= (_tx - e.X);
            }

            int x = _style.Images[0].Width*_style.Zoom;
            int y = _style.Images[0].Height*_style.Zoom;
            int w = WindowPanel.Width - (x + x);
            int h = WindowPanel.Height - (y + y);
            Cursor = PointWithin(e.Location, x, y, w, h) ? Cursors.SizeAll : Cursors.Default;
        }

        private bool PointWithin(Point pos, int x, int y, int width, int height)
        {
            return (pos.X > x && pos.Y > y && pos.X < x + width && pos.Y < y + height);
        }

        private void SelectImage(int num)
        {
            _style.Selected = num;
            StyleDrawer.SetImage(_style.Images[num]);
            WindowPanel.Refresh();
        }

        private void TestPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            for (int i = 0; i < 8; ++i)
            {
                if (_style.IsPointWithinSection(e.Location, i)) SelectImage(i);
            }

            _move = true;
            _tx = e.X;
            _ty = e.Y;
        }

        private void TestPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _move = false;
        }

        private void GridItem_Click(object sender, EventArgs e)
        {
            _style.Grid = !_style.Grid;
            WindowPanel.Refresh();
        }

        private void ZoomInItem_Click(object sender, EventArgs e)
        {
            ZoomOutItem.Enabled = ZoomOutButton.Enabled = true;
            if (_style.Zoom < 4)
            {
                _style.Zoom++;
                if (_style.Zoom == 4) ZoomInItem.Enabled = ZoomInButton.Enabled = false;
            }
            WindowPanel.Width = _windW * _style.Zoom;
            WindowPanel.Height = _windH * _style.Zoom;
            ZoomLabel.Text = @"Zoom: " + _style.Zoom;
            CenterInContainer();
            WindowPanel.Refresh();
        }

        private void ZoomOutItem_Click(object sender, EventArgs e)
        {
            ZoomInItem.Enabled = ZoomInButton.Enabled = true;
            if (_style.Zoom > 1)
            {
                _style.Zoom--;
                if (_style.Zoom == 1) ZoomOutItem.Enabled = ZoomOutButton.Enabled = false;
            }
            WindowPanel.Width = _windW * _style.Zoom;
            WindowPanel.Height = _windH * _style.Zoom;
            ZoomLabel.Text = @"Zoom: " + _style.Zoom;
            CenterInContainer();
            WindowPanel.Refresh();
        }

        private void EditBGItem_Click(object sender, EventArgs e)
        {
            _style.Selected = 8;
            StyleDrawer.SetImage(_style.Images[8]);
            WindowPanel.Refresh();
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            if (_style.Selected > 0) _style.Selected--;
            SelectImage(_style.Selected);
            ImgLabel.Text = @"Image: " + _style.Selected;
            LeftButton.Enabled = _style.Selected > 0;
            if (!LeftButton.Enabled) HelpLabel.Text = "";
            RightButton.Enabled = true;
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            if (_style.Selected < 8) _style.Selected++;
            SelectImage(_style.Selected);
            ImgLabel.Text = @"Image: " + _style.Selected;
            RightButton.Enabled = _style.Selected < 8;
            if (!RightButton.Enabled) HelpLabel.Text = "";
            LeftButton.Enabled = true;
        }

        #region tip texts
        private void ClearTip(object sender, EventArgs e)
        {
            HelpLabel.Text = "";
        }

        private void WindowPanel_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"Selecting a side allows you to edit that portion.";
        }

        private void WindowPanel_MouseLeave(object sender, EventArgs e)
        {
            HelpLabel.Text = "";
            Cursor = Cursors.Default;
        }

        private void GridButton_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"The grid can show you the window sections.";
        }

        private void WindowHolder_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"Right-click to show the context menu.";
        }

        private void LeftButton_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"Click to set last image.";
        }

        private void RightButton_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"Click to set next image.";
        }

        private void EditBGItem_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"Directly edit the window background.";
        }

        #endregion

        private void WindowHolder_Resize(object sender, EventArgs e)
        {
            CenterInContainer();
        }
    }
}
