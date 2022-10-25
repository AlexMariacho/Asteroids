using UnityEngine;

namespace Asteroids.Core
{
    public interface IMover
    {
        float Speed { get; }
        Transform Transform { get; }


        void Move(Vector2 target);
    }

}