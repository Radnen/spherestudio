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
    public partial class ImageEditShim : EditorObject, IImageEditor
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

        public override void Redo()
        {
            _editor.Redo();
        }
        
        public void SetImage(Bitmap image)
        {
            if (_editor == null) return;
            (_editor as IImageEditor).SetImage(image);
        }

        public override void Undo()
        {
            _editor.Undo();
        }

        public override void ZoomIn()
        {
            _editor.ZoomIn();
        }

        public override void ZoomOut()
        {
            _editor.ZoomOut();
        }

        private EditorObject _editor;
    }
}
