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
    public partial class ScriptEditShim : UserControl
    {
        private IScriptView _view;

        public ScriptEditShim()
        {
            InitializeComponent();
            
            // try to use a plugin for script editing
            _view = PluginManager.CreateEditView(EditorType.Script) as IScriptView;
            if (_view != null)
            {
                _view.Control.Dock = DockStyle.Fill;
                Controls.Add(_view.Control);
                fallbackTextBox.Hide();
            }
        }

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
