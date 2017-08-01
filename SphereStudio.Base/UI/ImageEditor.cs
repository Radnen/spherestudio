using System;
using System.Drawing;
using System.Windows.Forms;

using SphereStudio.Base;

namespace SphereStudio.UI
{
    /// <summary>
    /// Defers image editing functionality to the active Image plugin.
    /// </summary>
    public partial class ImageEditor : UserControl
    {
        private ImageView _view;

        /// <summary>
        /// Constructs an Image Editor control.
        /// </summary>
        public ImageEditor()
        {
            InitializeComponent();

            var plugin = PluginManager.Get<IEditor<ImageView>>(PluginManager.Core.Settings.ImageEditor);
            _view = plugin != null ? plugin.CreateEditView() : null;
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

        /// <summary>
        /// Fires when the image is modified.
        /// </summary>
        public event EventHandler ImageChanged;

        /// <summary>
        /// Gets the image contents as a Bitmap.
        /// </summary>
        public Bitmap Content
        {
            get { return _view != null ? _view.Content : null; }
            set { if (_view != null) _view.Content = value; }
        }

        /// <summary>
        /// Splits the image into tiles and returns the tile bitmaps.
        /// </summary>
        /// <param name="tileWidth">Tile width.</param>
        /// <param name="tileHeight">Tile height.</param>
        /// <returns>An array of tile bitmaps.</returns>
        public Bitmap[] GetImages(short tileWidth, short tileHeight)
        {
            if (_view == null) return null;
            return _view.GetImages(tileWidth, tileHeight);
        }

        /// <summary>
        /// Zooms in the image by one level.
        /// </summary>
        public void ZoomIn()
        {
            if (_view != null) _view.ZoomIn();
        }

        /// <summary>
        /// Zooms out the image by one level.
        /// </summary>
        public void ZoomOut()
        {
            if (_view != null) _view.ZoomOut();
        }
    }
}
