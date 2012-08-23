namespace Sphere_Editor.EditorComponents
{
    partial class ImageEditorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditorControl));
            this.DrawMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GetPixelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplacePixelsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToggleGridItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.UndoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSeperator3 = new System.Windows.Forms.ToolStripSeparator();
            this.EditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SlideItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlipHorizontalItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlipVerticalItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateCWItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateCCWItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FiltersItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlurItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorNoiseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MonoNoiseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InvertColorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrayscaleItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyImageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteImageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawMenuStrip
            // 
            this.DrawMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetPixelItem,
            this.ReplacePixelsItem,
            this.MenuSeperator1,
            this.ToggleGridItem,
            this.MenuSeparator2,
            this.UndoMenuItem,
            this.RedoMenuItem,
            this.MenuSeperator3,
            this.EditItem,
            this.FiltersItem,
            this.toolStripSeparator1,
            this.CopyImageItem,
            this.PasteImageItem});
            this.DrawMenuStrip.Name = "DrawMenuStrip";
            this.DrawMenuStrip.Size = new System.Drawing.Size(179, 226);
            // 
            // GetPixelItem
            // 
            this.GetPixelItem.Image = global::Sphere_Editor.Properties.Resources.pencil;
            this.GetPixelItem.Name = "GetPixelItem";
            this.GetPixelItem.Size = new System.Drawing.Size(178, 22);
            this.GetPixelItem.Text = "&Get Pixel";
            this.GetPixelItem.Click += new System.EventHandler(this.GetPixelItem_Click);
            // 
            // ReplacePixelsItem
            // 
            this.ReplacePixelsItem.Name = "ReplacePixelsItem";
            this.ReplacePixelsItem.Size = new System.Drawing.Size(178, 22);
            this.ReplacePixelsItem.Text = "&Replace Color";
            this.ReplacePixelsItem.Click += new System.EventHandler(this.ReplacePixelsItem_Click);
            // 
            // MenuSeperator1
            // 
            this.MenuSeperator1.Name = "MenuSeperator1";
            this.MenuSeperator1.Size = new System.Drawing.Size(175, 6);
            // 
            // ToggleGridItem
            // 
            this.ToggleGridItem.Image = global::Sphere_Editor.Properties.Resources.grid;
            this.ToggleGridItem.Name = "ToggleGridItem";
            this.ToggleGridItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.ToggleGridItem.Size = new System.Drawing.Size(178, 22);
            this.ToggleGridItem.Text = "&Toggle Grid";
            this.ToggleGridItem.Click += new System.EventHandler(this.ToggleGridItem_Click);
            // 
            // MenuSeparator2
            // 
            this.MenuSeparator2.Name = "MenuSeparator2";
            this.MenuSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // UndoMenuItem
            // 
            this.UndoMenuItem.Enabled = false;
            this.UndoMenuItem.Image = global::Sphere_Editor.Properties.Resources.arrow_undo;
            this.UndoMenuItem.Name = "UndoMenuItem";
            this.UndoMenuItem.Size = new System.Drawing.Size(178, 22);
            this.UndoMenuItem.Text = "&Undo";
            this.UndoMenuItem.Click += new System.EventHandler(this.UndoMenuItem_Click);
            // 
            // RedoMenuItem
            // 
            this.RedoMenuItem.Enabled = false;
            this.RedoMenuItem.Image = global::Sphere_Editor.Properties.Resources.arrow_redo;
            this.RedoMenuItem.Name = "RedoMenuItem";
            this.RedoMenuItem.Size = new System.Drawing.Size(178, 22);
            this.RedoMenuItem.Text = "&Redo";
            this.RedoMenuItem.Click += new System.EventHandler(this.RedoMenuItem_Click);
            // 
            // MenuSeperator3
            // 
            this.MenuSeperator3.Name = "MenuSeperator3";
            this.MenuSeperator3.Size = new System.Drawing.Size(175, 6);
            // 
            // EditItem
            // 
            this.EditItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SlideItem,
            this.FlipHorizontalItem,
            this.FlipVerticalItem,
            this.RotateCWItem,
            this.RotateCCWItem});
            this.EditItem.Name = "EditItem";
            this.EditItem.Size = new System.Drawing.Size(178, 22);
            this.EditItem.Text = "&Edit";
            // 
            // SlideItem
            // 
            this.SlideItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpItem,
            this.DownItem,
            this.LeftItem,
            this.RightItem});
            this.SlideItem.Name = "SlideItem";
            this.SlideItem.Size = new System.Drawing.Size(151, 22);
            this.SlideItem.Text = "&Slide";
            // 
            // UpItem
            // 
            this.UpItem.Name = "UpItem";
            this.UpItem.Size = new System.Drawing.Size(105, 22);
            this.UpItem.Text = "&Up";
            this.UpItem.Click += new System.EventHandler(this.UpItem_Click);
            // 
            // DownItem
            // 
            this.DownItem.Name = "DownItem";
            this.DownItem.Size = new System.Drawing.Size(105, 22);
            this.DownItem.Text = "&Down";
            this.DownItem.Click += new System.EventHandler(this.DownItem_Click);
            // 
            // LeftItem
            // 
            this.LeftItem.Name = "LeftItem";
            this.LeftItem.Size = new System.Drawing.Size(105, 22);
            this.LeftItem.Text = "&Left";
            this.LeftItem.Click += new System.EventHandler(this.LeftItem_Click);
            // 
            // RightItem
            // 
            this.RightItem.Name = "RightItem";
            this.RightItem.Size = new System.Drawing.Size(105, 22);
            this.RightItem.Text = "&Right";
            this.RightItem.Click += new System.EventHandler(this.RightItem_Click);
            // 
            // FlipHorizontalItem
            // 
            this.FlipHorizontalItem.Name = "FlipHorizontalItem";
            this.FlipHorizontalItem.Size = new System.Drawing.Size(151, 22);
            this.FlipHorizontalItem.Text = "Flip &Horizontal";
            this.FlipHorizontalItem.Click += new System.EventHandler(this.FlipHorizontalItem_Click);
            // 
            // FlipVerticalItem
            // 
            this.FlipVerticalItem.Name = "FlipVerticalItem";
            this.FlipVerticalItem.Size = new System.Drawing.Size(151, 22);
            this.FlipVerticalItem.Text = "Flip &Vertical";
            this.FlipVerticalItem.Click += new System.EventHandler(this.FlipVerticalItem_Click);
            // 
            // RotateCWItem
            // 
            this.RotateCWItem.Image = ((System.Drawing.Image)(resources.GetObject("RotateCWItem.Image")));
            this.RotateCWItem.Name = "RotateCWItem";
            this.RotateCWItem.Size = new System.Drawing.Size(151, 22);
            this.RotateCWItem.Text = "Rotate CW";
            this.RotateCWItem.Click += new System.EventHandler(this.RotateCWItem_Click);
            // 
            // RotateCCWItem
            // 
            this.RotateCCWItem.Image = ((System.Drawing.Image)(resources.GetObject("RotateCCWItem.Image")));
            this.RotateCCWItem.Name = "RotateCCWItem";
            this.RotateCCWItem.Size = new System.Drawing.Size(151, 22);
            this.RotateCCWItem.Text = "Rotate CCW";
            this.RotateCCWItem.Click += new System.EventHandler(this.RotateCCWItem_Click);
            // 
            // FiltersItem
            // 
            this.FiltersItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BlurItem,
            this.ColorNoiseItem,
            this.MonoNoiseItem,
            this.InvertColorItem,
            this.GrayscaleItem});
            this.FiltersItem.Image = global::Sphere_Editor.Properties.Resources.lightning;
            this.FiltersItem.Name = "FiltersItem";
            this.FiltersItem.Size = new System.Drawing.Size(178, 22);
            this.FiltersItem.Text = "&Filters";
            this.FiltersItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // BlurItem
            // 
            this.BlurItem.Name = "BlurItem";
            this.BlurItem.Size = new System.Drawing.Size(141, 22);
            this.BlurItem.Text = "&Blur";
            this.BlurItem.Click += new System.EventHandler(this.BlurItem_Click);
            // 
            // ColorNoiseItem
            // 
            this.ColorNoiseItem.Name = "ColorNoiseItem";
            this.ColorNoiseItem.Size = new System.Drawing.Size(141, 22);
            this.ColorNoiseItem.Text = "Color &Noise";
            this.ColorNoiseItem.Click += new System.EventHandler(this.NoiseItem_Click);
            // 
            // MonoNoiseItem
            // 
            this.MonoNoiseItem.Name = "MonoNoiseItem";
            this.MonoNoiseItem.Size = new System.Drawing.Size(141, 22);
            this.MonoNoiseItem.Text = "&Mono Noise";
            this.MonoNoiseItem.Click += new System.EventHandler(this.MonoNoiseItem_Click);
            // 
            // InvertColorItem
            // 
            this.InvertColorItem.Name = "InvertColorItem";
            this.InvertColorItem.Size = new System.Drawing.Size(141, 22);
            this.InvertColorItem.Text = "&Invert Colors";
            this.InvertColorItem.Click += new System.EventHandler(this.InvertColorItem_Click);
            // 
            // GrayscaleItem
            // 
            this.GrayscaleItem.Name = "GrayscaleItem";
            this.GrayscaleItem.Size = new System.Drawing.Size(141, 22);
            this.GrayscaleItem.Text = "&Grayscale";
            this.GrayscaleItem.Click += new System.EventHandler(this.GrayscaleItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // CopyImageItem
            // 
            this.CopyImageItem.Image = global::Sphere_Editor.Properties.Resources.page_copy;
            this.CopyImageItem.Name = "CopyImageItem";
            this.CopyImageItem.Size = new System.Drawing.Size(178, 22);
            this.CopyImageItem.Text = "&Copy Image";
            this.CopyImageItem.Click += new System.EventHandler(this.CopyImageItem_Click);
            // 
            // PasteImageItem
            // 
            this.PasteImageItem.Image = global::Sphere_Editor.Properties.Resources.paste_plain;
            this.PasteImageItem.Name = "PasteImageItem";
            this.PasteImageItem.Size = new System.Drawing.Size(178, 22);
            this.PasteImageItem.Text = "&Paste Image";
            this.PasteImageItem.Click += new System.EventHandler(this.PasteImageItem_Click);
            // 
            // ImageEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.DrawMenuStrip;
            this.DoubleBuffered = true;
            this.Name = "ImageEditorControl";
            this.Size = new System.Drawing.Size(80, 80);
            this.Load += new System.EventHandler(this.ImageEditorControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageEditorControl_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageEditorControl_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImageEditorControl_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageEditorControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageEditorControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageEditorControl_MouseUp);
            this.DrawMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip DrawMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem GetPixelItem;
        private System.Windows.Forms.ToolStripSeparator MenuSeperator1;
        private System.Windows.Forms.ToolStripMenuItem ToggleGridItem;
        private System.Windows.Forms.ToolStripSeparator MenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CopyImageItem;
        private System.Windows.Forms.ToolStripMenuItem PasteImageItem;
        private System.Windows.Forms.ToolStripMenuItem UndoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RedoMenuItem;
        private System.Windows.Forms.ToolStripSeparator MenuSeperator3;
        private System.Windows.Forms.ToolStripMenuItem ReplacePixelsItem;
        private System.Windows.Forms.ToolStripMenuItem FiltersItem;
        private System.Windows.Forms.ToolStripMenuItem BlurItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ColorNoiseItem;
        private System.Windows.Forms.ToolStripMenuItem MonoNoiseItem;
        private System.Windows.Forms.ToolStripMenuItem InvertColorItem;
        private System.Windows.Forms.ToolStripMenuItem GrayscaleItem;
        private System.Windows.Forms.ToolStripMenuItem EditItem;
        private System.Windows.Forms.ToolStripMenuItem SlideItem;
        private System.Windows.Forms.ToolStripMenuItem UpItem;
        private System.Windows.Forms.ToolStripMenuItem DownItem;
        private System.Windows.Forms.ToolStripMenuItem LeftItem;
        private System.Windows.Forms.ToolStripMenuItem RightItem;
        private System.Windows.Forms.ToolStripMenuItem FlipHorizontalItem;
        private System.Windows.Forms.ToolStripMenuItem FlipVerticalItem;
        private System.Windows.Forms.ToolStripMenuItem RotateCCWItem;
        private System.Windows.Forms.ToolStripMenuItem RotateCWItem;
    }
}
