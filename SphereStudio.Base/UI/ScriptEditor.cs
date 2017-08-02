using System.Windows.Forms;

using SphereStudio.Base;

namespace SphereStudio.UI
{
    /// <summary>
    /// Defers code editing functionality to the active Script plugin.
    /// </summary>
    public partial class ScriptEditor : UserControl
    {
        private ScriptView _view;

        /// <summary>
        /// Constructs a Script Editor control.
        /// </summary>
        public ScriptEditor()
        {
            InitializeComponent();

            // try to use a plugin for script editing
            var plugin = PluginManager.Get<IEditor<ScriptView>>(PluginManager.Core.Settings.ScriptEditor);
            _view = plugin != null ? plugin.CreateEditView() : null;
            if (_view != null)
            {
                _view.Dock = DockStyle.Fill;
                Controls.Add(_view);
                fallbackTextBox.Hide();
            }
        }

        /// <summary>
        /// Gets or sets the contents of the script.
        /// </summary>
        public override string Text
        {
            get
            {
                return _view != null ? _view.Text : fallbackTextBox.Text;
            }
            set
            {
                if (_view != null)
                    _view.Text = value;
                else
                    fallbackTextBox.Text = value;
            }
        }
    }
}
