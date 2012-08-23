﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Sphere_Editor.SphereObjects;
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
            Person = new Entity();
            Person.Type = 1;
            InitializeComponent();
        }

        public PersonForm(Entity entity, List<Entity> entities)
        {
            EntityList = entities;
            Person = entity;
            Person.Type = 1;
            InitializeComponent();
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
            ScriptBox.Text = (string)Person.Scripts[0];
            ScriptBox.Dock = DockStyle.Fill;
            NameTextBox.Text = Person.Name;
            SpritesetBox.Text = Person.Spriteset;

            // Set the spriteset preview //
            SpritePreview.Image = Person.Graphic;
            DirectionBox.Items.AddRange(Person.Sprite.GetDirections());
            
            PositionLabel.Text = "(X: " + Person.X + ", Y: " + Person.Y + ")";
            CodePanel.Controls.Add(ScriptBox);
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
            String path = Global.CurrentProject.Path + "\\spritesets";
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

                    // Load a spriteset image as a preview:
                    Person.Spriteset = SpritesetBox.Text;
                    Person.LoadSpriteset();
                    SpritePreview.Image = Person.Graphic;
                    DirectionBox.Items.Clear();
                    DirectionBox.Items.AddRange(Person.Sprite.GetDirections());
                }
            }
        }

        private void DirectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dir = (string)DirectionBox.SelectedItem;
            if (Person.Sprite != null)
                SpritePreview.Image = Person.Sprite.GetImage(dir, 0);
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