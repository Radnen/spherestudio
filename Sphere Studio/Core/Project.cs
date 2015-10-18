using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using SphereStudio.DockPanes;
using Sphere.Core;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio
{
    /// <summary>
    /// Represents a Sphere Studio project.
    /// </summary>
    class Project : IProject
    {
        private Dictionary<string, HashSet<int>> _breakpoints = new Dictionary<string, HashSet<int>>();
        private IniSettings _ssproj;

        /// <summary>
        /// Creates a new, empty Sphere Studio project.
        /// </summary>
        /// <param name="rootPath">Path of the directory where the project will reside. Must be empty.</param>
        /// <param name="name">The name of the project to create.</param>
        /// <returns>A Project object representing the new project.</returns>
        public static Project Create(string rootPath, string name)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(rootPath);
            if (dirInfo.Exists && dirInfo.GetFileSystemInfos().Length > 0)
                throw new ArgumentException("Root directory for a new project must be empty.");
            dirInfo.Create();
            var project = new Project(Path.Combine(dirInfo.FullName, MakeFileName(name)))
            {
                Name = name
            };
            return project;
        }

        /// <summary>
        /// Loads an existing project.
        /// </summary>
        /// <param name="rootPath">The full path of the directory containing the project.</param>
        /// <returns>A Project object used to manage the loaded project.</returns>
        public static Project Open(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();

            return new Project(fileName);
        }

        /// <summary>
        /// Creates a new Sphere Studio project from a Sphere 1.x game.sgm file.
        /// </summary>
        /// <param name="fileName">The fully qualified filename of the game.sgm to import.</param>
        /// <returns>A Project object representing the new project.</returns>
        public static Project FromSgm(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();

            var rootPath = Path.GetDirectoryName(fileName);
            Project project = new Project(Path.Combine(rootPath, "game.ssproj"))
            {
                Name = "Untitled",
                Author = "Author Unknown",
                Summary = "",
                ScreenWidth = 320,
                ScreenHeight = 240,
                MainScript = "main.js",
            };

            string[] sgmText = File.ReadAllLines(fileName);
            foreach (string line in sgmText)
            {
                try
                {
                    Match match = new Regex("(.+)=(.*)").Match(line);
                    if (match.Success)
                    {
                        string key = match.Groups[1].Value;
                        string value = match.Groups[2].Value;
                        switch (key)
                        {
                            case "name": project.Name = value; break;
                            case "author": project.Author = value; break;
                            case "description": project.Summary = value; break;
                            case "script": project.MainScript = value; break;
                            case "screen_width": project.ScreenWidth = int.Parse(value); break;
                            case "screen_height": project.ScreenHeight = int.Parse(value); break;
                        }
                    }
                }
                catch { }
            }

            project.FileName = Path.Combine(rootPath, MakeFileName(project.Name));
            project.Compiler = "Vanilla";
            return project;
        }

        private Project(string fileName)
        {
            fileName = Path.GetFullPath(fileName);
            FileName = fileName;
            _ssproj = new IniSettings(new IniFile(FileName, false), ".ssproj");
            User = new UserSettings(Path.ChangeExtension(FileName, ".ssuser"));
        }

        public UserSettings User { get; private set; }

        /// <summary>
        /// Gets the fully qualified filename of the .ssproj file.
        /// </summary>
        public string FileName { get; private set; }
        
        /// <summary>
        /// Gets the full path of the project's root directory.
        /// </summary>
        public string RootPath
        {
            get { return Path.GetDirectoryName(FileName); }
        }

        /// <summary>
        /// Gets or sets the name of the directory where the project
        /// is built. Relative to project root.
        /// </summary>
        public string BuildPath
        {
            get { return _ssproj.GetString("buildDir", "dist/"); }
            set
            {
                value = string.IsNullOrWhiteSpace(value) ? "./" : value;
                value = value.Replace(Path.DirectorySeparatorChar, '/');
                if (!value.EndsWith("/")) value += "/";
                _ssproj.SetValue("buildDir", value);
            }
        }

        public string ActiveEngine
        {
            get
            {
                string[] engines = PluginManager.GetNames<IStarter>();
                string defaultEngine =
                    engines.Contains(Core.Settings.Engine) ? Core.Settings.Engine
                    : engines.Length > 0 ? engines[0]
                    : "";
                string value = User.GetString("activeEngine", defaultEngine);
                return engines.Contains(value) ? value : Core.Settings.Engine;
            }
            set { User.SetValue("activeEngine", value); }
        }

        public string Compiler
        {
            get { return _ssproj.GetString("compiler", "Vanilla"); }
            set { _ssproj.SetValue("compiler", value); }
        }

        /// <summary>
        /// Gets or sets the project name (usually a title).
        /// </summary>
        public string Name
        {
            get { return _ssproj.GetString("name", "Untitled"); }
            set { _ssproj.SetValue("name", value); }
        }

        /// <summary>
        /// Gets or sets the name of the project author.
        /// </summary>
        public string Author
        {
            get { return _ssproj.GetString("author", ""); }
            set { _ssproj.SetValue("author", value); }
        }

        /// <summary>
        /// Gets or sets a short description of the game.
        /// </summary>
        public string Summary
        {
            get { return _ssproj.GetString("description", ""); }
            set { _ssproj.SetValue("description", value); }
        }

        /// <summary>
        /// Gets or sets the filename of the game's startup script, relative
        /// to the game's scripts/ directory.
        /// </summary>
        public string MainScript
        {
            get { return _ssproj.GetString("mainScript", ""); }
            set { _ssproj.SetValue("mainScript", value); }
        }

        /// <summary>
        /// Gets or sets the game's vertical resolution.
        /// </summary>
        public int ScreenWidth
        {
            get { return _ssproj.GetInteger("screenWidth", 320); }
            set { _ssproj.SetValue("screenWidth", value); }
        }

        /// <summary>
        /// Gets or sets the game's horizontal resolution.
        /// </summary>
        public int ScreenHeight
        {
            get { return _ssproj.GetInteger("screenHeight", 240); }
            set { _ssproj.SetValue("screenHeight", value); }
        }

        /// <summary>
        /// Saves any changes made to the project.
        /// </summary>
        public void Save()
        {
            User.SaveAs(Path.ChangeExtension(FileName, ".ssuser"));
            _ssproj.SaveAs(FileName);
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
                        User.GetString(string.Format("breakpointsSet:{0:X8}", hash), "").Split(','),
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
                User.SetValue(string.Format("breakpointsSet:{0:X8}", k.GetHashCode()),
                    string.Join(",", _breakpoints[k]));
            }
        }
        
        private static string MakeFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string pattern = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
            return Regex.Replace(name, pattern, "_") + ".ssproj";
        }
    }

    class UserSettings : IniSettings
    {
        public UserSettings(string filepath) :
            base(new IniFile(filepath, false), ".ssuser")
        {
        }

        /// <summary>
        /// Stores as a comma-separated list the opened files in the editor.
        /// </summary>
        public string[] Documents
        {
            get { return GetStringArray("openDocuments", new string[0]); }
            set { SetValue("openDocuments", value); }
        }

        /// <summary>
        /// Gets or sets the filepath of the last opened document you viewed.
        /// </summary>
        public string ActiveDocument
        {
            get { return GetString("currentDocument", ""); }
            set { SetValue("currentDocument", value); }
        }

        /// <summary>
        /// Gets or sets if the Start Page is hidden for this user.
        /// </summary>
        public bool StartHidden
        {
            get { return GetBoolean("hideStart", false); }
            set { SetValue("hideStart", value); }
        }

    }
}
