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
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace Sphere.Plugins.EditShims
{
    public partial class ImageEditShim : UserControl
    {
        private ImageView _view;

        public ImageEditShim()
        {
            InitializeComponent();

            _view = PluginManager.IDE.CreateImageView();
            if (_view != null)
            {
                _view.Dock = DockStyle.Fill;
                _view.ImageChanged += (sender, e) =>
                {
                    if (ImageChanged != null) ImageChanged(this, e);
                };
                Controls.Add(_view);
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
