using System;
using UnityEngine;

namespace Asteroids.Core
{
    public class PlayerMover : IMove
    {
        public event Action<Vector3> PositionChange;
        public event Action<Vector3> RotationChange;
        public event Action<float> SpeedChange; 

        private PlayerInputActions _playerInput;
        private Transform _transform;
        
        private float _acceleration;
        private float _rotationSpeed;
        private float _maxSpeed;
        private float _speed;

        public PlayerMover(PlayerInputActions playerInput, Transform transform, float acceleration, float rotationSpeed, float maxSpeed)
        {
            _playerInput = playerInput;
            _transform = transform;
            _acceleration = acceleration;
            _rotationSpeed = rotationSpeed;
            _maxSpeed = maxSpeed;
        }
        
        public void Move()
        {
            CalculateRotation();
            CalculateSpeed();
            
            _transform.Translate(Vector3.up * _speed * Time.deltaTime);
            PositionChange?.Invoke(_transform.position);
        }

        private void CalculateRotation()
        {
            var newRotation = _playerInput.Player.Rotate.ReadValue<Vector2>();
            if (_playerInput.Player.Rotate.IsPressed())
            {
                if (newRotation.x > 0)
                {
                    _transform.Rotate(new Vector3(0, 0, -_rotationSpeed * Time.deltaTime));
                }
                else
                {
                    _transform.Rotate(new Vector3(0, 0, _rotationSpeed * Time.deltaTime));
                }
            }
            RotationChange?.Invoke(_transform.rotation.eulerAngles);
        }

        private void CalculateSpeed()
        {
            if (_playerInput.Player.Acceleration.IsPressed())
            {
                _speed = Math.Min(_speed + _acceleration, _maxSpeed);
            }
            else
            {
                _speed = Math.Max(_speed - _acceleration, 0);
            }
            SpeedChange?.Invoke(_speed);
        }
    }
}