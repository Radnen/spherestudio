using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Sphere.Core.SphereObjects;
using Sphere_Editor.SubEditors;

namespace Sphere_Editor.Forms
{
    public partial class PersonForm : Form
    {
        public Entity Person { get; private set; }
        public List<Entity> EntityList { get; private set; }
        ScriptEditor ScriptBox = new ScriptEditor();
        private int last = 0;

        public PersonForm(List<Entity> entities)
        {
            EntityList = entities;
            Person = new Entity(Entity.EntityType.Person);
            InitializeComponent();
            ScriptBox.Text = (string)Person.Scripts[0];
            ScriptBox.Dock = DockStyle.Fill;
            CodePanel.Controls.Add(ScriptBox);
        }

        public PersonForm(Entity entity, List<Entity> entities)
        {
            EntityList = entities;
            Person = entity;
            Person.Type = Entity.EntityType.Person;
            InitializeComponent();
            ScriptBox.Text = (string)Person.Scripts[0];
            ScriptBox.Dock = DockStyle.Fill;
            CodePanel.Controls.Add(ScriptBox);
        }

        public void AddString(string text)
        {
            LayerComboBox.Items.Add(LayerComboBox.Items.Count + ". " + text);
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
            SpritePreview.Image = Person.GetSSImage(Global.CurrentProject.RootPath);

            // fill in sprite directions:
            string[] dirs = Person.GetSpriteDirections(Global.CurrentProject.RootPath);
            if (dirs != null) DirectionBox.Items.AddRange(dirs);
            
            PositionLabel.Text = "(X: " + Person.X + ", Y: " + Person.Y + ")";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Person.Name = NameTextBox.Text;
            Person.Spriteset = SpritesetBox.Text;
            Person.Scripts[last] = ScriptBox.Text;
        }

        private void LayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person.Layer = (short)LayerComboBox.SelectedIndex;
        }

        private void ScriptTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person.Scripts[last] = ScriptBox.Text;
            ScriptBox.Text = (string)Person.Scripts[ScriptTabControl.SelectedIndex];
            last = ScriptTabControl.SelectedIndex;
        }

        private void SpritesetButton_Click(object sender, EventArgs e)
        {
            String path = Global.CurrentProject.RootPath + "\\spritesets";
            using (OpenFileDialog sprite_diag = new OpenFileDialog())
            {
                sprite_diag.Filter = "Sprite Files (*.rss)|*.rss";
                if (System.IO.Directory.Exists(path))
                    sprite_diag.InitialDirectory = path;
                if (sprite_diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Figure out its relative path:
                    String sprite_path = sprite_diag.FileName;
                    sprite_path = sprite_path.Substring(sprite_path.LastIndexOf("spritesets"));
                    sprite_path = sprite_path.Substring(sprite_path.IndexOf("\\") + 1);
                    SpritesetBox.Text = sprite_path.Replace("\\", "/");
                    Person.Spriteset = SpritesetBox.Text;

                    // Load a spriteset image as a preview:
                    SpritePreview.Image = Person.GetSSImage(Global.CurrentProject.RootPath);
                    
                    DirectionBox.Items.Clear();
                    string[] dirs = Person.GetSpriteDirections(Global.CurrentProject.RootPath);
                    if (dirs != null) DirectionBox.Items.AddRange(dirs);
                }
            }
        }

        private void DirectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dir = (string)DirectionBox.SelectedItem;
            string script = (string)Person.Scripts[0];
            script = "SetPersonDirection(\"" + NameTextBox.Text + "\", \"" + dir + "\");\n" + script;
            ScriptBox.Text = script;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            Person.FigureOutName(EntityList);
            NameTextBox.Text = Person.Name;
        }
    }
}
