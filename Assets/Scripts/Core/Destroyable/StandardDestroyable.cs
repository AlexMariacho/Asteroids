using System;
using UnityEngine;

namespace Asteroids.Core
{
    public class StandardDestroyable : IDestroyable
    {
        public event Action<IDestroyable> Death;
        public int Health { get; private set; }

        public StandardDestroyable(int health)
        {
            Health = health;
        }

        public void TakeDamage()
        {
            Health--;
            if (Health <= 0)
            {
                Health = 0;
                Death?.Invoke(this);
            }
        }
    }
}