using System;
using System.IO;

namespace Sphere.Plugins
{
    public class EditFileEventArgs : EventArgs
    {
        public EditFileEventArgs(string path, bool useWildcard = false)
        {
            Path = (path != null && path[0] == '?') ? null : path;
            string extension = System.IO.Path.GetExtension(path);
            if (extension != null)
                Extension = useWildcard ? "*" : extension.ToLower();
            Handled = false;
        }

        public string Path { get; private set; }

        public string Extension { get; private set; }
        public bool Handled { get; set; }
    }

    public delegate void EditFileEventHandler(object sender, EditFileEventArgs e);
}
