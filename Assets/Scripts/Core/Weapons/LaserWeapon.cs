using System;
using Asteroids.Core.Weapons;
using UnityEngine;

namespace Asteroids.Core
{
    public class LaserWeapon : IWeapon
    {
        private PlayerInputActions _playerInput;
        private UnitFactory _unitFactory;
        private WorldContainer _worldContainer;

        private bool _isReload;
        private float _reloadTime;
        private float _currentReload;
        
        private int _maxCharges;
        private int _currentCharges;
        private float _chargeReloadTime;
        private float _currentReloadCharge;

        private float _fireTime;
        private float _currentFireTime;
        private BaseUnit _activeLaser;
        
        public LaserWeapon(PlayerInputActions playerInput, WorldContainer worldContainer, UnitFactory unitFactory, LaserConfiguration configuration)
        {
            _worldContainer = worldContainer;
            _playerInput = playerInput;
            _unitFactory = unitFactory;

            _reloadTime = configuration.ReloadTime;
            _maxCharges = configuration.ChargeCount;
            _currentCharges = _maxCharges;
            _chargeReloadTime = configuration.ChargeReloadTime;

            _fireTime = configuration.FireTime;
        }

        public void Fire()
        {
            CalculateReload();
            CalculateCharge();
            CheckActiveLaser();
            
            if (!_isReload && 
                _currentCharges > 0 &&
                _playerInput.Player.Fire.IsPressed())
            {
                _currentCharges--;
                _currentReload = 0;

                _activeLaser = _unitFactory.Create(UnitType.Laser);
            }
            
            Debug.Log($"IsReload: {_isReload}, Charges: {_currentCharges}");
        }

        private void CalculateReload()
        {
            _currentReload += Time.deltaTime;
            _isReload = _currentReload < _reloadTime;
        }

        private void CalculateCharge()
        {
            if (_currentCharges == _maxCharges)
            {
                _currentReloadCharge = 0;
                return;
            }

            _currentReloadCharge += Time.deltaTime;
            if (_currentReloadCharge > _chargeReloadTime)
            {
                _currentCharges = Math.Min(_currentCharges + 1, _maxCharges);
                _currentReloadCharge = 0;
            }
        }

        private void CheckActiveLaser()
        {
            if (_activeLaser != null)
            {
                _currentFireTime += Time.deltaTime;
                if (_currentFireTime > _fireTime)
                {
                    _currentFireTime = 0;
                    _worldContainer.UnRegisterUnit(_activeLaser);
                    _activeLaser.DestroyableComponent.Destroy();
                    _activeLaser = null;
                }
            }
        }

    }
}