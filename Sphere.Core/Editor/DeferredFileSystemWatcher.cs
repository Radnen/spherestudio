using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Timers;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// The event handler used for batching files in the DeferredFileSystemWatcher
    /// </summary>
    /// <param name="sender">Usually the calling object.</param>
    /// <param name="eAll">The items.</param>
    /// <typeparam name="T">The type of the items.</typeparam>
    public delegate void BatchEventHandler<in T>(object sender, IEnumerable<T> eAll);
    
    /// <summary>
    /// A FileSystemWatcher that only triggers after so long of a delay.
    /// </summary>
    public class DeferredFileSystemWatcher : FileSystemWatcher
    {
        private readonly Timer _timer;
        private readonly LinkedList<FileSystemEventArgs> _changeEvents = new LinkedList<FileSystemEventArgs>();
        private readonly LinkedList<FileSystemEventArgs> _createEvents = new LinkedList<FileSystemEventArgs>();
        private readonly LinkedList<FileSystemEventArgs> _deleteEvents = new LinkedList<FileSystemEventArgs>();
        private readonly LinkedList<RenamedEventArgs> _renameEvents = new LinkedList<RenamedEventArgs>();
        
        private void base_Changed(object sender, FileSystemEventArgs e)
        {
            _changeEvents.AddLast(e);
            _timer.Stop();
            _timer.Start();
        }
        
        private void base_Created(object sender, FileSystemEventArgs e)
        {
            _createEvents.AddLast(e);
            _timer.Stop();
            _timer.Start();
        }
        
        private void base_Deleted(object sender, FileSystemEventArgs e)
        {
            _deleteEvents.AddLast(e);
            _timer.Stop();
            _timer.Start();
        }
        
        private void base_Renamed(object sender, RenamedEventArgs e)
        {
            _renameEvents.AddLast(e);
            _timer.Stop();
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Changed != null && _changeEvents.Count > 0) Changed(this, _changeEvents);
            if (Created != null && _createEvents.Count > 0) Created(this, _createEvents);
            if (Deleted != null && _deleteEvents.Count > 0) Deleted(this, _deleteEvents);
            if (Renamed != null && _renameEvents.Count > 0) Renamed(this, _renameEvents);
            _changeEvents.Clear();
            _createEvents.Clear();
            _deleteEvents.Clear();
            _renameEvents.Clear();
        }

        /// <summary>
        /// Overrides the default dispose method to dispose the timer.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _timer.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes a new instance of the DeferredFileSystemWatcher.
        /// </summary>
        public DeferredFileSystemWatcher()
        {
            base.Changed += base_Changed;
            base.Created += base_Created;
            base.Deleted += base_Deleted;
            base.Renamed += base_Renamed;
            _timer = new Timer { AutoReset = false };
            _timer.Elapsed += _timer_Elapsed;
            Delay = 250;
        }

        /// <summary>
        /// The component whose thread the event delegates will be invoked on.
        /// </summary>
        public new ISynchronizeInvoke SynchronizingObject
        {
            get { return base.SynchronizingObject; }
            set
            {
                base.SynchronizingObject = value;
                _timer.SynchronizingObject = value;
            }
        }

        /// <summary>
        /// Event handler for when a file has been changed.
        /// </summary>
        public new event BatchEventHandler<FileSystemEventArgs> Changed;

        /// <summary>
        /// Event handler for when a file is created.
        /// </summary>
        public new event BatchEventHandler<FileSystemEventArgs> Created;

        /// <summary>
        /// Event handler for when a file has been deleted.
        /// </summary>
        public new event BatchEventHandler<FileSystemEventArgs> Deleted;

        /// <summary>
        /// Event handler for when a file has been renamed.
        /// </summary>
        public new event BatchEventHandler<RenamedEventArgs> Renamed;

        /// <summary>
        /// Gets or sets how much time, in milliseconds, must pass after the last FileSystemWatcher event
        /// before a batch event is raised.
        /// </summary>
        public double Delay
        {
            get { return _timer.Interval; }
            set { _timer.Interval = value; }
        }
    }
}
