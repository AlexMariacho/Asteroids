using System;
using Asteroids.Core.Systems;
using UnityEditor;
using UnityEngine;

namespace Asteroids.Core
{
    public sealed class GameManager : IDisposable
    {
        public event Action StartGame;
        public event Action EndGame;
        
        private GameSetting _gameSetting;
        private FactorySetting _factorySetting;
        
        private IUpdater _updater;
        private PlayerService _playerService;
        private UnitService _unitService;

        private MoveSystem _moveSystem;
        private PlayerInputSystem _playerInputSystem;
        
        
        public GameManager(GameSetting gameSetting, FactorySetting factorySetting)
        {
            _gameSetting = gameSetting;
            _factorySetting = factorySetting;
        }

        public void Initialize()
        {
            _updater = new Updater(_gameSetting.FrameRate);
            _updater.UpdateEvent += OnUpdate;
            
            
            //Подготовка фабрик
            var playerFactory = new PlayerFactory(_factorySetting.PlayerInformations);
            var unitFactory = new UnitFactory(_factorySetting.UnitInformations);
            
            //Подготовка сервисов
            _playerService = new PlayerService(playerFactory);
            _unitService = new UnitService(unitFactory);
            
            //playerFactory.CreateUnit(PlayerType.Classic);
            unitFactory.CreateUnit(UnitType.Asteroid);
            
            //Подготовка систем
            _moveSystem = new MoveSystem();
            _playerInputSystem = new PlayerInputSystem();

            _updater.Start();
        }

        private float _deltaTime = 0.05f;
        
        private void OnUpdate()
        {
            Debug.Log("Update");
            _moveSystem.Run(_unitService.GetElements, _deltaTime);
            _playerInputSystem.Run(_playerService.GetElements, _deltaTime);
        }

        public void Dispose()
        {
            _updater.UpdateEvent -= OnUpdate;
            _updater.Stop();
        }
    }
}