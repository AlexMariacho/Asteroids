using UnityEngine;

namespace Asteroids.Core.Collisions
{
    public interface ICollider
    {
        Vector3 Position { get; }
        float SizeCollider { get; }
    }
}