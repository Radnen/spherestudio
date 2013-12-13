using System;
using System.Collections.Generic;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// Manages undo/redo history for an editable document.
    /// </summary>
    public class HistoryManager : IDisposable
    {
        int _history_pos = 0;
        List<HistoryPage> _pages;

        /// <summary>
        /// Gets whether an Undo operation can currently be carried out.
        /// </summary>
        public bool CanUndo { get { return _history_pos != _pages.Count; } }
        
        /// <summary>
        /// Gets whether a Redo operation can currently be carried out.
        /// </summary>
        public bool CanRedo { get { return _history_pos != 0; } }

        /// <summary>
        /// Initializes a new history manager.
        /// </summary>
        public HistoryManager()
        {
            _pages = new List<HistoryPage>();
        }

        /// <summary>
        /// Pushes a history page onto the top of the undo stack.
        /// </summary>
        /// <param name="page">The HistoryPage to be added.</param>
        public void PushPage(HistoryPage page)
        {
            for (int i = 0; i < _history_pos; ++i) _pages[i].Dispose();
            _pages.RemoveRange(0, _history_pos);

            _pages.Insert(0, page);
            _history_pos = 0;
        }

        /// <summary>
        /// Undoes the most recently applied action.
        /// </summary>
        /// <returns>true of an undo operation was carried out, false otherwise.</returns>
        public bool Undo()
        {
            if (!CanUndo) return false;
            _pages[_history_pos].Undo();
            _history_pos++;
            return true;
        }

        /// <summary>
        /// Reverts the most recent undo operation.
        /// </summary>
        /// <returns>true if a redo operation was carried out, false otherwise.</returns>
        public bool Redo()
        {
            if (!CanRedo) return false;
            _history_pos--;
            _pages[_history_pos].Redo();
            return true;
        }

        /// <summary>
        /// Performs cleanup for the history manager and all pages in the undo/redo stack.
        /// </summary>
        public void Dispose()
        {
            for (int i = 0; i < _pages.Count; ++i)
                _pages[i].Dispose();
        }

        /// <summary>
        /// Clears all undo/redo history and disposes the history manager.
        /// </summary>
        public void Clear()
        {
            Dispose();
            _pages.Clear();
            _history_pos = 0;
        }
    }

    /// <summary>
    /// Base class for a history page. History pages represent operations that can be undone or
    /// redone by a HistoryManager. This is an abstract class.
    /// </summary>
    public abstract class HistoryPage : IDisposable
    {
        /// <summary>
        /// Undoes the change represented by the HistoryPage.
        /// </summary>
        public abstract void Undo();
        
        /// <summary>
        /// Replays the change represented by the HistoryPage.
        /// </summary>
        public abstract void Redo();

        /// <summary>
        /// Cleans up resources owned by the HistoryPage.
        /// </summary>
        public virtual void Dispose() { } // not all pages dispose
    }
}