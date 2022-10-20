using System;
using Asteroids.Core;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameSetting _gameSetting;
        
        private IUpdater _updater;
        private PlayerInputActions _playerInput;

        private GameManager _gameManager;

        private void Awake()
        {
            _playerInput = new PlayerInputActions();
            _updater = new Updater(_gameSetting.FrameRate);

            _gameManager = new GameManager(_updater, _playerInput);
            _gameManager.Initialize();
        }

        private void OnDestroy()
        {
            _gameManager.Dispose();
        }
    }
}


    