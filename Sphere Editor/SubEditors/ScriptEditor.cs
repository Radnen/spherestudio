using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;
using Sphere.Core.Editor;

namespace Sphere_Editor.SubEditors
{
    public partial class ScriptEditor : EditorObject
    {
        Scintilla _codeBox = new Scintilla();
        readonly Encoding ISO_8859_1 = Encoding.GetEncoding("iso-8859-1");

        public ScriptEditor()
        {
            _codeBox.ConfigurationManager.CustomLocation = Application.StartupPath + "\\SphereLexer.xml";
            _codeBox.ConfigurationManager.Language = "js";
            _codeBox.AutoComplete.SingleLineAccept = false;
            _codeBox.AutoComplete.FillUpCharacters = "";
            _codeBox.AutoComplete.StopCharacters = "(";
            _codeBox.AutoComplete.ListSeparator = ';';
            _codeBox.AutoComplete.IsCaseSensitive = false;
            _codeBox.SupressControlCharacters = true;
            
            _codeBox.Folding.MarkerScheme = FoldMarkerScheme.Arrow;
            _codeBox.Margins[0].Width = 36;

            bool fold = Global.CurrentEditor.GetBool("script-fold", true);
            if (fold) SetFold(true);

            _codeBox.Indentation.SmartIndentType = SmartIndent.CPP;
            _codeBox.Styles.BraceLight.ForeColor = Color.Black;
            _codeBox.Styles.BraceLight.BackColor = Color.LightGray;

            _codeBox.Caret.CurrentLineBackgroundColor = Color.LightGoldenrodYellow;

            _codeBox.CharAdded += CodeBox_CharAdded;
            _codeBox.TextDeleted += code_box_TextChanged;
            _codeBox.TextInserted += code_box_TextChanged;
            _codeBox.Dock = DockStyle.Fill;

            _codeBox.Commands.AddBinding(Keys.D, Keys.Control, BindableCommand.LineDuplicate);
            Controls.Add(_codeBox);

            UpdateStyle();
        }

        /// <summary>
        /// Styles the code box per the options specified in the editor settings.
        /// </summary>
        public void UpdateStyle()
        {
            _codeBox.Indentation.TabWidth = Global.CurrentEditor.GetInt("script-spaces", 2);
            _codeBox.Indentation.UseTabs = Global.CurrentEditor.GetBool("script-tabs", true);
            _codeBox.Caret.HighlightCurrentLine = Global.CurrentEditor.GetBool("script-hiline", true);
            _codeBox.IsBraceMatching = Global.CurrentEditor.GetBool("script-hibraces", true);

            string fontstring = Global.CurrentEditor.GetString("script-font");
            if (!String.IsNullOrEmpty(fontstring))
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                SetFont((Font)converter.ConvertFromString(fontstring));
            }
        }

        void code_box_TextChanged(object sender, EventArgs e)
        {
            MakeDirty();
        }

        public override void CreateNew()
        {
            if (Global.CurrentEditor.UseScriptUpdate)
            {
                string author = (Global.CurrentProject != null) ? Global.CurrentProject.Author : "Unnamed";
                const string header = "/**\n* Script: Untitled.js\n* Written by: {0}\n* Updated: {1}\n**/";
                _codeBox.Text = string.Format(header, author, DateTime.Today.ToShortDateString());
                _codeBox.UndoRedo.EmptyUndoBuffer();
            }
        }

        private void SetFont(Font font)
        {
            for (int i = 0; i < 128; ++i)
                _codeBox.Styles[i].Font = font;
            SetMarginSize(font);
        }

        private void SetMarginSize(Font font)
        {
            _codeBox.Margins[0].Width = 25 + (int)(Math.Log10(_codeBox.Lines.Count) * font.SizeInPoints);
        }

        private void SetFold(bool fold)
        {
            _codeBox.Margins[0].IsFoldMargin = fold;
            _codeBox.Margins[0].IsClickable = fold;
            _codeBox.Folding.IsEnabled = fold;
        }

        public override void LoadFile(string filename)
        {
            FileName = filename;
            try
            {
                using (StreamReader fileReader = new StreamReader(File.OpenRead(filename), ISO_8859_1))
                {
                    _codeBox.UndoRedo.IsUndoEnabled = false;
                    _codeBox.Text = fileReader.ReadToEnd();
                    _codeBox.UndoRedo.IsUndoEnabled = true;
                    if (!Global.IsScript(ref filename)) CodeBox.ConfigurationManager.Language = "default";
                    Parent.Text = Path.GetFileName(filename);
                    SetMarginSize(_codeBox.Styles[0].Font);
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
                using (StreamWriter writer = new StreamWriter(FileName, false, ISO_8859_1))
                {
                    if (Global.CurrentEditor.UseScriptUpdate)
                    {
                        _codeBox.UndoRedo.IsUndoEnabled = false;
                        if (_codeBox.Lines.Count > 1 && _codeBox.Lines[1].Text[0] == '*')
                            _codeBox.Lines[1].Text = "* Script: " + Path.GetFileName(FileName);
                        if (_codeBox.Lines.Count > 2 && _codeBox.Lines[2].Text[0] == '*')
                            _codeBox.Lines[2].Text = "* Written by: " + Global.CurrentProject.Author;
                        if (_codeBox.Lines.Count > 3 && _codeBox.Lines[3].Text[0] == '*')
                            _codeBox.Lines[3].Text = "* Updated: " + DateTime.Today.ToShortDateString();
                        _codeBox.UndoRedo.IsUndoEnabled = true;
                    }

                    writer.Write(_codeBox.Text);
                }
                Parent.Text = Path.GetFileName(FileName);
            }
        }

        public override void SaveAs()
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.Filter = @"Sphere Script Files (.js)|*.js";

                if (Global.CurrentProject != null)
                    diag.InitialDirectory = Global.CurrentProject.RootPath + "\\scripts";

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

        [Localizable(false)]
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
            if (char.IsLetter(e.Ch))
            {
                string word = _codeBox.GetWordFromPosition(_codeBox.CurrentPos).ToLower();
                List<string> filter = (from s in Global.functions where s.ToLower().Contains(word) select s.Replace(";", "")).ToList();

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
