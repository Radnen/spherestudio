using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using SphereStudio.UI;
using SphereStudio.Settings;
using Sphere.Core;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.IDE
{
    class Project : IProject, IDisposable
    {
        private Dictionary<string, HashSet<int>> _breakpoints = new Dictionary<string, HashSet<int>>();
        private BuildConsole _buildView;
        private INISettings _ini;
        private string _path;

        public static Project Create(string rootPath, string name)
        {
            Directory.CreateDirectory(rootPath);
            var project = new Project(Path.Combine(rootPath, MakeFileName(name)), true) { Name = name };
            project.Save();
            return project;
        }

        /// <summary>
        /// Loads an existing project.
        /// </summary>
        /// <param name="rootPath">The full path of the directory containing the project.</param>
        /// <param name="allowBuild">Whether to initialize a build pipeline for this project.</param>
        /// <returns></returns>
        public static Project Open(string rootPath, bool allowBuild = true)
        {
            if (!Directory.Exists(rootPath))
                rootPath = Path.GetDirectoryName(rootPath);

            string[] ssprojs = Directory.GetFiles(rootPath, "*.ssproj");
            string[] sgms = Directory.GetFiles(rootPath, "game.sgm");
            if (ssprojs.Length > 0)
                return new Project(ssprojs[0], allowBuild);
            else if (sgms.Length > 0)
                return new Project(sgms[0], allowBuild);
            else
                return null;
        }

        private Project(string filepath, bool allowBuilding)
        {
            filepath = Path.GetFullPath(filepath);  // canonize
            var userpath = GetUserFilePath(filepath);
            User = new UserSettings(userpath);

            if (Path.GetExtension(filepath) == ".sgm")
            {
                // auto-convert game.sgm to .ssproj
                _path = Path.Combine(Path.GetDirectoryName(filepath), "game.ssproj");
                _ini = new INISettings(new INI(_path, false), ".ssproj");
                Name = "Untitled";
                Author = "";
                Description = "";
                ScreenWidth = 320;
                ScreenHeight = 240;
                MainScript = "main.js";
                BuildPath = "./";
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
                _ini.Save();
            }
            else
            {
                // loading .ssproj directly
                _path = filepath;
                _ini = new INISettings(new INI(_path, false), ".ssproj");
            }
            if (allowBuilding)
            {
                _buildView = new BuildConsole();
                Sphere.Plugins.PluginManager.IDE.Docking.Hide(_buildView);
            }
        }

        public void Dispose()
        {
            if (_buildView != null) _buildView.Dispose();
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
        /// Gets or sets the name of the directory where the project
        /// is built. May be relative.
        /// </summary>
        public string BuildPath
        {
            get { return _ini.GetString("buildDir", "./"); }
            set
            {
                value = string.IsNullOrWhiteSpace(value) ? "./" : value;
                value = value.Replace(Path.DirectorySeparatorChar, '/');
                if (!value.EndsWith("/")) value += "/";
                _ini.SetValue("buildDir", value);
            }
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

        /// <summary>
        /// Gets or sets the filename of the game's startup script, relative
        /// to the game's scripts/ directory.
        /// </summary>
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
            if (scriptPath == null) return new int[0];
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
            return Path.ChangeExtension(projectPath, ".ssuser");
        }
        
        private static string MakeFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string pattern = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
            return Regex.Replace(name, pattern, "_") + ".ssproj";
        }
    }
}
