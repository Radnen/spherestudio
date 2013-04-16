using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;
using System.Drawing;
using System.ComponentModel;

namespace Sphere_Editor.SubEditors
{
    public partial class ScriptEditor : EditorObject
    {
        private string filename = null;
        Scintilla code_box = new Scintilla();
        readonly Encoding ISO_8859_1 = System.Text.Encoding.GetEncoding("iso-8859-1");

        public ScriptEditor()
        {
            code_box.ConfigurationManager.CustomLocation = Application.StartupPath + "\\SphereLexer.xml";
            code_box.ConfigurationManager.Language = "js";
            code_box.AutoComplete.SingleLineAccept = false;
            code_box.AutoComplete.FillUpCharacters = "";
            code_box.AutoComplete.StopCharacters = "(";
            code_box.AutoComplete.ListSeparator = ';';
            code_box.AutoComplete.IsCaseSensitive = false;
            code_box.SupressControlCharacters = true;
            
            code_box.Folding.MarkerScheme = FoldMarkerScheme.Arrow;
            code_box.Margins[0].Width = 36;

            bool fold = Global.CurrentEditor.GetBool("script-fold", true);
            if (fold) SetFold(fold);

            code_box.Indentation.SmartIndentType = SmartIndent.CPP;
            code_box.Styles.BraceLight.ForeColor = Color.Black;
            code_box.Styles.BraceLight.BackColor = Color.LightGray;

            code_box.Caret.CurrentLineBackgroundColor = Color.LightGoldenrodYellow;

            code_box.CharAdded += new EventHandler<CharAddedEventArgs>(CodeBox_CharAdded);
            code_box.TextDeleted += new EventHandler<TextModifiedEventArgs>(code_box_TextChanged);
            code_box.TextInserted += new EventHandler<TextModifiedEventArgs>(code_box_TextChanged);
            code_box.Dock = DockStyle.Fill;

            code_box.Commands.AddBinding(Keys.D, Keys.Control, BindableCommand.LineDuplicate);
            Controls.Add(code_box);

            UpdateStyle();
        }

        /// <summary>
        /// Styles the code box per the options specified in the editor settings.
        /// </summary>
        public void UpdateStyle()
        {
            code_box.Indentation.TabWidth = Global.CurrentEditor.GetInt("script-spaces", 2);
            code_box.Indentation.UseTabs = Global.CurrentEditor.GetBool("script-tabs", true);
            code_box.Caret.HighlightCurrentLine = Global.CurrentEditor.GetBool("script-hiline", true);
            code_box.IsBraceMatching = Global.CurrentEditor.GetBool("script-hibraces", true);

            string fontstring = Global.CurrentEditor.GetString("script-font");
            if (!String.IsNullOrEmpty(fontstring))
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                SetFont((Font)converter.ConvertFromString(fontstring));
            }
        }

        void code_box_TextChanged(object sender, EventArgs e)
        {
            if (Parent != null && !Parent.Text.EndsWith("*")) Parent.Text += "*";
        }

        public override void CreateNew()
        {
            if (Global.CurrentEditor.UseScriptUpdate)
            {
                string author = (Global.CurrentProject != null) ? Global.CurrentProject.Author : "Unnamed";
                string header = "/**\n* Script: Untitled.js\n* Written by: {0}\n* Updated: {1}\n**/";
                code_box.Text = string.Format(header, author, DateTime.Today.ToShortDateString());
                code_box.UndoRedo.EmptyUndoBuffer();
            }
        }

        private void SetFont(Font font)
        {
            for (int i = 0; i < 128; ++i)
                code_box.Styles[i].Font = font;
            SetMarginSize(font);
        }

        private void SetMarginSize(Font font)
        {
            code_box.Margins[0].Width = 25 + (int)(Math.Log10(code_box.Lines.Count) * font.SizeInPoints);
        }

        private void SetFold(bool fold)
        {
            code_box.Margins[0].IsFoldMargin = fold;
            code_box.Margins[0].IsClickable = fold;
            code_box.Folding.IsEnabled = fold;
        }

        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        public override void LoadFile(string filename)
        {
            this.filename = filename;
            try
            {
                using (StreamReader FileReader = new StreamReader(File.OpenRead(filename), ISO_8859_1))
                {
                    code_box.UndoRedo.IsUndoEnabled = false;
                    code_box.Text = FileReader.ReadToEnd();
                    code_box.UndoRedo.IsUndoEnabled = true;
                    if (!Global.IsScript(ref filename)) CodeBox.ConfigurationManager.Language = "default";
                    Parent.Text = Path.GetFileName(filename);
                    SetMarginSize(code_box.Styles[0].Font);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File: " + filename + " not found!", "File Not Found");
                Parent.Controls.Remove(this);
            }
        }

        public override void Save()
        {
            if (this.filename == null) SaveAs();
            else
            {
                using (StreamWriter writer = new StreamWriter(filename, false, ISO_8859_1))
                {
                    if (Global.CurrentEditor.UseScriptUpdate)
                    {
                        code_box.UndoRedo.IsUndoEnabled = false;
                        if (code_box.Lines.Count > 1 && code_box.Lines[1].Text[0] == '*')
                            code_box.Lines[1].Text = "* Script: " + Path.GetFileName(filename);
                        if (code_box.Lines.Count > 2 && code_box.Lines[2].Text[0] == '*')
                            code_box.Lines[2].Text = "* Written by: " + Global.CurrentProject.Author;
                        if (code_box.Lines.Count > 3 && code_box.Lines[3].Text[0] == '*')
                            code_box.Lines[3].Text = "* Updated: " + DateTime.Today.ToShortDateString();
                        code_box.UndoRedo.IsUndoEnabled = true;
                    }

                    writer.Write(code_box.Text);
                }
                Parent.Text = Path.GetFileName(filename);
            }
        }

        public override void SaveAs()
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.Filter = "Sphere Script Files (.js)|*.js";

                if (Global.CurrentProject != null)
                    diag.InitialDirectory = Global.CurrentProject.RootPath + "\\scripts";

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    this.filename = diag.FileName;
                    Save();
                }
            }
        }

        public override void Copy()
        {
            code_box.Clipboard.Copy();
        }

        public override void Paste()
        {
            if (code_box.Clipboard.CanPaste)
                code_box.Clipboard.Paste();
        }

        public override void Cut()
        {
            code_box.Clipboard.Cut();
        }

        public override void SelectAll()
        {
            code_box.Selection.SelectAll();
        }

        public override void Undo()
        {
            if (code_box.UndoRedo.CanUndo) code_box.UndoRedo.Undo();
        }

        public override void Redo()
        {
            if (code_box.UndoRedo.CanRedo) code_box.UndoRedo.Redo();
        }

        public override string Text
        {
            get { return code_box.Text; }
            set
            {
                code_box.Text = value;
                code_box.UndoRedo.EmptyUndoBuffer();
            }
        }

        public void CodeBox_CharAdded(object sender, CharAddedEventArgs e)
        {
            if (!Global.CurrentEditor.ShowAutoComplete) return;

            if (char.IsLetter(e.Ch))
            {
                string word = code_box.GetWordFromPosition(code_box.CurrentPos).ToLower();
                List<string> filter = new List<string>();

                foreach (string s in Global.functions)
                {
                    if (s.ToLower().Contains(word)) filter.Add(s.Replace(";", ""));
                }

                if (filter.Count != 0)
                {
                    code_box.AutoComplete.List = filter;
                    code_box.AutoComplete.Show(word.Length);
                }
            }
        }

        public Scintilla CodeBox
        {
            get { return code_box; }
            set { code_box = value; }
        }
    }
}
