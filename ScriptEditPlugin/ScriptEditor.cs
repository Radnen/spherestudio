using ScintillaNET;
using Sphere.Core.Editor;
using Sphere.Plugins;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SphereStudio.Plugins
{
    internal partial class ScriptEditor : EditorObject, IScriptEditor
    {
        private Scintilla _codeBox = new Scintilla();

        // We should technically be using ISO-8859-1 or Windows-1252 for compatibility with the old editor.
        // However, UTF-8 works fine in Sphere and some JS engines (e.g. Duktape) won't accept
        // 8-bit encodings if they contain extended characters, so we'll use UTF-8 and compromise
        // by not including a byte order mark.
        private readonly Encoding UTF_8_NOBOM = new UTF8Encoding(false);
        private readonly Encoding ISO_8859_1 = Encoding.GetEncoding("iso-8859-1");

        private bool _autocomplete;

        public ScriptEditor()
        {
            CanDirty = false;
            
            string configPath = Application.StartupPath + "\\SphereLexer.xml";
            if (File.Exists(configPath))
                _codeBox.ConfigurationManager.CustomLocation = configPath;

            _codeBox.Encoding = Encoding.UTF8;
            _codeBox.ConfigurationManager.Language = "js";
            _codeBox.AutoComplete.SingleLineAccept = false;
            _codeBox.AutoComplete.FillUpCharacters = "";
            _codeBox.AutoComplete.StopCharacters = "(";
            _codeBox.AutoComplete.ListSeparator = ';';
            _codeBox.AutoComplete.IsCaseSensitive = false;
            _codeBox.SupressControlCharacters = true;

            _codeBox.Folding.MarkerScheme = FoldMarkerScheme.Custom;
            _codeBox.Folding.Flags = FoldFlag.LineAfterContracted;
            _codeBox.Folding.UseCompactFolding = false;
            _codeBox.Margins.Margin1.IsClickable = true;
            _codeBox.Margins.Margin1.IsFoldMargin = true;
            _codeBox.Styles.LineNumber.BackColor = Color.FromArgb(235, 235, 255);
            _codeBox.Margins.FoldMarginColor = Color.FromArgb(235, 235, 255);

            _codeBox.Indentation.SmartIndentType = SmartIndent.CPP;
            _codeBox.Styles.BraceLight.ForeColor = Color.Black;
            _codeBox.Styles.BraceLight.BackColor = Color.LightGray;

            _codeBox.Caret.CurrentLineBackgroundColor = Color.LightGoldenrodYellow;

            _codeBox.CharAdded += CodeBox_CharAdded;
            _codeBox.TextDeleted += code_box_TextChanged;
            _codeBox.TextInserted += code_box_TextChanged;
            _codeBox.Dock = DockStyle.Fill;

            Controls.Add(_codeBox);

            UpdateStyle();
            OnRestyle += ScriptEditor_OnRestyle;
        }

        void ScriptEditor_OnRestyle(object sender, EventArgs e)
        {
            UpdateStyle();
        }

        public bool CanDirty { get; set; }

        /// <summary>
        /// Styles the code box per the options specified in the editor settings.
        /// </summary>
        public void UpdateStyle()
        {
            _codeBox.Indentation.TabWidth = PluginManager.IDE.Settings.GetInteger("script-spaces", 2);
            _codeBox.Indentation.UseTabs = PluginManager.IDE.Settings.GetBoolean("script-tabs", true);
            _codeBox.Caret.HighlightCurrentLine = PluginManager.IDE.Settings.GetBoolean("script-hiline", true);
            _codeBox.IsBraceMatching = PluginManager.IDE.Settings.GetBoolean("script-hibraces", true);

            _autocomplete = PluginManager.IDE.Settings.GetBoolean("script-autocomplete", true);

            bool fold = PluginManager.IDE.Settings.GetBoolean("script-fold", true);
            _codeBox.Margins.Margin1.Width = fold ? 16 : 0;

            /*string fontstring = PluginManager.IDE.EditorSettings.GetString("script-font");
            if (!String.IsNullOrEmpty(fontstring))
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                SetFont((Font)converter.ConvertFromString(fontstring));
            }*/
        }

        void code_box_TextChanged(object sender, EventArgs e)
        {
            if (CanDirty) MakeDirty();
            SetMarginSize(_codeBox.Styles[StylesCommon.LineNumber].Font);
        }

        public override void CreateNew()
        {
            if (PluginManager.IDE.Settings.GetBoolean("autoScriptHeader", false))
            {
                string author = (PluginManager.IDE.CurrentGame != null) ? PluginManager.IDE.CurrentGame.Author : "Unnamed";
                const string header = "/**\n* Script: Untitled.js\n* Written by: {0}\n* Updated: {1}\n**/";
                _codeBox.Text = string.Format(header, author, DateTime.Today.ToShortDateString());
                _codeBox.UndoRedo.EmptyUndoBuffer();
            }
        }

        private void SetMarginSize(Font font)
        {
            int spaces = (int)Math.Log10(_codeBox.Lines.Count) + 1;
            _codeBox.Margins[0].Width = 2 + spaces * (int)font.SizeInPoints;
        }

        public override void LoadFile(string filename)
        {
            FileName = filename;
            try
            {
                using (StreamReader fileReader = new StreamReader(File.OpenRead(filename), true))
                {
                    _codeBox.UndoRedo.IsUndoEnabled = false;
                    _codeBox.Text = fileReader.ReadToEnd();
                    _codeBox.UndoRedo.IsUndoEnabled = true;
                    
                    if (Path.GetExtension(filename) != ".js")
                        CodeBox.ConfigurationManager.Language = "default";
                    
                    SetTabText(Path.GetFileName(filename));
                    SetMarginSize(_codeBox.Styles[StylesCommon.LineNumber].Font);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(@"File: " + filename + @" not found!", @"File Not Found");
                Parent.Controls.Remove(this);
            }
        }

        public override void Save()
        {
            if (!IsSaved()) SaveAs();
            else
            {
                using (StreamWriter writer = new StreamWriter(FileName, false, UTF_8_NOBOM))
                {
                    if (PluginManager.IDE.Settings.GetBoolean("autoScriptUpdate", false))
                    {
                        _codeBox.UndoRedo.IsUndoEnabled = false;
                        if (_codeBox.Lines.Count > 1 && _codeBox.Lines[1].Text[0] == '*')
                            _codeBox.Lines[1].Text = "* Script: " + Path.GetFileName(FileName);
                        if (_codeBox.Lines.Count > 2 && _codeBox.Lines[2].Text[0] == '*')
                            _codeBox.Lines[2].Text = "* Written by: " + PluginManager.IDE.CurrentGame.Author;
                        if (_codeBox.Lines.Count > 3 && _codeBox.Lines[3].Text[0] == '*')
                            _codeBox.Lines[3].Text = "* Updated: " + DateTime.Today.ToShortDateString();
                        _codeBox.UndoRedo.IsUndoEnabled = true;
                    }

                    writer.Write(_codeBox.Text);
                }
                SetTabText(Path.GetFileName(FileName));
            }
        }

        public override void SaveAs()
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.Filter = @"JavaScript (.js)|*.js|CoffeeScript (.coffee)|*.coffee";
                diag.DefaultExt = "js";

                if (PluginManager.IDE.CurrentGame != null)
                    diag.InitialDirectory = PluginManager.IDE.CurrentGame.RootPath + "\\scripts";

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    FileName = diag.FileName;
                    Save();
                }
            }
        }

        public override void Copy()
        {
            _codeBox.Clipboard.Copy();
        }

        public override void Paste()
        {
            if (_codeBox.Clipboard.CanPaste)
                _codeBox.Clipboard.Paste();
        }

        public override void Cut()
        {
            _codeBox.Clipboard.Cut();
        }

        public override void SelectAll()
        {
            _codeBox.Selection.SelectAll();
        }

        public override void Undo()
        {
            if (_codeBox.UndoRedo.CanUndo) _codeBox.UndoRedo.Undo();
        }

        public override void Redo()
        {
            if (_codeBox.UndoRedo.CanRedo) _codeBox.UndoRedo.Redo();
        }

        public override string Text
        {
            get { return _codeBox.Text; }
            set
            {
                _codeBox.Text = value;
                _codeBox.UndoRedo.EmptyUndoBuffer();
            }
        }

        public void CodeBox_CharAdded(object sender, CharAddedEventArgs e)
        {
            if (!_autocomplete) return;

            if (char.IsLetter(e.Ch))
            {
                string word = _codeBox.GetWordFromPosition(_codeBox.CurrentPos).ToLower();
                List<string> filter = (from s in ScriptEditPlugin.Functions where s.ToLower().Contains(word) select s.Replace(";", "")).ToList();

                if (filter.Count != 0)
                {
                    _codeBox.AutoComplete.List = filter;
                    _codeBox.AutoComplete.Show(word.Length);
                }
            }
        }

        public Scintilla CodeBox
        {
            get { return _codeBox; }
            set { _codeBox = value; }
        }
    }
}
