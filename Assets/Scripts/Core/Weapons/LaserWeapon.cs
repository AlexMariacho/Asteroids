using System;
using Asteroids.Core.Weapons;
using UnityEngine;

namespace Asteroids.Core
{
    public class LaserWeapon : IWeapon
    {
        private PlayerInputActions _playerInput;
        private UnitFactory _unitFactory;

        private bool _isReload;
        private float _reloadTime;
        private float _currentReload;
        
        private int _maxCharges;
        private int _currentCharges;
        private float _chargeReloadTime;
        private float _currentReloadCharge;

        public LaserWeapon(PlayerInputActions playerInput, UnitFactory unitFactory, LaserConfiguration configuration)
        {
            _playerInput = playerInput;
            _unitFactory = unitFactory;

            _reloadTime = configuration.ReloadTime;
            _maxCharges = configuration.ChargeCount;
            _chargeReloadTime = configuration.ChargeReloadTime;
        }

        public void Fire()
        {
            CalculateReload();
            CalculateCharge();
            
            if (!_isReload && 
                _currentCharges > 0 &&
                _playerInput.Player.Fire.IsPressed())
            {
                _currentCharges--;
                _currentReload = 0;
                
                var laser = _unitFactory.Create(UnitType.Laser);
            }
        }

        private void CalculateReload()
        {
            _currentReload += Time.deltaTime;
            _isReload = !(_currentReload > _reloadTime);
        }

        private void CalculateCharge()
        {
            _currentReloadCharge += Time.deltaTime;
            if (_currentReloadCharge > _chargeReloadTime)
            {
                _currentCharges = Math.Min(_currentCharges + 1, _maxCharges);
                _currentReloadCharge = 0;
            }
        }

    }
}