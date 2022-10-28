using UnityEngine;

namespace Asteroids.Core
{
    public class StandardCollider : ICollider
    {
        public Transform Transform { get => _transform; }
        public float SizeCollider { get => _sizeCollider; }

        private Transform _transform;
        private float _sizeCollider;

        public StandardCollider(Transform transform, float sizeCollider)
        {
            _transform = transform;
            _sizeCollider = sizeCollider;
        }
    }
}