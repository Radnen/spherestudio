using System.Drawing;

using Sphere.Core.Editor;
using Sphere.Plugins.Interfaces;

namespace SphereStudio
{
    class DefaultStyles : IStyleProvider
    {
        public DefaultStyles()
        {
            var darkTheme = new UIStyle("Dark")
            {
                AccentColor = Color.FromArgb(32, 32, 48),
                BackColor = Color.FromArgb(16, 16, 16),
                FixedFont = new Font("Consolas", 10.25f),
                Font = new Font("Segoe UI", 9),
                LabelColor = Color.FromArgb(32, 32, 32),
                TextColor = Color.DarkGray,
                ToolColor = Color.FromArgb(48, 48, 48),
            };

            var lightTheme = new UIStyle("Light")
            {
                AccentColor = Color.LightGoldenrodYellow,
                BackColor = Color.GhostWhite,
                FixedFont = new Font("Consolas", 10.25f),
                Font = new Font("Segoe UI", 9),
                LabelColor = Color.LightSlateGray,
                TextColor = Color.Black,
                ToolColor = Color.LightSteelBlue,
            };

            this.Styles = new[] { darkTheme, lightTheme };
        }

        public UIStyle[] Styles { get; private set; }
    }
}
