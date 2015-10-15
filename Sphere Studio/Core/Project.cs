using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using SphereStudio.DockPanes;
using Sphere.Core;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio
{
    class Project : IProject
    {
        private Dictionary<string, HashSet<int>> _breakpoints = new Dictionary<string, HashSet<int>>();
        private IniSettings _ssproj;
        private string _projFileName;
        private string _userFileName;

        public static Project Create(string rootPath, string name)
        {
            Directory.CreateDirectory(rootPath);
            var project = new Project(Path.Combine(rootPath, MakeFileName(name))) { Name = name };
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

        private Project(string fileName)
        {
            fileName = Path.GetFullPath(fileName);
            _projFileName = fileName;
            _userFileName = Path.ChangeExtension(fileName, ".ssuser");
            _ssproj = new IniSettings(new IniFile(_projFileName, false), ".ssproj");
            User = new UserSettings(_userFileName);
        }

        public UserSettings User { get; private set; }

        /// <summary>
        /// Gets the path and filename of the .ssproj file.
        /// </summary>
        public string FileName
        {
            get { return _projFileName; }
        }
        
        /// <summary>
        /// Gets the full path of the project's root directory.
        /// </summary>
        public string RootPath
        {
            get { return Path.GetDirectoryName(_projFileName); }
        }

        /// <summary>
        /// Gets or sets the name of the directory where the project
        /// is built. May be relative.
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

        public string Engine
        {
            get { return _ssproj.GetString("engine", ""); }
            set { _ssproj.SetValue("engine", value); }
        }

        public string Compiler
        {
            get { return _ssproj.GetString("compiler", ""); }
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
        public string Description
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
            User.SaveAs(_userFileName);
            _ssproj.SaveAs(_projFileName);
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
            get { return GetStringArray("openDocuments"); }
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
