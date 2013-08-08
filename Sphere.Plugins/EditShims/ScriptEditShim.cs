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
        public ScriptEditShim()
        {
            InitializeComponent();
            
            // try to use a plugin for script editing
            _editor = PluginManager.CreateEditControl(EditorType.Script);
            if (_editor != null)
            {
                IImageEditor editor = _editor as IImageEditor;
                _editor.Dock = DockStyle.Fill;
                Controls.Add(_editor);
                fallbackTextBox.Hide();
            }
        }

        public override string Text
        {
            get { return _editor != null ? (_editor as IScriptEditor).Text : fallbackTextBox.Text; }
            set
            {
                if (_editor != null) (_editor as IScriptEditor).Text = value;
                    else fallbackTextBox.Text = value;
            }
        }

        private EditorObject _editor;
    }
}
