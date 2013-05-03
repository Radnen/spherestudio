using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sphere.Plugins
{
    public delegate void EditFileEventHandler(object sender, EditFileEventArgs e);

    public class EditFileEventArgs : EventArgs
    {
        public EditFileEventArgs(string filePath)
        {
            this.FileFullPath = filePath;
            this.FileExtension = Path.GetExtension(filePath);
            this.IsAlreadyMatched = false;
        }

        public string FileFullPath { get; private set; }
        public string FileExtension { get; private set; }
        public bool IsAlreadyMatched { get; set; }
    }
}
