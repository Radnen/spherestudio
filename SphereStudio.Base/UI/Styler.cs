using System;
using System.Collections.Generic;
using System.Linq;

namespace SphereStudio.UI
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
        /// Registers an IStyleable component to be automatically styled.
        /// </summary>
        /// <param name="component">An object implementing IStyleable.</param>
        public static void AutoStyle(IStyleable component)
        {
            // this is a clever use of weak references I think: we only style controls
            // as long as they have active references elsewhere, without keeping them
            // alive unnecessarily with a strong reference.
            var weakRef = new WeakReference<IStyleable>(component);
            m_Styleables.Add(weakRef);
            if (Style != null)
                component.ApplyStyle(Style);
        }

        /// <summary>
        /// Restyles all controls with the current UI style.
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
