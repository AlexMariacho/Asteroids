using System;
using System.Timers;
using UnityEngine;

namespace Asteroids.Core
{
    public class LaserDestroy : IDestroyable
    {
        public event Action<IDestroyable> Death;
        public int Health { get; } = 1;
        private MonoBehaviour _selfView;

        public LaserDestroy(MonoBehaviour selfView, float lifeTime)
        {
            _selfView = selfView;
        }

        public void TakeDamage()
        {
        }

        public void Destroy()
        {
            GameObject.Destroy(_selfView.gameObject);
            Death?.Invoke(this);
        }
    }
}