using System;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Sphere_Editor.Settings
{
    public class ScriptSettings
    {
        public String CurrentWord = "";
        private static string word_chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string word_stops = " :;{}[].,?/!@#$%^&*_+-=|\\<>\'\"123456789";
        private static string function_list;

        public string FunctionList { get { return function_list; } }

        public string WordChars
        {
            get { return word_chars; }
        }

        public string WordStops
        {
            get { return word_stops; }
        }

        // will populate it's own function list with the contents of a function.txt file.
        private bool LoadFunctionList()
        {
            FileInfo FunctionFile = new FileInfo(Application.StartupPath + "\\docs\\functions.txt");
            if (!FunctionFile.Exists) { FunctionFile = null; return false; }

            using (StreamReader reader = FunctionFile.OpenText())
            {
                StringBuilder builder = new StringBuilder(500);
                while (!reader.EndOfStream)
                {
                    builder.Append(reader.ReadLine());
                }
                function_list = builder.ToString();
            }
            FunctionFile = null;
            return true;
        }

        // This will load the function list.
        public void LoadSettings()
        {
            LoadFunctionList();
        }

        public void UpdateCurrentWord(char single_ch)
        {
            if (char.IsLetter(single_ch)) CurrentWord += single_ch;
            else if (char.IsWhiteSpace(single_ch)) CurrentWord = "";
        }
    }
}
