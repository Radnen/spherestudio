using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jurassic;
using Jurassic.Library;

namespace SphereStudio.Pipeline
{
    /// <summary>
    /// Represents a Sphere Studio build target.
    /// </summary>
    class Target : ObjectInstance
    {
        private string _path;

        /// <summary>
        /// Constructs a new build target.
        /// </summary>
        /// <param name="build">The pipeline instance managing the build.</param>
        /// <param name="path">The absolute path of the directory the target will be built in.</param>
        public Target(BuildEngine build, string path)
            : base(build.JS)
        {
            PopulateFunctions();

            _path = path;
        }

        /// <summary>
        /// Gets the absolute path of the target directory.
        /// </summary>
        [JSProperty(Name = "path", IsConfigurable = false, IsEnumerable = false)]
        public string RootPath
        {
            get { return _path.EndsWith(@"\") ? _path : _path + @"\"; }
        }

        [JSFunction(Name = "mkdir", IsConfigurable = false, IsEnumerable = false)]
        public void mkdir(string name)
        {
            Directory.CreateDirectory(Path.Combine(RootPath,
                name.Replace('/', Path.DirectorySeparatorChar)));
        }

        /// <summary>
        /// Deletes a file or directory.
        /// </summary>
        /// <param name="recursive">
        /// true to recursively delete subdirectories. If this is false and a directory
        /// is being deleted, it must be empty. Ignored if 'filename' refers to a file.
        /// </param>
        /// <param name="filename">The filename of the file or directory.</param>
        [JSFunction (Name = "rm", IsConfigurable = false, IsEnumerable = false)]
        public void rm(string filename, [DefaultParameterValue(false)] bool recursive = false)
        {
            var fullPath = Path.Combine(RootPath, filename);
            if (File.Exists(fullPath))
                File.Delete(fullPath);
            else if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, recursive);
            }
        }
    }
}
