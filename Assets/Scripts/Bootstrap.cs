using System;
using Asteroids.Core;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameSetting _gameSetting;
        [SerializeField] private UnitSetting _unitSetting;
        
        private IUpdater _updater;
        private PlayerInputActions _playerInput;

        private GameManager _gameManager;

        private void Start()
        {
            _playerInput = new PlayerInputActions();
            _updater = new Updater(_gameSetting.FrameRate);

            _gameManager = new GameManager(_updater, _playerInput, _unitSetting);
            _gameManager.Initialize();
        }

        private void OnDestroy()
        {
            _gameManager.Dispose();
        }
    }
}


    