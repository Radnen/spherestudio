﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using SphereStudio.Base;

using SphereStudio.Plugins.Debugger;
using SphereStudio.Plugins.Properties;

namespace SphereStudio.Plugins.Forms
{
    partial class ObjectViewer : Form, IStyleAware
    {
        private Inferior _inferior;
        private KiAtom _value;

        public ObjectViewer(Inferior inferior, string objectName, KiAtom value)
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);

            m_nameTextBox.Text = string.Format("eval('{0}') = {1};",
                objectName.Replace(@"\", @"\\").Replace("'", @"\'").Replace("\n", @"\n").Replace("\r", @"\r"),
                value.ToString());
            TreeIconImageList.Images.Add("object", Resources.StackIcon);
            TreeIconImageList.Images.Add("prop", Resources.VisibleIcon);
            TreeIconImageList.Images.Add("hiddenProp", Resources.InvisibleIcon);

            _inferior = inferior;
            _value = value;
        }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsTextView(m_nameTextBox);
            style.AsTextView(m_propListTreeView);
            style.AsAccent(m_okButton);

        }

        private async void this_Load(object sender, EventArgs e)
        {
            m_propListTreeView.BeginUpdate();
            m_propListTreeView.Nodes.Clear();
            var trunk = m_propListTreeView.Nodes.Add(_value.ToString());
            trunk.ImageKey = "object";
            if (_value.Tag == KiTag.Ref)
                await PopulateTreeNode(trunk, (KiRef)_value);
            trunk.Expand();
            m_propListTreeView.EndUpdate();
        }

        private async void PropTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag == null || e.Node.Nodes[0].Text != "")
                return;

            PropDesc propDesc = (PropDesc)e.Node.Tag;
            if (propDesc.Value.Tag == KiTag.Ref)
                await PopulateTreeNode(e.Node, (KiRef)propDesc.Value);
        }

        private void PropTree_MouseMove(object sender, MouseEventArgs e)
        {
            var ht = m_propListTreeView.HitTest(e.Location);
            m_propListTreeView.Cursor = ht.Node != null && ht.Node.Bounds.Contains(e.Location)
                ? Cursors.Hand : Cursors.Default;
        }

        private async Task PopulateTreeNode(TreeNode node, KiRef handle)
        {
            m_propListTreeView.BeginUpdate();
            var props = await _inferior.InspectObject(handle, 0, int.MaxValue);
            foreach (var key in props.Keys) {
                if (props[key].Flags.HasFlag(PropFlags.Accessor)) {
                    KiAtom getter = props[key].Getter;
                    KiAtom setter = props[key].Setter;
                    var nodeText = string.Format("{0} = get: {1}, set: {2}", key,
                        getter.ToString(), setter.ToString());
                    var valueNode = node.Nodes.Add(nodeText);
                    valueNode.ImageKey = "prop";
                    valueNode.SelectedImageKey = valueNode.ImageKey;
                    valueNode.Tag = props[key];
                }
                else {
                    KiAtom value = props[key].Value;
                    var nodeText = string.Format("{0} = {1}", key, value.ToString());
                    var valueNode = node.Nodes.Add(nodeText);
                    valueNode.ImageKey = "prop";
                    valueNode.SelectedImageKey = valueNode.ImageKey;
                    valueNode.Tag = props[key];
                    if (value.Tag == KiTag.Ref) {
                        valueNode.Nodes.Add("");
                    }
                }
            }
            if (node.Nodes.Count > 0 && node.Nodes[0].Text == "")
                node.Nodes.RemoveAt(0);
            m_propListTreeView.EndUpdate();
        }
    }
}
