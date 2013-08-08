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

namespace Sphere.Plugins.EditShims
{
    public partial class ImageEditShim : UserControl
    {
        public ImageEditShim()
        {
            InitializeComponent();
            _editor = PluginManager.CreateEditControl(EditorType.Image);
            if (_editor != null)
            {
                IImageEditor editor = _editor as IImageEditor;
                editor.ImageEdited += (sender, e) => ImageEdited(this, e);
                _editor.Dock = DockStyle.Fill;
                Controls.Add(_editor);
                statusLabel.Hide();
            }
            else
                statusLabel.Text = "No suitable plugin was found to edit this image.";
        }

        public event EventHandler ImageEdited;

        public Bitmap GetImage()
        {
            if (_editor == null) return null;
            return (_editor as IImageEditor).GetImage();
        }
        
        public IList<Bitmap> GetImages(short tileWidth, short tileHeight)
        {
            if (_editor == null) return null;
            IImageEditor editor = _editor as IImageEditor;
            return editor.GetImages(tileWidth, tileHeight);
        }

        public void SetImage(Bitmap image)
        {
            if (_editor == null) return;
            (_editor as IImageEditor).SetImage(image);
        }

        private EditorObject _editor;
    }
}
