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
        private IImageView _view;

        public ImageEditShim()
        {
            InitializeComponent();
            
            _view = PluginManager.CreateEditView(EditorType.Image) as IImageView;
            if (_view != null)
            {
                _view.Control.Dock = DockStyle.Fill;
                _view.ImageChanged += (sender, e) =>
                {
                    if (ImageChanged != null) ImageChanged(this, e);
                };
                Controls.Add(_view.Control);
                statusLabel.Hide();
            }
            else
            {
                statusLabel.Text = "No suitable plugin was found to edit this image.";
            }
        }

        public event EventHandler ImageChanged;

        public Bitmap Content
        {
            get { return _view != null ? _view.Content : null; }
            set { if (_view != null) _view.Content = value; }
        }

        public IList<Bitmap> GetImages(short tileWidth, short tileHeight)
        {
            if (_view == null) return null;
            return _view.GetImages(tileWidth, tileHeight);
        }

        public void ZoomIn()
        {
            if (_view != null) _view.ZoomIn();
        }
        
        public void ZoomOut()
        {
            if (_view != null) _view.ZoomOut();
        }
    }
}
