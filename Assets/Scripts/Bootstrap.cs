using System;
using Asteroids.Core;
using Asteroids.Core.Factory;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private UnitSettings _unitSettings;
        
        private PlayerInputActions _playerInput;
        private UnitFactory _unitFactory;

        private Player _player;

        private void Awake()
        {
            _playerInput = new PlayerInputActions();
            _unitFactory = new UnitFactory(_unitSettings, _playerInput);

            _player = _unitFactory.Create<Player>(UnitType.Player);

            _playerInput.Enable();
        }

        private void Update()
        {
            _player.MoveComponent.Move();
        }
        
    }
}


    