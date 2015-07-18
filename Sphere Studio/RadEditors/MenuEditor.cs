using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sphere.Core.Editor;
using Sphere.Plugins.EditShims;
using SphereStudio.Components;

namespace SphereStudio.RadEditors
{
    internal partial class StateEditor : EditorObject
    {
        private readonly ScriptEditShim _codeBox = new ScriptEditShim();
        private readonly RadPanel _radBasePanel;
        private RadControl _currentCtrl;
        private readonly List<RadControl> _controls = new List<RadControl>();

        public StateEditor()
        {
            InitializeComponent();
            _radBasePanel = new RadPanel(base_panel);
            _codeBox.Dock = DockStyle.Fill;
            CodePage.Controls.Add(_codeBox);
            _radBasePanel.Name = "base_panel";
            _currentCtrl = _radBasePanel;
            MainPropGrid.SelectedObject = _radBasePanel;
        }

        void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (_currentCtrl != null) _currentCtrl.Outlined = false;
            _currentCtrl = _radBasePanel;
            _currentCtrl.Outlined = true;
            MainPropGrid.SelectedObject = _radBasePanel;
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
            build.AppendLine(Global.CurrentGame.Author);
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
            build.Append(_radBasePanel.X); build.Append(", ");
            build.Append(_radBasePanel.Y); build.Append(", ");
            build.Append(_radBasePanel.W); build.Append(", ");
            build.Append(_radBasePanel.H); build.AppendLine(");");
            build.AppendLine();
            build.AppendLine("\tvar base_panel = this.createBasePanel();");
            if (!_radBasePanel.UseWindow) build.AppendLine("\tbase_panel.useWindow = false;");
            if (!_radBasePanel.BackColor.Equals(Color.Transparent))
            {
                _radBasePanel.WriteProperty(build, "backColor");
                build.Append("CreateColor(");
                ToSphereColorString(build, _radBasePanel.BackColor);
                build.AppendLine(");");
            }
            build.AppendLine();
            
            // extra info:
            //build.AppendLine("\t//Define your variables here:");
            //build.AppendLine("\n");

            // body info:
            build.AppendLine("\t//Component Creation Step:");
            foreach (RadControl c in _controls) c.ToBaseCode(build);

            // end info:
            build.AppendLine("\t//Component Addition Step:");
            foreach (RadControl c in _controls) c.ToAddCode(build);

            _codeBox.Text = build.ToString(0, build.Length);

            if (_codeBox.Text[_codeBox.Text.Length - 2] != '}')
            {
                _codeBox.Text += "}\n";
            }
        }

        static public void ToSphereColorString(StringBuilder builder, Color col)
        {
            builder.Append(col.R); builder.Append(", ");
            builder.Append(col.G); builder.Append(", ");
            builder.Append(col.B); builder.Append(", ");
            builder.Append(col.A);
        }

        private RadControl FindControl(string name)
        {
            return _controls.FirstOrDefault(t => t.Name == name);
        }

        private void Object_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            RadControl ctrl = FindControl(((Control)sender).Name);
            if (ctrl != null)
            {
                Rectangle rect = new Rectangle(1, 1, ((Control)sender).Width-1, ((Control)sender).Height-1);
                e.Graphics.DrawRectangle(ctrl.Outlined ? Pens.Red : Pens.Gray, rect);
            }
        }

        private bool _move;
        private int _mode;
        private Point _last = Point.Empty, _cur = Point.Empty;
        private void Object_MouseDown(object sender, MouseEventArgs e)
        {
            _move = true;
            Control netCtrl = (Control)sender;
            _last = netCtrl.Parent.PointToClient(Cursor.Position);
            _cur = netCtrl.Location;
            netCtrl.Cursor = Cursors.SizeAll;
            RadControl radCtrl = FindControl(((Control)sender).Name);
            if (radCtrl != null)
            {
                if (_currentCtrl != null) _currentCtrl.Outlined = false;
                _currentCtrl = radCtrl;
                _currentCtrl.Outlined = true;
                MainPropGrid.SelectedObject = radCtrl;
            }
        }

        private void Object_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (_move)
            {
                if (_mode == 0)
                {
                    Point mouse = ctrl.Parent.PointToClient(Cursor.Position);
                    ctrl.Location = new Point(_cur.X + mouse.X - _last.X, _cur.Y + mouse.Y - _last.Y);
                }
                else if (_currentCtrl.CanResize)
                {
                    if (_mode == 1) { ctrl.Width = e.X; ctrl.Height = e.Y; }
                    else if (_mode == 2) ctrl.Height = e.Y;
                    else if (_mode == 3) ctrl.Width = e.X;
                }
            }
            else
            {
                if (_currentCtrl.CanResize)
                {
                    bool yReach = (e.Y > ctrl.Height - 6);
                    bool xReach = (e.X > ctrl.Width - 6);
                    if (yReach && xReach) { ctrl.Cursor = Cursors.SizeNWSE; _mode = 1; }
                    else if (yReach) { ctrl.Cursor = Cursors.SizeNS; _mode = 2; }
                    else if (xReach) { ctrl.Cursor = Cursors.SizeWE; _mode = 3; }
                    else { ctrl.Cursor = Cursors.Default; _mode = 0; }
                }
                else { ctrl.Cursor = Cursors.Default; _mode = 0; }
            }
        }

        private void Object_MouseUp(object sender, MouseEventArgs e)
        {
            _move = false;
            Control netCtrl = (Control)sender;
            RadControl radCtrl = FindControl(netCtrl.Name);
            if (radCtrl != null)
            {
                radCtrl.X = netCtrl.Location.X;
                radCtrl.Y = netCtrl.Location.Y;
                radCtrl.W = netCtrl.Width;
                radCtrl.H = netCtrl.Height;
            }
            netCtrl.Cursor = Cursors.Default;
        }

        private void PanelButton_Click(object sender, EventArgs e)
        {
            Panel newPanel = new Panel();
            RadPanel radPanel = new RadPanel(newPanel) {Name = "control_" + _controls.Count};
            newPanel.MouseDown += Object_MouseDown;
            newPanel.MouseMove += Object_MouseMove;
            newPanel.MouseUp += Object_MouseUp;
            newPanel.Paint += Object_Paint;
            radPanel.X = radPanel.Y = 3;
            radPanel.W = 64; radPanel.H = 32;
            if (_currentCtrl is RadPanel)
            {
                radPanel.Parent = _currentCtrl;
                _currentCtrl.Preview.Controls.Add(newPanel);
            }
            else
            {
                radPanel.Parent = _radBasePanel;
                base_panel.Controls.Add(newPanel);
            }
            _controls.Add(radPanel);
        }

        private void LabelButton_Click(object sender, EventArgs e)
        {
            /*Panel new_panel = new Panel();
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
            controls.Add(rad_label);*/
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            Panel newPanel = new Panel();
            RadImage radImage = new RadImage(newPanel) {Name = "control_" + _controls.Count};
            newPanel.MouseDown += Object_MouseDown;
            newPanel.MouseMove += Object_MouseMove;
            newPanel.MouseUp += Object_MouseUp;
            newPanel.Paint += Object_Paint;

            radImage.X = radImage.Y = 3;
            radImage.W = 32; radImage.H = 32;
            
            if (_currentCtrl is RadPanel)
            {
                radImage.Parent = _currentCtrl;
                _currentCtrl.Preview.Controls.Add(newPanel);
            }
            else
            {
                radImage.Parent = _radBasePanel;
                base_panel.Controls.Add(newPanel);
            }
            _controls.Add(radImage);
        }
    }
}
