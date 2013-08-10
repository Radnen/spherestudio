using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Sphere.Core;

namespace SphereStudio.RadEditors
{
    internal class RadControl
    {
        private int x, y, w, h;
        private bool outlined, can_resize = false;
        private string name = string.Empty;
        private RadControl parent;
        private Control preview;

        public RadControl() { }

        public int X
        {
            get { return x; }
            set { x = value; preview.Location = new Point(value, preview.Location.Y); }
        }

        public int Y
        {
            get { return y; }
            set { y = value; preview.Location = new Point(preview.Location.X, value); }
        }

        public int W
        {
            get { return w; }
            set { w = value; preview.Size = new Size(value, preview.Size.Height); preview.Invalidate(); }
        }

        public int H
        {
            get { return h; }
            set { h = value; preview.Size = new Size(preview.Size.Width, value); preview.Invalidate(); }
        }

        public bool Outlined
        {
            get { return outlined; }
            set { outlined = value; preview.Invalidate(); }
        }

        public bool CanResize
        {
            get { return can_resize; }
            set { can_resize = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; Preview.Name = value; }
        }

        public Control Preview
        {
            get { return preview; }
            set
            {
                preview = value;
                x = value.Location.X;
                y = value.Location.Y;
                w = value.Width;
                h = value.Height;
            }
        }

        public RadControl Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public virtual void ToBaseCode(StringBuilder builder)
        {
            builder.Append("\t//Code for: ");
            builder.AppendLine(this.Name);
            builder.Append("\tvar ");
            builder.Append(this.Name);
        }

        public virtual void ToAddCode(StringBuilder builder)
        {
            builder.Append("\t");
            builder.Append(parent.Name);
            builder.Append(".controls.push(");
            builder.Append(name);
            builder.AppendLine(");");
        }

        public void WriteProperty(StringBuilder builder, string property)
        {
            builder.Append("\t");
            builder.Append(name);
            builder.Append(".");
            builder.Append(property);
            builder.Append(" = ");
        }

        public void WriteProperty(StringBuilder builder, string property, string value)
        {
            WriteProperty(builder, property);
            builder.Append(value);
            builder.AppendLine(";");
        }
    }

    internal class RadPanel : RadControl
    {
        private bool use_window;
        private Windowstyle style = null;
        private Color back_color = Color.Transparent;

        public RadPanel(Panel preview)
        {
            style = new Windowstyle(Application.StartupPath + "\\docs\\RadGui\\windowstyles\\RadGui\\basicwindow.rws");
            Preview = preview;
            preview.Padding = new Padding(4);
            Preview.Paint += new PaintEventHandler(Preview_Paint);
            CanResize = true;
        }

        public void  Preview_Paint(object sender, PaintEventArgs e)
        {
            if (use_window)
            {
                style.GeneratePreview(W, H);
                style.DrawWindow(e.Graphics);
            }
        }

        public Color BackColor
        {
            get { return back_color; }
            set
            {
                back_color = value; Preview.BackColor = value;
                if (value.Equals(Color.Transparent))
                {
                    ((Panel)Preview).BorderStyle = BorderStyle.FixedSingle;
                }
                else ((Panel)Preview).BorderStyle = BorderStyle.None;
            }
        }

        public bool UseWindow
        {
            get { return use_window; }
            set { use_window = value; Preview.Refresh(); }
        }

        public override void ToBaseCode(StringBuilder builder)
        {
            base.ToBaseCode(builder);
            builder.Append(" = new Panel(");
            builder.Append(Parent.Name);
            builder.Append(", ");
            builder.Append(this.X + Preview.Padding.Left); builder.Append(", ");
            builder.Append(this.Y + Preview.Padding.Top); builder.Append(", ");
            builder.Append(this.W - Preview.Padding.Horizontal); builder.Append(", ");
            builder.Append(this.H - Preview.Padding.Vertical); builder.AppendLine(");");
            if (!back_color.Equals(Color.Transparent))
            {
                WriteProperty(builder, "backColor");
                builder.Append("CreateColor(");
                StateEditor.ToSphereColorString(builder, this.back_color);
                builder.AppendLine(");");
            }
            if (use_window)
            {
                WriteProperty(builder, "useWindow", "true");
            }
            builder.AppendLine();
        }
    }

    /*internal class RadLabel : RadControl
    {
        private string text;
        private Sphere_Editor.EditorComponents.FontSet font;

        public RadLabel(Panel preview)
        {
            font = new EditorComponents.FontSet();
            font.LoadFromFile(Application.StartupPath + "\\docs\\RadGui\\fonts\\RadGui\\text.rfn");
            Preview = preview;
            preview.Paint += new PaintEventHandler(preview_Paint);
            preview.BackColor = Color.Transparent;
        }

        void preview_Paint(object sender, PaintEventArgs e)
        {
            string str = Text;
            Bitmap img = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(img);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            int x = 0;
            int zoom = font.Zoom;
            for (int i = 0; i < str.Length; ++i)
            {
                Bitmap charImg = font.Characters[(int)str[i]].Image;
                g.DrawImage(charImg, x, 0, charImg.Width * zoom, charImg.Height * zoom);
                x += charImg.Width * zoom;
            }
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.DrawImageUnscaled(img, 0, 0);
            g.Dispose();
            img.Dispose();
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                Preview.Text = value;
                W = font.GetStringWidth(value);
            }
        }

        public override void ToBaseCode(StringBuilder builder)
        {
            base.ToBaseCode(builder);
            builder.Append(" = new Label(");
            builder.Append(Parent.Name);
            builder.Append(", \"");
            builder.Append(text);
            builder.AppendLine("\");");
            if (X > 4) WriteProperty(builder, "xx", (X - 4).ToString());
            if (Y > 4) WriteProperty(builder, "yy", (Y - 4).ToString());
            builder.AppendLine();
        }
    }*/

    internal class RadImage : RadControl
    {
        private string filename = string.Empty;
        Bitmap image_preview = null;

        public RadImage(Panel preview)
        {
            Preview = preview;
            preview.Paint += new PaintEventHandler(preview_Paint);
            preview.BackColor = Color.Transparent;
        }

        private void preview_Paint(object sender, PaintEventArgs e)
        {
            if (image_preview != null)
            {
                e.Graphics.DrawImageUnscaled(image_preview, 0, 0);
            }
        }

        /// <summary>
        /// Relative path to the image in your /images folder.
        /// </summary>
        public string FileName
        {
            get { return filename; }
            set
            {
                filename = value;
                string path = Global.CurrentProject.RootPath + "/images/" + value;
                if (System.IO.File.Exists(path))
                {
                    image_preview = (Bitmap)Bitmap.FromFile(path);
                    W = image_preview.Width;
                    H = image_preview.Height;
                }
                else filename = string.Empty;
            }
        }

        public override void ToBaseCode(StringBuilder builder)
        {
            base.ToBaseCode(builder);
            builder.Append(" = new ImageContainer(");
            builder.Append(Parent.Name);
            builder.AppendLine(");");
            if (filename != string.Empty)
            {
                WriteProperty(builder, "graphic");
                builder.Append("LoadImage(\"");
                builder.Append(filename);
                builder.AppendLine("\");");
            }
            if (X > 4) WriteProperty(builder, "xx", (X - 4).ToString());
            if (Y > 4) WriteProperty(builder, "yy", (Y - 4).ToString());
            builder.AppendLine();
        }
    }
}