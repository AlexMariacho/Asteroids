using System;
using System.Timers;

namespace Asteroids
{
    public class Updater : IUpdater
    {
        public event Action UpdateEvent;
        private Timer _timer;

        public Updater(int frameRate)
        {
            _timer = new Timer((int)(1000 / frameRate));
            _timer.Enabled = true;
            _timer.AutoReset = true;
        }

        public void Start()
        {
            _timer.Elapsed += OnUpdateEvent;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Elapsed -= OnUpdateEvent;
            _timer.Stop();
        }

        private void OnUpdateEvent(object sender, ElapsedEventArgs e)
        {
            UpdateEvent?.Invoke();
        }
        
    }
}