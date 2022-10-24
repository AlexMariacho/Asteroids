using System;

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
        
        public GameManager(GameSetting gameSetting, FactorySetting factorySetting)
        {
            _gameSetting = gameSetting;
            _factorySetting = factorySetting;
        }

        public void Initialize()
        {
            _updater = new Updater(_gameSetting.FrameRate);
            
            //Подготовка фабрик
            var playerFactory = new PlayerFactory(_factorySetting.PlayerInformations);

            playerFactory.CreateUnit(PlayerType.Classic);
        }

        public void Dispose()
        {
        }
    }
}