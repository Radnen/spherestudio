using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Sphere_Editor.Settings
{
    public class ScriptSettings
    {
        private static string word_chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string word_stops = " :;{}[].,?/!@#$%^&*_+-=|\\<>\'\"123456789";

        public List<string> FunctionList { get; private set; }

        public ScriptSettings()
        {
            FunctionList = new List<string>();
        }

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
                while (!reader.EndOfStream)
                    FunctionList.Add(reader.ReadLine());
            }

            FunctionFile = null;
            return true;
        }

        // This will load the function list.
        public void LoadSettings()
        {
            LoadFunctionList();
        }
    }
}
