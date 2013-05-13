using System;
using System.IO;

namespace Sphere.Plugins
{
    public class EditFileEventArgs : EventArgs
    {
        public EditFileEventArgs(string filePath, bool useWildcard = false)
        {
            FileFullPath = (filePath != null && filePath[0] == '?') ? null : filePath;
            string extension = Path.GetExtension(filePath);
            if (extension != null)
                FileExtension = useWildcard ? "*" : extension.ToLower();
            IsAlreadyMatched = false;
        }

        public string FileFullPath { get; private set; }

        public string FileExtension { get; private set; }
        public bool IsAlreadyMatched { get; set; }
    }

    public delegate void EditFileEventHandler(object sender, EditFileEventArgs e);
}
