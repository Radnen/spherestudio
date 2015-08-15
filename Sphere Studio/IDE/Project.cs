using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using SphereStudio.Settings;
using Sphere.Core;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.IDE
{
    class Project : IProject
    {
        Dictionary<string, HashSet<int>> _breakpoints = new Dictionary<string, HashSet<int>>();
        private INISettings _ini;
        private string _path;

        public static Project Create(string rootPath, string name)
        {
            Directory.CreateDirectory(rootPath);
            string[] subfolders = new[] {
                "animations", "fonts", "images", "maps", "scripts",
                "sounds", "spritesets", "windowstyles" };
            foreach (string subfolder in subfolders)
            {
                Directory.CreateDirectory(Path.Combine(rootPath, subfolder));
            }
            var project = new Project(Path.Combine(rootPath, MakeFileName(name))) { Name = name };
            project.Save();
            return project;
        }

        public static Project Open(string rootPath)
        {
            if (!Directory.Exists(rootPath))
                rootPath = Path.GetDirectoryName(rootPath);
            
            string[] ssprojs = Directory.GetFiles(rootPath, "*.ssproj");
            string[] sgms = Directory.GetFiles(rootPath, "game.sgm");
            if (ssprojs.Length > 0)
                return new Project(ssprojs[0]);
            else if (sgms.Length > 0)
                return new Project(sgms[0]);
            else
                throw new FileNotFoundException("No Sphere project was found in the specified directory.");
        }
        
        private Project(string filepath)
        {
            _path = filepath;
            var userpath = GetUserFilePath(filepath);
            User = new UserSettings(userpath);

            // auto-convert game.sgm to .ssproj
            if (Path.GetFileName(filepath) == "game.sgm")
            {
                _path = Path.Combine(Path.GetDirectoryName(filepath), "game.ssproj");
                _ini = new INISettings(new INI(_path, false), ".ssproj");
                Name = "Untitled";
                Author = "";
                Description = "";
                ScreenWidth = 320;
                ScreenHeight = 240;
                MainScript = "main.js";
                using (StreamReader file = new StreamReader(filepath))
                {
                    Regex regex = new Regex("^(.*)=(.*)$");
                    while (!file.EndOfStream)
                    {
                        Match match = regex.Match(file.ReadLine());
                        if (match.Success)
                        {
                            string key = match.Groups[1].Value;
                            string value = match.Groups[2].Value;
                            int intValue;
                            switch (key.ToLower())
                            {
                                case "name": Name = value; break;
                                case "author": Author = value; break;
                                case "description": Description = value; break;
                                case "screen_width":
                                    if (int.TryParse(value, out intValue))
                                        ScreenWidth = intValue;
                                    break;
                                case "screen_height":
                                    if (int.TryParse(value, out intValue))
                                        ScreenHeight = intValue;
                                    break;
                                case "script": MainScript = value; break;
                            }
                        }
                    }
                    file.Close();
                }
                _path = Path.Combine(Path.GetDirectoryName(_path), MakeFileName(Name));
            }
            else
            {
                _ini = new INISettings(new INI(_path, false), ".ssproj");
            }
        }

        public UserSettings User { get; private set; }

        /// <summary>
        /// Gets the full path of the project's root directory.
        /// </summary>
        public string RootPath
        {
            get { return Path.GetDirectoryName(_path); }
        }
        
        /// <summary>
        /// Gets or sets the project name (usually a title).
        /// </summary>
        public string Name
        {
            get { return _ini.GetString("name", "Untitled"); }
            set { _ini.SetValue("name", value); }
        }

        /// <summary>
        /// Gets or sets the name of the project author.
        /// </summary>
        public string Author
        {
            get { return _ini.GetString("author", ""); }
            set { _ini.SetValue("author", value); }
        }

        /// <summary>
        /// Gets or sets a short description of the game.
        /// </summary>
        public string Description
        {
            get { return _ini.GetString("description", ""); }
            set { _ini.SetValue("description", value); }
        }

        public string MainScript
        {
            get { return _ini.GetString("mainScript", ""); }
            set { _ini.SetValue("mainScript", value); }
        }

        /// <summary>
        /// Gets or sets the game's vertical resolution.
        /// </summary>
        public int ScreenWidth
        {
            get { return _ini.GetInteger("screenWidth", 320); }
            set { _ini.SetValue("screenWidth", value); }
        }
        
        /// <summary>
        /// Gets or sets the game's horizontal resolution.
        /// </summary>
        public int ScreenHeight
        {
            get { return _ini.GetInteger("screenHeight", 240); }
            set { _ini.SetValue("screenHeight", value); }
        }

        /// <summary>
        /// Saves any changes made to the project.
        /// </summary>
        public void Save()
        {
            User.SaveAs(GetUserFilePath(_path));
            _ini.SaveAs(_path);
        }
        
        /// <summary>
        /// Builds the project so it can be run by Sphere.
        /// </summary>
        /// <returns>The full path of the generated `game.sgm`.</returns>
        public string Build()
        {
            // save the project before building
            Save();

            // write out game.sgm
            string sgmPath = Path.Combine(Path.GetDirectoryName(_path), "game.sgm");
            using (StreamWriter writer = new StreamWriter(sgmPath, false))
            {
                writer.WriteLine(string.Format("name={0}", Name));
                writer.WriteLine(string.Format("author={0}", Author));
                writer.WriteLine(string.Format("description={0}", Description));
                writer.WriteLine(string.Format("screen_width={0}", ScreenWidth));
                writer.WriteLine(string.Format("screen_height={0}", ScreenHeight));
                writer.WriteLine(string.Format("script={0}", MainScript));
                writer.Close();
            }
            return sgmPath;
        }

        public IReadOnlyDictionary<string, int[]> GetAllBreakpoints()
        {
            Dictionary<string, int[]> retval = new Dictionary<string, int[]>();
            foreach (string k in _breakpoints.Keys)
            {
                retval.Add(k, _breakpoints[k].ToArray());
            }
            return retval;
        }


        public int[] GetBreakpoints(string scriptPath)
        {
            int hash = scriptPath.GetHashCode();
            if (_breakpoints.ContainsKey(scriptPath))
                return _breakpoints[scriptPath].ToArray();
            else
            {
                int[] lines = new int[0];
                try
                {
                    lines = Array.ConvertAll(
                        User.GetString(string.Format("bp_{0:X8}", hash), "").Split(','),
                        int.Parse);
                } catch (Exception) { }  // *munch*
                _breakpoints.Add(scriptPath, new HashSet<int>(lines));
                return lines;
            }
        }

        public void SetBreakpoints(string scriptPath, int[] lineNumbers)
        {
            _breakpoints[scriptPath] = new HashSet<int>(lineNumbers);
            foreach (var k in _breakpoints.Keys)
            {
                User.SetValue(string.Format("bp_{0:X8}", k.GetHashCode()),
                    string.Join(",", _breakpoints[k]));
            }
        }

        private string GetUserFilePath(string projectPath)
        {
            string dirpath = Path.GetDirectoryName(projectPath);
            return Path.Combine(dirpath,
                Path.GetFileNameWithoutExtension(projectPath) + ".ssuser");
        }
        
        private static string MakeFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string pattern = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
            return Regex.Replace(name, pattern, "_") + ".ssproj";
        }
    }
}
