using UnityEngine;

namespace Asteroids.Core
{
    public abstract class BaseBullet
    {
        public IMove MoveComponent { get; protected set; }
        public ICheckBorder CheckBorder { get; protected set; }
        public ICollider Collider { get; protected set; }
        public IDestroyable Destroyable { get; protected set; }
        public MonoBehaviour View { get; protected set; }
    }
}