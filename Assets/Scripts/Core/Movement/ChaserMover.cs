using UnityEngine;

namespace Asteroids.Core
{
    public class ChaserMover : IMove
    {
        private float _speed;
        private Transform _transform;
        private Transform _target;

        public ChaserMover(float speed, Transform transform, Transform target)
        {
            _speed = speed;
            _transform = transform;
            _target = target;
        }

        public void Move()
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position, 
                _target.position, 
                _speed * Time.deltaTime);
        }
    }
}