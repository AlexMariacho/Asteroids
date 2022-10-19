using System;

namespace Asteroids
{
    public interface IUpdater
    {
        event Action UpdateEvent;
        void Start();
        void Stop();
    }
}