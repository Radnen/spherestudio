using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sphere.Core;

namespace SphereStudio.Plugins.Components
{
    partial class EntityControl : UserControl
    {
        private List<Entity> _entities = new List<Entity>();
        private List<Layer> _layers = new List<Layer>();

        /// <summary>
        /// This control allows you to peer at the list of entities on a map.
        /// </summary>
        public EntityControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates this entity view with appropriate data. WinForms API lacks
        /// the ability to dynamically bind to a data set so this will have to do.
        /// </summary>
        /// <param name="entities">The entity list from the map you want to view.</param>
        public void UpdateList(List<Entity> entities, List<Layer> layers)
        {
            _entities = entities;
            _layers = layers;
            EntityListView.Items.Clear();
            EntityListView.BeginUpdate();
            EntityListView.SmallImageList = new ImageList();
            int num = 0, triggers = 0;
            foreach (var entity in entities)
            {
                string name = "", type = "";
                if (entity.Type == Entity.EntityType.Trigger)
                {
                    triggers++;
                    name = $"Trigger: {triggers}";
                    type = "Trigger";
                }
                else if (entity.Type == Entity.EntityType.Person)
                {
                    name = entity.Name;
                    type = "Person";
                }

                var item = new ListViewItem(name);
                item.Tag = entity;
                item.SubItems.Add(entity.Layer.ToString());
                item.SubItems.Add(type);
                EntityListView.Items.Add(item);
                EntityListView.SmallImageList.Images.Add(entity.Image);
                item.ImageIndex = num++;
            }
            EntityListView.EndUpdate();
        }

        private void EntityListView_ItemActivate(object sender, EventArgs e)
        {
            if (EntityListView.SelectedItems.Count > 0)
            {
                var entity = EntityListView.SelectedItems[0].Tag as Entity;
                if (entity?.Type == Entity.EntityType.Person)
                {
                    var form = new Forms.PersonForm(entity, _entities);
                    form.AddLayers(_layers);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // write the new entity
                        _entities[_entities.IndexOf(entity)] = form.Person;
                    }
                }
                else if (entity?.Type == Entity.EntityType.Trigger)
                {
                    var form = new Forms.TriggerForm(entity);
                    form.AddLayers(_layers);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // write the new entity
                        _entities[_entities.IndexOf(entity)] = form.Trigger;
                    }
                }
            }
        }
    }
}
