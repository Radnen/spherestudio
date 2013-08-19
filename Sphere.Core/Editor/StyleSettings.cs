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
            var darkgroup = new StyleGroup();
            darkgroup.Label = new Style(Color.FromArgb(64, 64, 64), Color.White, null);
            darkgroup.Panel = new Style(Color.FromArgb(127, 127, 127), null, null);
            darkgroup.MenuBar = darkgroup.Label;
            darkgroup.ToolBar = darkgroup.Panel;

            var lightgroup = new StyleGroup();
            lightgroup.Label = new Style(Color.White, Color.Black, null);
            lightgroup.Panel = lightgroup.Label;
            lightgroup.StatusBar = lightgroup.Label;
            lightgroup.MenuBar = lightgroup.Label;
            lightgroup.ToolBar = lightgroup.Label;

            var bluegroup = new StyleGroup();
            bluegroup.Label = new Style(Color.FromArgb(100, 120, 200), Color.DarkBlue, null);
            bluegroup.Panel = new Style(Color.FromArgb(192, 192, 255), null, null);
            bluegroup.MenuBar = bluegroup.Label;
            bluegroup.ToolBar = bluegroup.Panel;

            var greengroup = new StyleGroup();
            greengroup.Label = new Style(Color.FromArgb(0, 88, 38), Color.LightYellow, null);
            greengroup.Panel = new Style(Color.LawnGreen, null, null);
            greengroup.MenuBar = greengroup.Label;
            greengroup.ToolBar = greengroup.Panel;

            var orangegroup = new StyleGroup();
            orangegroup.Label = new Style(Color.FromArgb(247, 148, 29), Color.Black, null);
            orangegroup.Panel = new Style(Color.LightGoldenrodYellow, null, null);
            orangegroup.MenuBar = orangegroup.Label;
            orangegroup.ToolBar = orangegroup.Panel;

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
