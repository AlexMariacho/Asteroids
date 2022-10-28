using UnityEngine;

namespace Asteroids.Core
{
    public interface ICollider
    {
        Transform Transform { get; }
        float SizeCollider { get; }
    }
}