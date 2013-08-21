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
            darkgroup.LabelStyle = new Style(Color.FromArgb(64, 64, 64), Color.White, null);
            darkgroup.PanelStyle = new Style(Color.FromArgb(127, 127, 127), null, null);
            darkgroup.MenuBarStyle = darkgroup.LabelStyle;
            darkgroup.ToolBarStyle = darkgroup.PanelStyle;

            var lightgroup = new StyleGroup();
            lightgroup.LabelStyle = new Style(Color.White, Color.Black, null);
            lightgroup.PanelStyle = lightgroup.LabelStyle;
            lightgroup.StatusBar = lightgroup.LabelStyle;
            lightgroup.MenuBarStyle = lightgroup.LabelStyle;
            lightgroup.ToolBarStyle = lightgroup.LabelStyle;

            var bluegroup = new StyleGroup();
            bluegroup.LabelStyle = new Style(Color.FromArgb(100, 120, 200), Color.DarkBlue, null);
            bluegroup.PanelStyle = new Style(Color.FromArgb(192, 192, 255), null, null);
            bluegroup.MenuBarStyle = bluegroup.LabelStyle;
            bluegroup.ToolBarStyle = bluegroup.PanelStyle;

            var greengroup = new StyleGroup();
            greengroup.LabelStyle = new Style(Color.FromArgb(0, 88, 38), Color.LightYellow, null);
            greengroup.PanelStyle = new Style(Color.LawnGreen, null, null);
            greengroup.MenuBarStyle = greengroup.LabelStyle;
            greengroup.ToolBarStyle = greengroup.PanelStyle;

            var orangegroup = new StyleGroup();
            orangegroup.LabelStyle = new Style(Color.FromArgb(247, 148, 29), Color.Black, null);
            orangegroup.PanelStyle = new Style(Color.LightGoldenrodYellow, null, null);
            orangegroup.MenuBarStyle = orangegroup.LabelStyle;
            orangegroup.ToolBarStyle = orangegroup.PanelStyle;

            var lesgroup = new StyleGroup();
            lesgroup.MenuBarStyle = new Style(Color.Green, Color.Black);
            lesgroup.ToolBarStyle = new Style(Color.ForestGreen, Color.Black);
            lesgroup.LabelStyle = new Style(Color.Goldenrod, Color.Black);
            lesgroup.PanelStyle = new Style(Color.DarkGoldenrod, Color.Black);

            AddStyle("Dark", darkgroup);
            AddStyle("Light", lightgroup);
            AddStyle("Blue", bluegroup);
            AddStyle("Green", greengroup);
            AddStyle("Orange", orangegroup);
            AddStyle("Lord English Special", lesgroup);
        }

        public static IReadOnlyDictionary<string, StyleGroup> Styles
        {
            get { return _styles; }
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
