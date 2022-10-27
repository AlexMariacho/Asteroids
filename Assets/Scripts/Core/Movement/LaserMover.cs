using UnityEngine;

namespace Asteroids.Core
{
    public class LaserMover : IMove
    {
        private Transform _ownerTransform;
        private Transform _selfTransform;

        public LaserMover(Transform ownerTransform, Transform selfTransform)
        {
            _ownerTransform = ownerTransform;
            _selfTransform = selfTransform;
        }

        public void Move()
        {
            _selfTransform.position = _ownerTransform.position;
            _selfTransform.rotation = _ownerTransform.rotation;
        }
    }
}