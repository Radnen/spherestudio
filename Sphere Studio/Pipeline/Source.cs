using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jurassic;
using Jurassic.Library;

using SphereStudio.IDE;

namespace SphereStudio.Pipeline
{
    /// <summary>
    /// Represents a Sphere Studio project being built.
    /// </summary>
    class Source : ObjectInstance
    {
        private BuildEngine _build;
        private Project _project;

        /// <summary>
        /// Constructs a new build source for a project.
        /// </summary>
        /// <param name="js">The JS engine instance.</param>
        /// <param name="project">The project being sourced.</param>
        public Source(BuildEngine build, Project project)
            : base(build.JS)
        {
            PopulateFunctions();

            _build = build;
            _project = project;
        }

        /// <summary>
        /// Gets the game title.
        /// </summary>
        [JSProperty(Name = "name", IsConfigurable = false, IsEnumerable = false)]
        public string Name { get { return _project.Name; } }

        /// <summary>
        /// Gets or sets the name of the game's author.
        /// </summary>
        [JSProperty(Name = "author", IsConfigurable = false, IsEnumerable = false)]
        public string Author { get { return _project.Author; } }

        /// <summary>
        /// Gets or sets a short description of the game.
        /// </summary>
        [JSProperty(Name = "description", IsConfigurable = false, IsEnumerable = false)]
        public string Description { get { return _project.Description; } }

        /// <summary>
        /// Gets or sets the width component of the game resolution.
        /// </summary>
        [JSProperty(Name = "screenWidth", IsConfigurable = false, IsEnumerable = false)]
        public int ScreenWidth { get { return _project.ScreenWidth; } }

        /// <summary>
        /// Gets or sets the height component of the game resolution.
        /// </summary>
        [JSProperty(Name = "screenHeight", IsConfigurable = false, IsEnumerable = false)]
        public int ScreenHeight { get { return _project.ScreenHeight; } }

        /// <summary>
        /// Gets the filename of the game's startup script, relative to
        /// the distribution scripts/ directory. Not SphereFS-compliant.
        /// </summary>
        [JSProperty(Name = "mainScript", IsConfigurable = false, IsEnumerable = false)]
        public string MainScript { get { return _project.MainScript; } }
        
        /// <summary>
        /// Gets the absolute path of the source directory, including trailing
        /// backslash.
        /// </summary>
        [JSProperty(Name = "path", IsConfigurable = false, IsEnumerable = false)]
        public string RootPath
        {
            get
            {
                string pathSep = Path.DirectorySeparatorChar.ToString();
                return _project.RootPath.EndsWith(pathSep)
                    ? _project.RootPath
                    : _project.RootPath + pathSep;
            }
        }

        /// <summary>
        /// Gets the name of the build directory. May be relative, in which case
        /// it is relative to the project root.
        /// </summary>
        [JSProperty(Name = "buildPath", IsConfigurable = false, IsEnumerable = false)]
        public string BuildPath
        {
            get { return _project.BuildPath; }
        }

        /// <summary>
        /// Copies a single file from the project.
        /// </summary>
        /// <param name="sourcePath">The path of the file to copy, relative to the project.</param>
        /// <param name="destPath">The full path of the destination file.</param>
        [JSFunction(Name = "cp", IsConfigurable = false, IsEnumerable = false)]
        public void cp(string sourcePath, string destPath, [DefaultParameterValue(false)] bool forceCopy = false)
        {
            var absPath = Path.Combine(RootPath, sourcePath.Replace('/', '\\'));
            destPath = destPath.Replace('/', Path.DirectorySeparatorChar);
            bool wantCopy = !File.Exists(destPath) || forceCopy;
            if (File.Exists(destPath))
            {
                DateTime sourceTime = new FileInfo(absPath).LastWriteTime;
                DateTime destTime = new FileInfo(destPath).LastWriteTime;
                wantCopy |= destTime < sourceTime;
            }
            if (wantCopy)
            {
                _build.Print("-> " + sourcePath);
                Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                File.Copy(absPath, destPath, true);
            }
        }
        
        /// <summary>
        /// Generates a listing of all files in a directory.
        /// </summary>
        /// <param name="subdir">The directory path to search.</param>
        /// <param name="isRecursive">true to search recursively in subdirectories.</param>
        /// <returns>A JS array instance with full paths of all listed files.</returns>
        [JSFunction(Name = "ls", IsConfigurable = false, IsEnumerable = false)]
        public ArrayInstance ls(
            [DefaultParameterValue("*")] string filter = "*",
            [DefaultParameterValue("")] string subdir = "",
            [DefaultParameterValue(true)] bool isRecursive = true)
        {
            var absPath = Path.Combine(RootPath, subdir.Replace('/', '\\'));
            var dirInfo = new DirectoryInfo(absPath);
            var option = isRecursive
                ? SearchOption.AllDirectories
                : SearchOption.TopDirectoryOnly;
            var q = from fi in dirInfo.GetFiles(filter, option)
                    where fi.FullName.StartsWith(RootPath)
                    select fi.FullName.Substring(RootPath.Length).Replace('\\', '/');
            return Engine.Array.New(q.ToArray());
        }
        
        /// <summary>
        /// Creates a subdirectory. Parent directories are created recursively.
        /// </summary>
        /// <param name="name">The name of the directory to create, relative to the project.</param>
        [JSFunction(Name = "mkdir", IsConfigurable = false, IsEnumerable = false)]
        public void mkdir(string name)
        {
            Directory.CreateDirectory(Path.Combine(RootPath,
                name.Replace('/', Path.DirectorySeparatorChar)));
        }
    }
}
