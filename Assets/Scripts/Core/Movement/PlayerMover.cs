using System;
using System.Collections.Generic;
using System.Timers;
using Asteroids.Core.Views;
using UnityEditor;
using UnityEngine;

namespace Asteroids.Core
{
    public class PlayerMover : IMove
    {
        public event Action<Vector3> PositionChange;
        public event Action<Vector3> RotationChange;
        public event Action<float> SpeedChange; 

        private PlayerInputActions _playerInput;
        private PlayerView _playerView;
        
        private float _acceleration;
        private float _rotationSpeed;
        private float _speed;
        private float _angle;
        
        private List<Inercions> _inercions = new List<Inercions>();
        
        public class Inercions
        {
            public float Distance;
            public float Angle;
            public int LifeTime;

            public Inercions(float distance, float angle, int lifeTime)
            {
                Distance = distance;
                Angle = angle;
                LifeTime = lifeTime;
            }
        }
        
        public PlayerMover(PlayerInputActions playerInput, PlayerView playerView, float acceleration, float rotationSpeed)
        {
            _playerInput = playerInput;
            _playerView = playerView;
            _acceleration = acceleration;
            _rotationSpeed = rotationSpeed;
        }
        
        public void Move()
        {
            CalculateRotation();
            CalculateAccelerations();
            CalculateMove();
            CalculateSpeed();
            
            PositionChange?.Invoke(_playerView.transform.position);
        }

        private void CalculateRotation()
        {
            var newRotation = _playerInput.Player.Rotate.ReadValue<Vector2>();
            if (_playerInput.Player.Rotate.IsPressed())
            {
                _playerView.View.transform.Rotate(newRotation.x > 0
                    ? new Vector3(0, 0, -_rotationSpeed * Time.deltaTime)
                    : new Vector3(0, 0, _rotationSpeed * Time.deltaTime));
            }
            RotationChange?.Invoke(_playerView.View.rotation.eulerAngles);
        }

        private void CalculateAccelerations()
        {
            if (_playerInput.Player.Acceleration.IsPressed())
            {
                _angle = _playerView.View.transform.rotation.eulerAngles.z;
                _angle = _angle * 0.0174533f;
                _inercions.Add(new Inercions(_acceleration / 100, _angle, 500));
            }
        }

        private void CalculateMove()
        {
            for (int i = 0; i < _inercions.Count; i++)
            {
                Move(_inercions[i].Distance, _inercions[i].Angle);
                _inercions[i].LifeTime--;
            }

            _inercions.RemoveAll(e => e.LifeTime <= 0);
        }

        private void Move(float distance, float angle)
        {
            var targetPosition = new Vector2(
                -Mathf.Sin(angle) * distance + _playerView.transform.position.x, 
                Mathf.Cos(angle) * distance + _playerView.transform.position.y);
            _playerView.transform.position = targetPosition;
        }

        private void CalculateSpeed()
        {
            _speed = GetSpeed() * 100;
            SpeedChange?.Invoke(_speed);
        }

        private float GetSpeed()
        {
            float result = 0;
            foreach (var inercion in _inercions)
            {
                result += inercion.Distance;
            }
            return result;
        }
    }
}