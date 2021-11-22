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
                BackColor = Color.FromArgb(24, 24, 32),
                FixedFont = new Font("Consolas", 10.0f),
                Font = new Font("Segoe UI", 9.0f),
                HighlightColor = Color.DarkSlateBlue,
                LabelColor = Color.FromArgb(32, 32, 32),
                TextColor = Color.LightGray,
                ToolColor = Color.FromArgb(48, 48, 48),
            };

            var lightTheme = new UIStyle("Light") {
                AccentColor = Color.FromArgb(192, 192, 208),
                BackColor = Color.White,
                FixedFont = new Font("Consolas", 10.0f),
                Font = new Font("Segoe UI", 9.0f),
                HighlightColor = Color.LightGoldenrodYellow,
                LabelColor = Color.LightSteelBlue,
                TextColor = Color.Black,
                ToolColor = Color.FromArgb(208, 208, 224),
            };

            this.Styles = new[] { darkTheme, lightTheme };
        }

        public UIStyle[] Styles { get; private set; }
    }
}
