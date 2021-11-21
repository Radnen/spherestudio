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
                BackColor = Color.FromArgb(32, 32, 32),
                FixedFont = new Font("Consolas", 10.25f),
                Font = new Font("Segoe UI", 9.0f),
                HighlightColor = Color.DarkSlateBlue,
                LabelColor = Color.FromArgb(32, 32, 32),
                TextColor = Color.LightGray,
                ToolColor = Color.FromArgb(48, 48, 48),
            };

            var lightTheme = new UIStyle("Light") {
                AccentColor = Color.DarkGray,
                BackColor = Color.White,
                FixedFont = new Font("Consolas", 10.0f),
                Font = new Font("Segoe UI", 9.0f),
                HighlightColor = Color.LightGray,
                LabelColor = Color.Gray,
                TextColor = Color.Black,
                ToolColor = Color.LightGray,
            };

            this.Styles = new[] { darkTheme, lightTheme };
        }

        public UIStyle[] Styles { get; private set; }
    }
}
