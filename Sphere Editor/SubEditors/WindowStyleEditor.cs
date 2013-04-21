using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere.Core;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere_Editor.SubEditors
{
    public partial class WindowStyleEditor : EditorObject
    {
        #region attributes
        private Windowstyle style;
        private bool _move = false;
        private int tx = 0;
        private int ty = 0;
        private int wind_h = 0;
        private int wind_w = 0;

        /* Docking Data */
        private DockContent StyleContent;
        private DockContent ImageContent;
        private DockPanel StyleDockPanel;
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
            StyleContent = new DockContent();
            StyleContent.Text = "WindowStyle Preview";
            StyleContent.Controls.Add(WindowHolder);
            StyleContent.Controls.Add(StyleStatusStrip);
            StyleContent.Controls.Add(StyleToolStrip);
            StyleStatusStrip.SendToBack();
            StyleToolStrip.BringToFront();

            ImageContent = new DockContent();
            ImageContent.Text = "WindowStyle Image Editor";
            ImageContent.Controls.Add(StyleDrawer);
            StyleContent.CloseButtonVisible = ImageContent.CloseButtonVisible = false;

            StyleDockPanel = new DockPanel();
            StyleDockPanel.Dock = DockStyle.Fill;
            StyleDockPanel.DocumentStyle = DocumentStyle.DockingWindow;
            if (System.IO.File.Exists("WindowEditor.xml"))
            {
                DeserializeDockContent dc = new DeserializeDockContent(GetContent);
                StyleDockPanel.LoadFromXml("WindowEditor.xml", dc);
            }
            else
            {
                StyleContent.Show(StyleDockPanel, DockState.Document);
                ImageContent.Show(StyleContent.Pane, DockAlignment.Bottom, 0.40);
            }

            Controls.Add(StyleDockPanel);
            StyleDockPanel.BringToFront();
        }

        public override void SaveLayout()
        {
            StyleDockPanel.SaveAsXml("WindowEditor.xml");
        }

        private int _id = -1;
        public IDockContent GetContent(string persist)
        {
            if (persist == "WeifenLuo.WinFormsUI.Docking.DockContent")
            {
                _id++;
                switch (_id)
                {
                    case 0: return StyleContent;
                    case 1: return ImageContent;
                    default: return new DockContent();
                }
            }
            else return new DockContent();
        }
        
        public override void CreateNew()
        {
            style = new Windowstyle();
            style.Grid = true;
            InitWindow();
        }

        public override void LoadFile(string filename)
        {
            FileName = filename;
            using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
            {
                style = new Windowstyle(reader);
            }
            style.Grid = true;
            InitWindow();
        }

        public override void Copy() { StyleDrawer.Copy(); }
        public override void Paste() { StyleDrawer.Paste(); }
        public override void Undo() { StyleDrawer.Undo(); }
        public override void Redo() { StyleDrawer.Redo(); }

        private void InitWindow()
        {
            style.GeneratePreview(WindowPanel.Width, WindowPanel.Height);
            StyleDrawer.SetImage(style.Images[0]);
            StyleDrawer.ZoomIn();
            wind_w = WindowPanel.Width;
            wind_h = WindowPanel.Height;
        }

        private void CenterInContainer()
        {
            int x = (WindowHolder.Width >> 1) - (WindowPanel.Width >> 1);
            int y = (WindowHolder.Height >> 1) - (WindowPanel.Height >> 1);
            WindowPanel.Location = new Point(x, y);
        }

        private void StyleDrawer_ImageEdited(object sender, EventArgs e)
        {
            style.Images[style.Selected] = StyleDrawer.GetImage();
            style.GeneratePreview(wind_w, wind_h);
            WindowPanel.Invalidate();
            MakeDirty();
        }

        public override void Save()
        {
            if (!IsSaved()) SaveAs();
            else
            {
                Parent.Text = Path.GetFileName(FileName);
                style.Save(FileName);
            }
        }

        public override void SaveAs()
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.Filter = "WindowStyle Files (.rws)|*.rws";

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
            if (style == null) return;
            style.DrawWindow(e.Graphics);
        }

        private void TestPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_move)
            {
                WindowPanel.Top -= (ty - e.Y);
                WindowPanel.Left -= (tx - e.X);
            }

            int x = style.Images[0].Width*style.Zoom;
            int y = style.Images[0].Height*style.Zoom;
            int w = WindowPanel.Width - (x + x);
            int h = WindowPanel.Height - (y + y);
            if (PointWithin(e.Location, x, y, w, h)) Cursor = Cursors.SizeAll;
            else Cursor = Cursors.Default;
        }

        private bool PointWithin(Point pos, int x, int y, int width, int height)
        {
            return (pos.X > x && pos.Y > y && pos.X < x + width && pos.Y < y + height);
        }

        private void SelectImage(int num)
        {
            style.Selected = num;
            StyleDrawer.SetImage(style.Images[num]);
            WindowPanel.Refresh();
        }

        private void TestPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) return;
            for (int i = 0; i < 8; ++i)
            {
                if (style.IsPointWithinSection(e.Location, i)) SelectImage(i);
            }

            _move = true;
            tx = e.X;
            ty = e.Y;
        }

        private void TestPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _move = false;
        }

        private void GridItem_Click(object sender, EventArgs e)
        {
            style.Grid = !style.Grid;
            WindowPanel.Refresh();
        }

        private void ZoomInItem_Click(object sender, EventArgs e)
        {
            ZoomOutItem.Enabled = ZoomOutButton.Enabled = true;
            if (style.Zoom < 4)
            {
                style.Zoom++;
                if (style.Zoom == 4) ZoomInItem.Enabled = ZoomInButton.Enabled = false;
            }
            WindowPanel.Width = wind_w * style.Zoom;
            WindowPanel.Height = wind_h * style.Zoom;
            ZoomLabel.Text = "Zoom: " + style.Zoom;
            CenterInContainer();
            WindowPanel.Refresh();
        }

        private void ZoomOutItem_Click(object sender, EventArgs e)
        {
            ZoomInItem.Enabled = ZoomInButton.Enabled = true;
            if (style.Zoom > 1)
            {
                style.Zoom--;
                if (style.Zoom == 1) ZoomOutItem.Enabled = ZoomOutButton.Enabled = false;
            }
            WindowPanel.Width = wind_w * style.Zoom;
            WindowPanel.Height = wind_h * style.Zoom;
            ZoomLabel.Text = "Zoom: " + style.Zoom;
            CenterInContainer();
            WindowPanel.Refresh();
        }

        private void EditBGItem_Click(object sender, EventArgs e)
        {
            style.Selected = 8;
            StyleDrawer.SetImage(style.Images[8]);
            WindowPanel.Refresh();
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            if (style.Selected > 0) style.Selected--;
            SelectImage(style.Selected);
            ImgLabel.Text = "Image: " + style.Selected;
            LeftButton.Enabled = style.Selected > 0;
            if (!LeftButton.Enabled) HelpLabel.Text = "";
            RightButton.Enabled = true;
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            if (style.Selected < 8) style.Selected++;
            SelectImage(style.Selected);
            ImgLabel.Text = "Image: " + style.Selected;
            RightButton.Enabled = style.Selected < 8;
            if (!RightButton.Enabled) HelpLabel.Text = "";
            LeftButton.Enabled = true;
        }

        #region tip texts
        private void ClearTip(object sender, EventArgs e)
        {
            this.HelpLabel.Text = "";
        }

        private void WindowPanel_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "Selecting a side allows you to edit that portion.";
        }

        private void WindowPanel_MouseLeave(object sender, EventArgs e)
        {
            this.HelpLabel.Text = "";
            this.Cursor = Cursors.Default;
        }

        private void GridButton_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "The grid can show you the window sections.";
        }

        private void StyleDrawer_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "The drawer will automatically update the windowstyle.";
        }

        private void WindowHolder_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "Right-click to show the context menu.";
        }

        private void LeftButton_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "Click to set last image.";
        }

        private void RightButton_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "Click to set next image.";
        }

        private void EditBGItem_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "Directly edit the window background.";
        }

        private void CenterButton_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "Click to center the windowstyle.";
        }
        #endregion

        private void WindowHolder_Resize(object sender, EventArgs e)
        {
            CenterInContainer();
        }
    }
}
