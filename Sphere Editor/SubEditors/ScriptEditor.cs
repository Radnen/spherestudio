using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ScintillaNET;

namespace Sphere_Editor.SubEditors
{
    public partial class ScriptEditor : EditorObject
    {
        private string filename = null;
        Scintilla code_box = new Scintilla();

        public ScriptEditor()
        {
            code_box.ConfigurationManager.CustomLocation = Application.StartupPath + "\\SphereLexer.xml";
            code_box.ConfigurationManager.Language = "js";
            code_box.AutoComplete.SingleLineAccept = false;
            code_box.AutoComplete.FillUpCharacters = " ";
            code_box.AutoComplete.StopCharacters = "(";
            code_box.AutoComplete.ListSeparator = '&';
            code_box.AutoComplete.IsCaseSensitive = false;
            code_box.AutoCompleteAccepted += new EventHandler<AutoCompleteAcceptedEventArgs>(code_box_AutoCompleteAccepted);
            code_box.SupressControlCharacters = true;
            code_box.Margins[0].Width = 36;
            code_box.Indentation.SmartIndentType = SmartIndent.CPP;
            code_box.Indentation.TabWidth = 2;
            code_box.CharAdded += new EventHandler<CharAddedEventArgs>(CodeBox_CharAdded);
            code_box.TextDeleted += new EventHandler<TextModifiedEventArgs>(code_box_TextChanged);
            code_box.TextInserted += new EventHandler<TextModifiedEventArgs>(code_box_TextChanged);
            code_box.Dock = DockStyle.Fill;
            code_box.Commands.AddBinding(Keys.D, Keys.Control, BindableCommand.LineDuplicate);
            Controls.Add(code_box);
        }

        void code_box_AutoCompleteAccepted(object sender, AutoCompleteAcceptedEventArgs e)
        {
            int pos = e.WordStartPosition - 1;
            string lastword = (pos > 0) ? code_box.GetWordFromPosition(pos) : "";

            if (lastword == "var" || lastword == "const" || lastword == "function")
            {
                e.Cancel = true;
            }
        }

        void code_box_TextChanged(object sender, EventArgs e)
        {
            if (!Parent.Text.Contains("*")) Parent.Text += "*";
        }

        public override void CreateNew()
        {
            if (Global.CurrentEditor.UseScriptUpdate)
            {
                code_box.Text += "/**\n* Script: Untitled.js" +
                       "\n* Written by: " + Global.CurrentProject.Author +
                       "\n* Updated: " + DateTime.Today.ToShortDateString() + "\n**/";
                code_box.UndoRedo.EmptyUndoBuffer();
            }
        }

        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }

        public override void LoadFile(string filename)
        {
            this.filename = filename;
            using (StreamReader FileReader = File.OpenText(filename))
            {
                code_box.UndoRedo.IsUndoEnabled = false;
                code_box.Text = FileReader.ReadToEnd();
                code_box.UndoRedo.IsUndoEnabled = true;
                if (!Global.IsScript(ref filename)) CodeBox.ConfigurationManager.Language = "default";
                Parent.Text = Path.GetFileName(filename);
            }
        }

        public override void Save()
        {
            if (this.filename == null) SaveAs();
            else
            {
                using (StreamWriter writer = new StreamWriter(filename, false))
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

                if (Global.CurrentProject.Path != null)
                    diag.InitialDirectory = Global.CurrentProject.Path + "\\scripts";

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

            string word = code_box.GetWordFromPosition(code_box.CurrentPos);
            string lword = word.ToLower();
            if (char.IsLetter(e.Ch))
            {
                List<string> filter = new List<string>();

                foreach (string s in Global.CurrentScriptSettings.FunctionList)
                {
                    if (s.ToLower().Contains(lword)) filter.Add(s);
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
