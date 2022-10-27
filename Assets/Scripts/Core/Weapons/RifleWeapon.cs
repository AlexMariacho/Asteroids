using System;
using System.Timers;
using UnityEngine;

namespace Asteroids.Core
{
    public class RifleWeapon : IWeapon, IDisposable
    {
        private PlayerInputActions _playerInput;
        private BulletFactory _bulletFactory;
        private Transform _directionTransform;
        
        private Timer _reloadTimer;
        private bool _isReload;

        public RifleWeapon(PlayerInputActions playerInput, Transform directionTransform, float attackSpeed, BulletFactory bulletFactory)
        {
            _playerInput = playerInput;
            _bulletFactory = bulletFactory;
            _directionTransform = directionTransform;

            _reloadTimer = new Timer(1000 / attackSpeed);
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
                var bullet = _bulletFactory.Create(BulletType.Rifle);
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