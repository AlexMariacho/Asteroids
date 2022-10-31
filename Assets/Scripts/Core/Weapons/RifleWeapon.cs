using UnityEngine;

namespace Asteroids.Core
{
    public class RifleWeapon : IWeapon
    {
        public bool IsReload { get; private set; }
        
        private PlayerInputActions _playerInput;
        private UnitFactory _unitFactory;
        private Transform _directionTransform;

        private float _currentReloadTime;
        private float _attackSpeed;
        
        public RifleWeapon(PlayerInputActions playerInput, Transform directionTransform, float attackSpeed, UnitFactory unitFactory)
        {
            _playerInput = playerInput;
            _unitFactory = unitFactory;
            _directionTransform = directionTransform;
            _attackSpeed = attackSpeed;
        }
        
        public void Fire()
        {
            CalculateReload();
            TryFire();
        }

        private void CalculateReload()
        {
            _currentReloadTime += Time.deltaTime;
            IsReload = _currentReloadTime < _attackSpeed;
        }

        private void TryFire()
        {
            if (!IsReload && _playerInput.Player.Fire.IsPressed())
            {
                var bullet = _unitFactory.Create(UnitType.Bullet);
                bullet.View.transform.position = _directionTransform.position;
                bullet.View.transform.rotation = Quaternion.Euler(_directionTransform.rotation.eulerAngles);
                _currentReloadTime = 0;
            }
        }
        
    }
}