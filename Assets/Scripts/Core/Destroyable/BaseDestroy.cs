using System;

namespace Asteroids.Core
{
    public class BaseDestroy : IDestroyable
    {
        public event Action<IDestroyable> Death;
        public int Health { get; protected set; }

        public BaseDestroy(int health)
        {
            Health = health;
        }

        public virtual void TakeDamage()
        {
            Health--;
            if (Health <= 0)
            {
                Health = 0;
            }
        }

        public virtual void Destroy()
        {
            Death?.Invoke(this);
        }
    }
}