using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Sphere.Core.Editor;
using Sphere.Plugins;

namespace SphereStudio.Plugins
{
    public partial class Scripter : EditorObject, IScriptEditor, IStyleable
    {
        readonly Encoding ISO_8859_1 = Encoding.GetEncoding("iso-8859-1");
        private readonly FastColoredTextBox _textbox;

        public Scripter()
        {
            InitializeComponent();
            CanDirty = false;
            _textbox = new FastColoredTextBox {Dock = DockStyle.Fill};
            _textbox.TextChangedDelayed += _textbox_TextChangedDelayed;
            Controls.Add(_textbox);
            UpdateStyle();
        }

        public bool CanDirty { get; set; }

        void _textbox_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            if (CanDirty) MakeDirty();
        }

        public void UpdateStyle()
        {
            _textbox.TabLength = PluginManager.IDE.EditorSettings.GetInt("script-spaces", 2);
            _textbox.AcceptsTab = PluginManager.IDE.EditorSettings.GetBool("script-tabs", _textbox.AcceptsTab);
            _textbox.ShowFoldingLines = PluginManager.IDE.EditorSettings.GetBool("script-fold", true);
            
            _textbox.CurrentLineColor = PluginManager.IDE.EditorSettings.GetBool("script-hiline", true) ? Color.Yellow : Color.White;

            string fontstring = PluginManager.IDE.EditorSettings.GetString("script-font");
            if (String.IsNullOrEmpty(fontstring)) return;

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
            Font f = (Font)converter.ConvertFromString(fontstring);
            if (f != null) _textbox.Font = f;
        }

        public override void LoadFile(string filename)
        {
            base.LoadFile(filename);

            _textbox.Language = filename.EndsWith(".js") ? Language.JS : Language.Custom;

            using (StreamReader reader = new StreamReader(filename))
            {
                _textbox.Text = reader.ReadToEnd();
                _textbox.ClearUndo();
                Parent.Text = Path.GetFileName(FileName);
            }
        }

        public override void Save()
        {
            if (!IsSaved()) SaveAs();
            else
            {
                using (StreamWriter writer = new StreamWriter(FileName, false, ISO_8859_1))
                {
                    writer.Write(_textbox.Text);
                    Parent.Text = Path.GetFileName(FileName);
                }
            }
        }

        public override void SaveAs()
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.Filter = @"Sphere Script Files (.js)|*.js";

                if (PluginManager.IDE.CurrentGame != null)
                    diag.InitialDirectory = PluginManager.IDE.CurrentGame.RootPath + "\\scripts";

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    FileName = diag.FileName;
                    Save();
                }
            }
        }

        public override void SelectAll()
        {
            _textbox.SelectAll();
        }

        public override void Copy()
        {
            _textbox.Copy();
        }

        public override void Paste()
        {
            _textbox.Paste();
        }

        public override void Cut()
        {
            _textbox.Cut();
        }

        public override void Undo()
        {
            _textbox.Undo();
        }

        public override void Redo()
        {
            _textbox.Redo();
        }

        public override string Text
        {
            get { return _textbox.Text; }
            set
            {
                _textbox.Text = value;
                _textbox.ClearUndo();
            }
        }
    }
}
