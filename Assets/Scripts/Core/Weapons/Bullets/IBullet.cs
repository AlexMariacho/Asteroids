using UnityEngine;

namespace Asteroids.Core
{
    public interface IBullet
    {
        void CheckCollision(Vector2 position);
    }
}