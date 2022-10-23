using UnityEngine;

namespace Asteroids.Core
{
    public abstract class BaseBullet : IBullet
    {
        protected BulletConfig _bulletConfig;
        
        public virtual void CheckCollision(Vector2 position)
        {
        }
    }
}