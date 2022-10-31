using System;
using System.Timers;
using UnityEngine;

namespace Asteroids.Core
{
    public class DefaultWeapon : IWeapon, IDisposable
    {
        private PlayerInputActions _playerInput;
        private UnitFactory _unitFactory;
        private Transform _directionTransform;
        
        private Timer _reloadTimer;
        private bool _isReload;

        public DefaultWeapon(PlayerInputActions playerInput, Transform directionTransform, float attackSpeed, UnitFactory unitFactory)
        {
            _playerInput = playerInput;
            _unitFactory = unitFactory;
            _directionTransform = directionTransform;

            _reloadTimer = new Timer(attackSpeed * 1000);
            _reloadTimer.Elapsed += OnReloadReady;
        }

        private void OnReloadReady(object sender, ElapsedEventArgs e)
        {
            _isReload = false;
        }

        public void Fire()
        {
            if (!_isReload && _playerInput.Player.Fire.IsPressed())
            {
                var bullet = _unitFactory.Create(UnitType.Bullet);
                bullet.View.transform.position = _directionTransform.position;
                bullet.View.transform.rotation = Quaternion.Euler(_directionTransform.rotation.eulerAngles);
                _reloadTimer.Start();
                _isReload = true;
            }
        }

        public void Dispose()
        {
            _reloadTimer?.Dispose();
        }
    }
}