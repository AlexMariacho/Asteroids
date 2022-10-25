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
        private BaseEnemy _ufo;

        private void Awake()
        {
            _playerInput = new PlayerInputActions();
            Vector2 viewSize = new Vector2 (_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
            _player = new Player(_unitSettings.PlayerConfiguration, _playerInput, viewSize);

            _unitFactory = new UnitFactory(_unitSettings, _player.View.transform, viewSize);
            _enemy = _unitFactory.Create(UnitType.Asteroid);
            _ufo = _unitFactory.Create(UnitType.Ufo);
            
            _playerInput.Enable();
        }

        private void Update()
        {
            _player.MoveComponent.Move();
            _enemy.MoveComponent.Move();
            _ufo.MoveComponent.Move();
            
            _player.CheckBorder.CheckBorder();
            _enemy.CheckBorder.CheckBorder();
            _ufo.CheckBorder.CheckBorder();
        }
        
    }
}


    