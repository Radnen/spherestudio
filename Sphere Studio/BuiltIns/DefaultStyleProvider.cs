using System.Drawing;

using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Ide.BuiltIns
{
    class DefaultStyleProvider : IStyleProvider
    {
        public DefaultStyleProvider()
        {
            var darkTheme = new UIStyle("Dark") {
                AccentColor = Color.FromArgb(32, 32, 48),
                BackColor = Color.FromArgb(24, 24, 24),
                FixedFont = new Font("Consolas", 10.25f),
                Font = new Font("Segoe UI", 9),
                HighlightColor = Color.DarkSlateBlue,
                LabelColor = Color.FromArgb(32, 32, 32),
                TextColor = Color.LightGray,
                ToolColor = Color.FromArgb(48, 48, 48),
            };

            var lightTheme = new UIStyle("Light") {
                AccentColor = Color.LightGoldenrodYellow,
                BackColor = Color.GhostWhite,
                FixedFont = new Font("Consolas", 10.25f),
                Font = new Font("Segoe UI", 9),
                HighlightColor = Color.FromArgb(155, 225, 255),  // "Purwa Blue"
                LabelColor = Color.LightSlateGray,
                TextColor = Color.Black,
                ToolColor = Color.LightSteelBlue,
            };

            this.Styles = new[] { darkTheme, lightTheme };
        }

        public UIStyle[] Styles { get; private set; }
    }
}
