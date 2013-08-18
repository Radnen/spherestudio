using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// Performs styling options on editor controls.
    /// </summary>
    public static class StyleSettings
    {
        /// <summary>
        /// The current style being depolyed to all forms affected by styling.
        /// </summary>
        public static string CurrentStyle = "Dark";

        private static Dictionary<string, StyleGroup> _styles = new Dictionary<string, StyleGroup>();

        static StyleSettings()
        {
            Style style;

            style = new Style();
            style.ForeColor = Color.White;
            style.BackColor = Color.FromArgb(64, 64, 64);
            var darkgroup = new StyleGroup();
            darkgroup.Label = style;
            darkgroup.Panel = new Style(Color.FromArgb(127, 127, 127), null, null);

            style = new Style();
            style.ForeColor = Color.Black;
            style.BackColor = Color.White;
            var lightgroup = new StyleGroup();
            lightgroup.Label = style;
            lightgroup.Panel = style;

            style = new Style();
            style.ForeColor = Color.DarkBlue;
            style.BackColor = Color.FromArgb(100, 120, 200);
            var bluegroup = new StyleGroup();
            bluegroup.Label = style;
            bluegroup.Panel = new Style(Color.LightSkyBlue, null, null);

            style = new Style();
            style.ForeColor = Color.LightYellow;
            style.BackColor = Color.FromArgb(0, 88, 38);
            var greengroup = new StyleGroup();
            greengroup.Label = style;
            greengroup.Panel = new Style(Color.LawnGreen, null, null);

            style = new Style();
            style.ForeColor = Color.Black;
            style.BackColor = Color.FromArgb(247, 148, 29);
            var orangegroup = new StyleGroup();
            orangegroup.Label = style;
            orangegroup.Panel = new Style(Color.LightGoldenrodYellow, null, null);

            _styles["Dark"] = darkgroup;
            _styles["Light"] = lightgroup;
            _styles["Blue"] = bluegroup;
            _styles["Green"] = greengroup;
            _styles["Orange"] = orangegroup;
        }

        /// <summary>
        /// Puts the current style into the target control.
        /// </summary>
        /// <param name="target"></param>
        public static void ApplyStyle(Control target)
        {
            _styles[CurrentStyle].Apply(target);
        }

        /// <summary>
        /// Adds the named style to the internal style list.
        /// </summary>
        /// <param name="name">Name of the style.</param>
        /// <param name="group">The style to add.</param>
        public static void AddStyle(string name, StyleGroup group)
        {
            _styles[name] = group;
        }

        /// <summary>
        /// Removes the associated style if it exist.
        /// </summary>
        /// <param name="name">Name of the style.</param>
        public static void RemoveStyle(string name)
        {
            if (_styles.ContainsKey(name))
                _styles.Remove(name);
        }
    }
}
