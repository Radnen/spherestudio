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
    public partial class ScriptEditShim : UserControl
    {
        private ScriptView _view;

        public ScriptEditShim()
        {
            InitializeComponent();

            // try to use a plugin for script editing
            _view = PluginManager.IDE.CreateScriptView();
            if (_view != null)
            {
                _view.Dock = DockStyle.Fill;
                Controls.Add(_view);
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
