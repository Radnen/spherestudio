using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sphere.Plugins
{
    public class EditFileEventArgs : EventArgs
    {
        public EditFileEventArgs(string filePath, bool useWildcard = false)
        {
            this.FileFullPath = (filePath != null && filePath[0] == '.') ? null : filePath;
            this.FileExtension = useWildcard ? "*" : Path.GetExtension(filePath);
            this.IsAlreadyMatched = false;
        }

        public string FileFullPath { get; private set; }
        public string FileExtension { get; private set; }
        public bool IsAlreadyMatched { get; set; }
    }

    public delegate void EditFileEventHandler(object sender, EditFileEventArgs e);
}
