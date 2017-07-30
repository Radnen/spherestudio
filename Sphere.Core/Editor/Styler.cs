using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// Manages and applies UI styles throughout the IDE.
    /// </summary>
    public static class Styler
    {
        static List<WeakReference<IStyleable>> m_Styleables = new List<WeakReference<IStyleable>>();
        static UIStyle m_Style;

        /// <summary>
        /// Gets or sets the current UI style for the IDE.
        /// </summary>
        public static UIStyle Style
        {
            get => m_Style;
            set
            {
                m_Style = value;
                Refresh();
            }
        }
        
        /// <summary>
        /// Registers a styleable component to be automatically styled.
        /// </summary>
        /// <param name="component">An object implementing IThemeable.</param>
        public static void AutoStyle(IStyleable component)
        {
            var weakRef = new WeakReference<IStyleable>(component);
            m_Styleables.Add(weakRef);
            Refresh();
        }

        /// <summary>
        /// Updates all stylables with the current UI style.
        /// </summary>
        public static void Refresh()
        {
            if (m_Style == null)
                return;

            // clean up any dead references first
            m_Styleables = m_Styleables
                .Where(it => it.TryGetTarget(out _))
                .ToList();

            // restyle all registered components
            foreach (var stylableRef in m_Styleables)
            {
                stylableRef.TryGetTarget(out IStyleable component);
                if (component != null)
                {
                    component.ApplyStyle(m_Style);
                }
            }
        }
    }
}
