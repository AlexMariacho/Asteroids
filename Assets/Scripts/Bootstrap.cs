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

        private WorldUpdater _worldUpdater;
        private WorldContainer _worldContainer;
        
        private PlayerInputActions _playerInput;
        private UnitFactory _unitFactory;
        private PlayerFactory _playerFactory;

        private Player _player;

        private void Awake()
        {
            _worldContainer = new WorldContainer();
            _worldUpdater = new WorldUpdater(_worldContainer);
            _playerInput = new PlayerInputActions();
            Vector2 viewSize = new Vector2 (_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
            
            _playerFactory = new PlayerFactory(_unitSettings, _worldContainer, _playerInput, viewSize);
            _player = _playerFactory.Create(PlayerType.Classic);
            
            _unitFactory = new UnitFactory(_unitSettings, _worldContainer, _player.View.transform, viewSize);
            _unitFactory.Create(UnitType.Asteroid);
            _unitFactory.Create(UnitType.Ufo);
            
            _playerInput.Enable();
        }

        private void Update()
        {
            _worldUpdater.Update();
        }
        
    }
}


    