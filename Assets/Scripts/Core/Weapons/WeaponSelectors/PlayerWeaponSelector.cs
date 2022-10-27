using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Asteroids.Core
{
    public class PlayerWeaponSelector : IWeaponSelector, IDisposable
    {
        private readonly List<IWeapon> _weapons;
        private readonly PlayerInputActions _playerInput;
        private IWeapon _selectedWeapon;
        private int _currentIndex;

        public PlayerWeaponSelector(List<IWeapon> weapons, IWeapon selectedWeapon, PlayerInputActions playerInput)
        {
            _weapons = weapons;
            _selectedWeapon = selectedWeapon;
            _playerInput = playerInput;

            if (_weapons.Count > 0)
            {
                _selectedWeapon = _weapons[0];
            }

            _playerInput.Player.NextWeapon.started += OnNextWeapon;
        }

        private void OnNextWeapon(InputAction.CallbackContext obj)
        {
            NextWeapon();
        }

        public void NextWeapon()
        {
            if (_weapons.Count == 0)
            {
                return;
            }
            _currentIndex = _currentIndex + 1 < _weapons.Count ? _currentIndex + 1 : 0;
            _selectedWeapon = _weapons[_currentIndex];
        }

        public void Dispose()
        {
            _playerInput.Player.NextWeapon.started -= OnNextWeapon;
        }
    }
}