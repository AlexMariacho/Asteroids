using UnityEngine;

namespace Asteroids.Core
{
    public interface IMover
    {
        float Speed { get; }
        void Move(Vector2 point, float time);
    }
}