using System;
using System.ComponentModel;
using System.IO;

namespace Sphere.Plugins
{
    /// <summary>
    /// Provides data for Sphere Studio 'edit file' events.
    /// </summary>
    public class EditFileEventArgs : HandledEventArgs
    {
        /// <summary>
        /// Initializes a new instance of EditFileEventArgs, which provides data for Sphere Studio 'edit file' events.
        /// </summary>
        /// <param name="path">The full path of the file to be edited.</param>
        /// <param name="useWildcard">If true, reports a wildcard ('*') in place of the file's actual extension.</param>
        public EditFileEventArgs(string path)
        {
            Path = (path != null && path[0] == '?') ? null : path;
            Extension = System.IO.Path.GetExtension(path);
        }

        /// <summary>
        /// The file extension of the file to be edited, including the dot ('.'),
        /// or an empty string if the file has no extension.
        /// </summary>
        public string Extension { get; private set; }
        
        /// <summary>
        /// The full path of the file to be edited.
        /// </summary>
        public string Path { get; private set; }
    }

    public delegate void EditFileEventHandler(object sender, EditFileEventArgs e);
}
