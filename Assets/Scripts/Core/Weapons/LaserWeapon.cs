using System.Timers;
using UnityEngine;

namespace Asteroids.Core
{
    public class LaserWeapon : IWeapon
    {
        private PlayerInputActions _playerInput;
        private Transform _directionTransform;
        
        private Timer _reloadTimer;
        private bool _isReload;
        private Timer _chargesTimer;
        private int _maxCharges;
        private int _currentCharges;

        private void OnReloadReady(object sender, ElapsedEventArgs e)
        {
            _isReload = false;
        }

        public void Fire()
        {
            // if (!_isReload && _playerInput.Player.Fire.IsPressed())
            // {
            //     var bullet = _bulletFactory.Create(BulletType.Rifle);
            //     
            //     
            //     
            //     bullet.View.transform.position = _directionTransform.position;
            //     bullet.View.transform.rotation = Quaternion.Euler(_directionTransform.rotation.eulerAngles);
            //     _reloadTimer.Start();
            //     _isReload = true;
            // }
        }

        public void Dispose()
        {
            _reloadTimer?.Dispose();
        }
    }
}