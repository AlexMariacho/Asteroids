using System;
using Asteroids.Core;
using Asteroids.Settings;
using UnityEngine;

namespace Asteroids.Core
{
    public class LaserWeapon : IWeapon
    {
        public event Action<int> ChargeEvent;
        public event Action<float> ChargeTimeEvent;

        public bool IsReload { get; private set; }
        private PlayerInputActions _playerInput;
        private UnitFactory _unitFactory;
        
        private float _reloadTime;
        private float _currentReload;

        public int CurrentCharges { get; private set; }
        private int _maxCharges;
        private float _chargeReloadTime;
        private float _currentReloadCharge;

        private float _fireTime;
        private float _currentFireTime;
        private BaseUnit _activeLaser;


        public LaserWeapon(PlayerInputActions playerInput, UnitFactory unitFactory, LaserConfiguration configuration)
        {
            _playerInput = playerInput;
            _unitFactory = unitFactory;

            _reloadTime = configuration.ReloadTime;
            _maxCharges = configuration.ChargeCount;
            CurrentCharges = _maxCharges;
            _chargeReloadTime = configuration.ChargeReloadTime;

            _fireTime = configuration.FireTime;
            _currentReload = _reloadTime;
        }

        public void Fire()
        {
            CalculateReload();
            CalculateCharge();
            CheckActiveLaser();
            
            if (!IsReload && 
                CurrentCharges > 0 &&
                _playerInput.Player.Fire.IsPressed())
            {
                CurrentCharges--;
                _currentReload = 0;
                ChargeEvent?.Invoke(CurrentCharges);
                
                _activeLaser = _unitFactory.Create(UnitType.Laser);
            }
        }

        private void CalculateReload()
        {
            _currentReload += Time.deltaTime;
            IsReload = _currentReload < _reloadTime;
        }

        private void CalculateCharge()
        {
            if (CurrentCharges == _maxCharges)
            {
                _currentReloadCharge = 0;
                return;
            }

            _currentReloadCharge += Time.deltaTime;
            ChargeTimeEvent?.Invoke(_currentReloadCharge / _chargeReloadTime);
            if (_currentReloadCharge > _chargeReloadTime)
            {
                CurrentCharges = Math.Min(CurrentCharges + 1, _maxCharges);
                _currentReloadCharge = 0;
                ChargeTimeEvent?.Invoke(1);
                ChargeEvent?.Invoke(CurrentCharges);
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
                    _activeLaser.DestroyableComponent.Destroy();
                    _activeLaser = null;
                }
            }
        }

    }
}