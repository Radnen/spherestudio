using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using SphereStudio.Settings;
using Sphere.Core;
using Sphere.Plugins;

namespace SphereStudio.IDE
{
    class Project : IProject
    {
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
                using (StreamReader file = new StreamReader(filepath))
                {
                    Regex regex = new Regex("^(.*)=(.*)$");
                    while (!file.EndOfStream)
                    {
                        Match match = regex.Match(file.ReadLine());
                        string key = match.Success ? match.Groups[1].Value : null;
                        string value = match.Success ? match.Groups[2].Value : null;
                        switch (key.ToLower())
                        {
                            case "name": Name = value; break;
                            case "author": Author = value; break;
                            case "description": Description = value; break;
                            case "screen_width": ScreenWidth = Convert.ToInt32(value); break;
                            case "screen_height": ScreenHeight = Convert.ToInt32(value); break;
                            case "script": MainScript = value; break;
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

        public string RootPath
        {
            get { return Path.GetDirectoryName(_path); }
        }
        
        public string Name
        {
            get { return _ini.GetString("name", "Untitled"); }
            set { _ini.SetValue("name", value); }
        }

        public string Author
        {
            get { return _ini.GetString("author", ""); }
            set { _ini.SetValue("author", value); }
        }

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

        public int ScreenWidth
        {
            get { return _ini.GetInteger("screenWidth", 320); }
            set { _ini.SetValue("screenWidth", value); }
        }
        
        public int ScreenHeight
        {
            get { return _ini.GetInteger("screenHeight", 240); }
            set { _ini.SetValue("screenHeight", value); }
        }

        public void Save()
        {
            SaveAs(_path);
        }
        
        public void SaveAs(string filepath)
        {
            _path = filepath;
            User.SaveAs(GetUserFilePath(_path));
            _ini.SaveAs(_path);
        }

        public void Build()
        {
            string dirpath = Path.GetDirectoryName(_path);
            string sgmPath = Path.Combine(dirpath, "game.sgm");
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
