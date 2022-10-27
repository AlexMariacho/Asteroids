using UnityEngine;

namespace Asteroids.Core
{
    public class DirectionMover : IMove
    {
        private Transform _transform;
        private float _speed;

        public DirectionMover(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move()
        {
            _transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
    }
}