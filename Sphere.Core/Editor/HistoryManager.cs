using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Sphere.Core;

namespace Sphere.Core.Editor
{
    public class HistoryManager : IDisposable
    {
        int _history_pos = 0;
        List<HistoryPage> _pages;

        public bool CanUndo { get { return _history_pos != _pages.Count; } }
        public bool CanRedo { get { return _history_pos != 0; } }

        public HistoryManager()
        {
            _pages = new List<HistoryPage>();
        }

        public void PushPage(HistoryPage page)
        {
            for (int i = 0; i < _history_pos; ++i) _pages[i].Dispose();
            _pages.RemoveRange(0, _history_pos);

            _pages.Insert(0, page);
            _history_pos = 0;
        }

        /// <summary>
        /// Returns true if an undo has been successfully carried out.
        /// </summary>
        public bool Undo()
        {
            if (!CanUndo) return false;
            _pages[_history_pos].Undo();
            _history_pos++;
            return true;
        }

        /// <summary>
        /// Returns true if a redo has been successfully carried out.
        /// </summary>
        public bool Redo()
        {
            if (!CanRedo) return false;
            _history_pos--;
            _pages[_history_pos].Redo();
            return true;
        }

        public void Dispose()
        {
            for (int i = 0; i < _pages.Count; ++i)
                _pages[i].Dispose();
        }

        public void Clear()
        {
            Dispose();
            _pages.Clear();
            _history_pos = 0;
        }
    }

    public abstract class HistoryPage : IDisposable
    {
        public abstract void Undo();
        public abstract void Redo();

        public virtual void Dispose() { } // not all pages dispose
    }
}