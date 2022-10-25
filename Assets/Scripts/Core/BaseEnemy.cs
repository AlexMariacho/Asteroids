using UnityEngine;

namespace Asteroids.Core
{
    public abstract class BaseEnemy
    {
        public IMove MoveComponent { get; protected set; }
        public ICheckBorder CheckBorder { get; protected set; }
        public GameObject View { get; protected set; }
    }
}