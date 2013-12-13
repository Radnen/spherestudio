using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
            Font mainUIFont = new Font("Segoe UI", 9);
            
            var darkgroup = new StyleGroup();
            darkgroup.LabelStyle = new Style(Color.FromArgb(64, 64, 64), Color.White, mainUIFont);
            darkgroup.PanelStyle = new Style(Color.FromArgb(127, 127, 127), null, mainUIFont);
            darkgroup.MenuBarStyle = darkgroup.LabelStyle;
            darkgroup.ToolBarStyle = darkgroup.PanelStyle;
            darkgroup.SecondaryStyle = new Style(Color.LightGray, null, mainUIFont);

            var lightgroup = new StyleGroup();
            lightgroup.LabelStyle = new Style(Color.LightGray, Color.Black, mainUIFont);
            lightgroup.PanelStyle = new Style(Color.White, null, mainUIFont);
            lightgroup.StatusBarStyle = lightgroup.PanelStyle;
            lightgroup.MenuBarStyle = lightgroup.LabelStyle;
            lightgroup.ToolBarStyle = lightgroup.PanelStyle;
            lightgroup.SecondaryStyle = lightgroup.PanelStyle;

            var bluegroup = new StyleGroup();
            bluegroup.LabelStyle = new Style(Color.FromArgb(100, 120, 200), Color.DarkBlue, mainUIFont);
            bluegroup.PanelStyle = new Style(Color.FromArgb(192, 192, 255), null, mainUIFont);
            bluegroup.MenuBarStyle = bluegroup.LabelStyle;
            bluegroup.ToolBarStyle = bluegroup.PanelStyle;
            bluegroup.SecondaryStyle = new Style(Color.FromArgb(230, 230, 255), null, mainUIFont);

            var greengroup = new StyleGroup();
            greengroup.LabelStyle = new Style(Color.FromArgb(0, 88, 38), Color.LightYellow, mainUIFont);
            greengroup.PanelStyle = new Style(Color.FromArgb(135, 185, 80), null, mainUIFont);
            greengroup.MenuBarStyle = greengroup.LabelStyle;
            greengroup.ToolBarStyle = greengroup.PanelStyle;
            greengroup.SecondaryStyle = new Style(Color.FromArgb(225, 237, 197), null, mainUIFont);

            var orangegroup = new StyleGroup();
            orangegroup.LabelStyle = new Style(Color.FromArgb(255, 192, 104), Color.Black, mainUIFont);
            orangegroup.PanelStyle = new Style(Color.FromArgb(254, 230, 173), null, mainUIFont);
            orangegroup.MenuBarStyle = orangegroup.LabelStyle;
            orangegroup.ToolBarStyle = orangegroup.PanelStyle;
            orangegroup.SecondaryStyle = new Style(Color.LightYellow, null, mainUIFont);

            var lesgroup = new StyleGroup();
            lesgroup.MenuBarStyle = new Style(Color.Green, Color.Black, mainUIFont);
            lesgroup.ToolBarStyle = new Style(Color.Green, Color.Black, mainUIFont);
            lesgroup.LabelStyle = new Style(Color.Goldenrod, Color.Black, mainUIFont);
            lesgroup.PanelStyle = new Style(Color.DarkGoldenrod, Color.Black, mainUIFont);
            lesgroup.WindowStyle = new Style(Color.DarkGreen, Color.White, mainUIFont);
            lesgroup.SecondaryStyle = new Style(Color.DarkGreen, Color.White, mainUIFont);

            AddStyle("Dark", darkgroup);
            AddStyle("Light", lightgroup);
            AddStyle("Blue", bluegroup);
            AddStyle("Green", greengroup);
            AddStyle("Orange", orangegroup);
            AddStyle("Lord English Special", lesgroup);
        }

        /// <summary>
        /// Gets a readonly version of the installed styles.
        /// </summary>
        public static IReadOnlyDictionary<string, StyleGroup> Styles
        {
            get { return _styles; }
        }

        /// <summary>
        /// Puts the current style into the target control.
        /// </summary>
        /// <param name="target">The .NET Form or Control to style.</param>
        public static void ApplyStyle(Control target)
        {
            _styles[CurrentStyle].ApplyPrimary(target);
        }

        /// <summary>
        /// Puts the current style's secondarry options into the target control.
        /// </summary>
        /// <param name="target">The .NET Form or Control to style.</param>
        public static void ApplySecondaryStyle(Control target)
        {
            _styles[CurrentStyle].ApplySecondary(target);
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
