using UnityEngine;

namespace Asteroids.Core
{
    public abstract class BaseUnit
    {
        public IMove MoveComponent { get; protected set; }
        public IDestroyable DestroyableComponent { get; protected set; }
        public ICheckBorder CheckBorderComponent { get; protected set; }
        public ICollider ColliderComponent { get; protected set; }
        public MonoBehaviour View { get; protected set; }
    }
}