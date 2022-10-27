using System;
using UnityEngine;

namespace Asteroids.Core
{
    public interface IDestroyable
    {
        public event Action<IDestroyable> Death;
        int Health { get; }
        void TakeDamage();
    }
}