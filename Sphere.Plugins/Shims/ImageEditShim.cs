using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sphere.Core.Editor;

namespace Sphere.Plugins.Shims
{
    public partial class ImageEditShim : UserControl
    {
        public ImageEditShim()
        {
            InitializeComponent();
            _editControl = PluginManager.CreateEditControl(EditorType.Image);
            if (_editControl != null)
            {
                IImageEditor editor = _editControl as IImageEditor;
                editor.ImageEdited += (sender, e) => ImageEdited(this, e);
                _editControl.Dock = DockStyle.Fill;
                Controls.Add(_editControl);
                statusLabel.Hide();
            }
            else
                statusLabel.Text = "No suitable plugin was found to edit this image.";
        }

        public event EventHandler ImageEdited;
        
        public Bitmap GetImage()
        {
            if (_editControl == null) return null;
            return (_editControl as IImageEditor).GetImage();
        }
        
        public List<Bitmap> GetImages(short tileWidth, short tileHeight)
        {
            if (_editControl == null) return null;
            IImageEditor editor = _editControl as IImageEditor;
            return editor.GetImages(tileWidth, tileHeight);
        }

        public void SetImage(Bitmap image)
        {
            if (_editControl == null) return;
            (_editControl as IImageEditor).SetImage(image);
        }

        private EditorObject _editControl;
    }
}
