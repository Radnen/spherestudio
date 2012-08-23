using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sphere_Editor.SubEditors;

namespace Sphere_Editor.RadEditors
{
    public partial class StateEditor : EditorObject
    {
        private ScriptEditor code_box = new ScriptEditor();
        private RadPanel rad_base_panel;
        private RadControl current_ctrl;
        private List<RadControl> controls = new List<RadControl>();

        public StateEditor()
        {
            InitializeComponent();
            rad_base_panel = new RadPanel(base_panel);
            code_box.Dock = DockStyle.Fill;
            CodePage.Controls.Add(code_box);
            rad_base_panel.Name = "base_panel";
            current_ctrl = rad_base_panel;
            MainPropGrid.SelectedObject = rad_base_panel;
        }

        void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (current_ctrl != null) current_ctrl.Outlined = false;
            current_ctrl = rad_base_panel;
            current_ctrl.Outlined = true;
            MainPropGrid.SelectedObject = rad_base_panel;
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex == 1) CompileInterfaceToJS();
        }

        private void CompileInterfaceToJS()
        {
            // header info:
            StringBuilder build = new StringBuilder();
            build.AppendLine("/**\n* Script: Untitled.js");
            build.Append("* Written by: ");
            build.AppendLine(Global.CurrentProject.Author);
            build.Append("* Updated: ");
            build.AppendLine(DateTime.Today.ToShortDateString());
            build.AppendLine("**/");
            build.AppendLine();
            build.Append("function ");
            build.Append(NameTextBox.Text);
            build.AppendLine("(name)");
            build.AppendLine("{");
            build.AppendLine("\tthis.inherit = GUIState;");
            build.Append("\tthis.inherit(name"); build.Append(", ");
            build.Append(rad_base_panel.X); build.Append(", ");
            build.Append(rad_base_panel.Y); build.Append(", ");
            build.Append(rad_base_panel.W); build.Append(", ");
            build.Append(rad_base_panel.H); build.AppendLine(");");
            build.AppendLine();
            build.AppendLine("\tvar base_panel = this.createBasePanel();");
            if (!rad_base_panel.UseWindow) build.AppendLine("\tbase_panel.useWindow = false;");
            if (!rad_base_panel.BackColor.Equals(Color.Transparent))
            {
                rad_base_panel.WriteProperty(build, "backColor");
                build.Append("CreateColor(");
                StateEditor.ToSphereColorString(build, rad_base_panel.BackColor);
                build.AppendLine(");");
            }
            build.AppendLine();
            
            // extra info:
            //build.AppendLine("\t//Define your variables here:");
            //build.AppendLine("\n");

            // body info:
            build.AppendLine("\t//Component Creation Step:");
            foreach (RadControl c in controls) c.ToBaseCode(build);

            // end info:
            build.AppendLine("\t//Component Addition Step:");
            foreach (RadControl c in controls) c.ToAddCode(build);

            code_box.Text = build.ToString(0, build.Length);

            if (code_box.Text[code_box.Text.Length - 2] != '}')
            {
                code_box.Text += "}\n";
            }
        }

        static public void ToSphereColorString(StringBuilder builder, Color col)
        {
            builder.Append(col.R); builder.Append(", ");
            builder.Append(col.G); builder.Append(", ");
            builder.Append(col.B); builder.Append(", ");
            builder.Append(col.A);
        }

        private RadControl FindControl(string Name)
        {
            for (int i = 0; i < controls.Count; ++i)
            {
                if (controls[i].Name == Name) return controls[i];
            }
            return null;
        }

        private void Object_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            RadControl ctrl = FindControl(((Control)sender).Name);
            if (ctrl != null)
            {
                Rectangle rect = new Rectangle(1, 1, ((Control)sender).Width-1, ((Control)sender).Height-1);
                if (ctrl.Outlined) e.Graphics.DrawRectangle(Pens.Red, rect);
                else e.Graphics.DrawRectangle(Pens.Gray, rect);
            }
        }

        private bool move = false;
        private int mode = 0;
        private Point last = Point.Empty, cur = Point.Empty;
        private void Object_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            Control net_ctrl = (Control)sender;
            last = net_ctrl.Parent.PointToClient(Cursor.Position);
            cur = net_ctrl.Location;
            net_ctrl.Cursor = Cursors.SizeAll;
            RadControl rad_ctrl = FindControl(((Control)sender).Name);
            if (rad_ctrl != null)
            {
                if (current_ctrl != null) current_ctrl.Outlined = false;
                current_ctrl = rad_ctrl;
                current_ctrl.Outlined = true;
                MainPropGrid.SelectedObject = rad_ctrl;
            }
        }

        private void Object_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (move)
            {
                if (mode == 0)
                {
                    Point mouse = ctrl.Parent.PointToClient(Cursor.Position);
                    ctrl.Location = new Point(cur.X + mouse.X - last.X, cur.Y + mouse.Y - last.Y);
                }
                else if (current_ctrl.CanResize)
                {
                    if (mode == 1) { ctrl.Width = e.X; ctrl.Height = e.Y; }
                    else if (mode == 2) ctrl.Height = e.Y;
                    else if (mode == 3) ctrl.Width = e.X;
                }
            }
            else
            {
                if (current_ctrl.CanResize)
                {
                    bool y_reach = (e.Y > ctrl.Height - 6);
                    bool x_reach = (e.X > ctrl.Width - 6);
                    if (y_reach && x_reach) { ctrl.Cursor = Cursors.SizeNWSE; mode = 1; }
                    else if (y_reach) { ctrl.Cursor = Cursors.SizeNS; mode = 2; }
                    else if (x_reach) { ctrl.Cursor = Cursors.SizeWE; mode = 3; }
                    else { ctrl.Cursor = Cursors.Default; mode = 0; }
                }
                else { ctrl.Cursor = Cursors.Default; mode = 0; }
            }
        }

        private void Object_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
            Control net_ctrl = (Control)sender;
            RadControl rad_ctrl = FindControl(net_ctrl.Name);
            if (rad_ctrl != null)
            {
                rad_ctrl.X = net_ctrl.Location.X;
                rad_ctrl.Y = net_ctrl.Location.Y;
                rad_ctrl.W = net_ctrl.Width;
                rad_ctrl.H = net_ctrl.Height;
            }
            net_ctrl.Cursor = Cursors.Default;
        }

        private void PanelButton_Click(object sender, EventArgs e)
        {
            Panel new_panel = new Panel();
            RadPanel rad_panel = new RadPanel(new_panel);
            rad_panel.Name = "control_" + controls.Count;
            new_panel.MouseDown += new MouseEventHandler(Object_MouseDown);
            new_panel.MouseMove += new MouseEventHandler(Object_MouseMove);
            new_panel.MouseUp += new MouseEventHandler(Object_MouseUp);
            new_panel.Paint += new PaintEventHandler(Object_Paint);
            rad_panel.X = rad_panel.Y = 3;
            rad_panel.W = 64; rad_panel.H = 32;
            if (current_ctrl is RadPanel)
            {
                rad_panel.Parent = current_ctrl;
                current_ctrl.Preview.Controls.Add(new_panel);
            }
            else
            {
                rad_panel.Parent = rad_base_panel;
                base_panel.Controls.Add(new_panel);
            }
            controls.Add(rad_panel);
        }

        private void LabelButton_Click(object sender, EventArgs e)
        {
            Panel new_panel = new Panel();
            RadLabel rad_label = new RadLabel(new_panel);
            rad_label.Name = "control_" + controls.Count;
            new_panel.MouseDown += new MouseEventHandler(Object_MouseDown);
            new_panel.MouseMove += new MouseEventHandler(Object_MouseMove);
            new_panel.MouseUp += new MouseEventHandler(Object_MouseUp);
            new_panel.Paint += new PaintEventHandler(Object_Paint);
            rad_label.H = 16;
            rad_label.Text = rad_label.Name;
            if (current_ctrl is RadPanel)
            {
                rad_label.Parent = current_ctrl;
                current_ctrl.Preview.Controls.Add(new_panel);
            }
            else
            {
                rad_label.Parent = rad_base_panel;
                base_panel.Controls.Add(new_panel);
            }
            controls.Add(rad_label);
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            Panel new_panel = new Panel();
            RadImage rad_image = new RadImage(new_panel);
            rad_image.Name = "control_" + controls.Count;
            new_panel.MouseDown += new MouseEventHandler(Object_MouseDown);
            new_panel.MouseMove += new MouseEventHandler(Object_MouseMove);
            new_panel.MouseUp += new MouseEventHandler(Object_MouseUp);
            new_panel.Paint += new PaintEventHandler(Object_Paint);

            rad_image.X = rad_image.Y = 3;
            rad_image.W = 32; rad_image.H = 32;
            
            if (current_ctrl is RadPanel)
            {
                rad_image.Parent = current_ctrl;
                current_ctrl.Preview.Controls.Add(new_panel);
            }
            else
            {
                rad_image.Parent = rad_base_panel;
                base_panel.Controls.Add(new_panel);
            }
            controls.Add(rad_image);
        }
    }
}
