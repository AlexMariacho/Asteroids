using UnityEngine;

namespace Asteroids.Core
{
    public class AsteroidMover : IMove
    {
        private Transform _transform;
        private float _speed;

        public AsteroidMover(Transform transform, float speed, Vector2 startPosition, float startRotation)
        {
            _transform = transform;
            _speed = speed;

            transform.position = startPosition;
            transform.rotation = Quaternion.Euler(0, 0, startRotation);
        }

        public void Move()
        {
            _transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
    }
}