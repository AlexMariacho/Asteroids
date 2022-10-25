using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Core.Factory;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private UnitSettings _unitSettings;
        
        private PlayerInputActions _playerInput;
        private UnitFactory _unitFactory;

        private Player _player;
        private BaseEnemy _enemy;

        private void Awake()
        {
            _playerInput = new PlayerInputActions();
            _player = new Player(_unitSettings.PlayerConfiguration, _playerInput, _camera);
            
            _unitFactory = new UnitFactory(_unitSettings, _player.View.transform, _camera);
            _enemy = _unitFactory.Create(UnitType.Asteroid);

            _playerInput.Enable();
        }

        private void Update()
        {
            _player.MoveComponent.Move();
            _enemy.MoveComponent.Move();
            
            _player.CheckBorder.CheckBorder();
            _enemy.CheckBorder.CheckBorder();
        }
        
    }
}


    