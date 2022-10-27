using UnityEngine;

namespace Asteroids.Core
{
    public class DistanceDirectionMover : IMove
    {
        private Transform _transform;
        private float _speed;
        private float _maxDistance;
        private float _currentDistance;
        private IDestroyable _destroyable;

        public DistanceDirectionMover(Transform transform, IDestroyable destroyable, float speed, float maxDistance)
        {
            _transform = transform;
            _speed = speed;
            _destroyable = destroyable;
            _maxDistance = maxDistance;
        }

        public void Move()
        {
            _transform.Translate(Vector3.up * _speed * Time.deltaTime);
            _currentDistance += _speed * Time.deltaTime;
            if (_currentDistance >= _maxDistance)
            {
                _destroyable.TakeDamage();
            }
        }
    }
}