using Asteroids.Core;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameSetting _gameSetting;
        [SerializeField] private FactorySetting _factorySetting;

        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = new GameManager(_gameSetting, _factorySetting);
            _gameManager.Initialize();
        }

        private void OnDestroy()
        {
            _gameManager.Dispose();
        }
    }
}


    