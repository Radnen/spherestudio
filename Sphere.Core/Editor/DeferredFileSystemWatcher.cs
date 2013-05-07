using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

namespace Sphere.Core.Editor
{
    public delegate void BatchEventHandler<T>(object sender, IEnumerable<T> eList);
    
    public class DeferredFileSystemWatcher : FileSystemWatcher
    {
        private Timer _timer;
        private LinkedList<FileSystemEventArgs> _changeEvents = new LinkedList<FileSystemEventArgs>();
        private LinkedList<FileSystemEventArgs> _createEvents = new LinkedList<FileSystemEventArgs>();
        private LinkedList<FileSystemEventArgs> _deleteEvents = new LinkedList<FileSystemEventArgs>();
        private LinkedList<RenamedEventArgs> _renameEvents = new LinkedList<RenamedEventArgs>();

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            _changeEvents.AddLast(e);
            _timer.Stop();
            _timer.Start();
        }
        
        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            _createEvents.AddLast(e);
            _timer.Stop();
            _timer.Start();
        }
        
        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            _deleteEvents.AddLast(e);
            _timer.Stop();
            _timer.Start();
        }
        
        private void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            _renameEvents.AddLast(e);
            _timer.Stop();
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Changed != null && _changeEvents.Count > 0) Changed(null, _changeEvents);
            if (Created != null && _createEvents.Count > 0) Created(null, _createEvents);
            if (Deleted != null && _deleteEvents.Count > 0) Deleted(null, _deleteEvents);
            if (Renamed != null && _renameEvents.Count > 0) Renamed(null, _renameEvents);
            _changeEvents.Clear();
            _createEvents.Clear();
            _deleteEvents.Clear();
            _renameEvents.Clear();
        }

        protected override void Dispose(bool disposing)
        {
            _timer.Dispose();
            base.Dispose(disposing);
        }

        public DeferredFileSystemWatcher()
        {
            base.Changed += watcher_Changed;
            base.Created += watcher_Created;
            base.Deleted += watcher_Deleted;
            base.Renamed += watcher_Renamed;
            _timer = new Timer();
            _timer.Elapsed += _timer_Elapsed;
            _timer.AutoReset = false;
        }

        public new event BatchEventHandler<FileSystemEventArgs> Changed;
        public new event BatchEventHandler<FileSystemEventArgs> Created;
        public new event BatchEventHandler<FileSystemEventArgs> Deleted;
        public new event BatchEventHandler<RenamedEventArgs> Renamed;
        
        public double Delay
        {
            get { return _timer.Interval; }
            set { _timer.Interval = value; }
        }
    }
}
