using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Core.Editor;
using Sphere.Plugins;
using Sphere.Plugins.EditShims;
using SphereStudio.Plugins.Components;

namespace SphereStudio.Plugins.Forms
{
    partial class PersonForm : Form
    {
        public Entity Person { get; private set; }
        public List<Entity> EntityList { get; private set; }
        readonly ScriptEditShim _scriptBox = new ScriptEditShim();
        private int _last;

        public PersonForm(List<Entity> entities)
        {
            EntityList = entities;
            Person = new Entity(Entity.EntityType.Person);
            InitializeComponent();
            _scriptBox.Text = Person.Scripts[0];
            _scriptBox.Dock = DockStyle.Fill;
            CodePanel.Controls.Add(_scriptBox);
        }

        public PersonForm(Entity entity, List<Entity> entities)
        {
            EntityList = entities;
            Person = entity;
            Person.Type = Entity.EntityType.Person;
            InitializeComponent();
            _scriptBox.Text = Person.Scripts[0];
            _scriptBox.Dock = DockStyle.Fill;
            CodePanel.Controls.Add(_scriptBox);
        }

        /// <summary>
        /// Use this to optinally add the layers to this Person Form.
        /// </summary>
        /// <param name="layers"></param>
        public void AddLayers(List<Layer> layers)
        {
            LayerComboBox.BeginUpdate();
            foreach (Layer layer in layers)
            {
                LayerComboBox.Items.Add(LayerComboBox.Items.Count + ": " + layer.Name);
            }
            LayerComboBox.EndUpdate();
        }

        public int SelectedIndex
        {
            set { LayerComboBox.SelectedIndex = value; Person.Layer = (short)value; }
        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            NameTextBox.Text = Person.Name;
            SpritesetBox.Text = Person.Spriteset;
            LayerComboBox.SelectedIndex = Person.Layer;

            // set sprite preview:
            SpritePreview.Image = Person.GetSSImage(PluginManager.IDE.Project.RootPath);

            // fill in sprite directions:
            string[] dirs = Person.GetSpriteDirections(PluginManager.IDE.Project.RootPath);
            if (dirs != null) DirectionBox.Items.AddRange(dirs);
            
            PositionLabel.Text = string.Format("(X: {0}, Y: {1})", Person.X, Person.Y);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Person.Name = NameTextBox.Text;
            Person.Spriteset = SpritesetBox.Text;
            Person.Scripts[_last] = _scriptBox.Text;
        }

        private void LayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person.Layer = (short)LayerComboBox.SelectedIndex;
        }

        private void ScriptTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person.Scripts[_last] = _scriptBox.Text;
            _scriptBox.Text = Person.Scripts[ScriptTabControl.SelectedIndex];
            _last = ScriptTabControl.SelectedIndex;
        }

        private void SpritesetButton_Click(object sender, EventArgs e)
        {
            String path = PluginManager.IDE.Project.RootPath + "\\spritesets";
            using (OpenFileDialog spriteDiag = new OpenFileDialog())
            {
                spriteDiag.Filter = @"Sprite Files (*.rss)|*.rss";
                if (System.IO.Directory.Exists(path))
                    spriteDiag.InitialDirectory = path;
                if (spriteDiag.ShowDialog() == DialogResult.OK)
                {
                    // Figure out its relative path:
                    String spritePath = spriteDiag.FileName;
                    spritePath = spritePath.Substring(spritePath.LastIndexOf("spritesets", StringComparison.Ordinal));
                    spritePath = spritePath.Substring(spritePath.IndexOf("\\", StringComparison.Ordinal) + 1);
                    SpritesetBox.Text = spritePath.Replace("\\", "/");
                    Person.Spriteset = SpritesetBox.Text;

                    // Load a spriteset image as a preview:
                    SpritePreview.Image = Person.GetSSImage(PluginManager.IDE.Project.RootPath);
                    
                    DirectionBox.Items.Clear();
                    object[] dirs = Person.GetSpriteDirections(PluginManager.IDE.Project.RootPath);
                    if (dirs != null) DirectionBox.Items.AddRange(dirs);
                }
            }
        }

        private void DirectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dir = (string)DirectionBox.SelectedItem;
            string script = Person.Scripts[0];
            string format = "SetPersonDirection(\"{0}\", \"{1}\");\n{2}";
            _scriptBox.Text = string.Format(format, NameTextBox.Text, dir, script);
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            Person.FigureOutName(EntityList);
            NameTextBox.Text = Person.Name;
        }
    }
}
