using System.Collections.Generic;

namespace Asteroids.Core
{
    public sealed class GameManager
    {
        private GameWorld _world;
        private UnitBuilder _unitBuilder;
        
        private IUpdater _updater;
        private PlayerInputActions _playerInput;
        private UnitSetting _unitSetting;
        
        private List<ISystem> _systems = new List<ISystem>();

        public GameManager(IUpdater updater, PlayerInputActions playerInput, UnitSetting unitSetting)
        {
            _updater = updater;
            _playerInput = playerInput;
            _unitSetting = unitSetting;
        }

        public void Initialize()
        {
            _world = new GameWorld();
            _unitBuilder = new UnitBuilder(_world, _unitSetting);
            
            CreateFakeData();
            CreateSystems();
            InitializeSystems();
            
            _updater.UpdateEvent += OnUpdate;
            _updater.Start();
        }

        private void CreateFakeData()
        {
            _unitBuilder.CreateUnit(UnitType.Player);
        }

        private void CreateSystems()
        {
            _systems.Add(new PlayerInputSystem(_playerInput));
        }

        private void InitializeSystems()
        {
            foreach (var system in _systems)
            {
                system.Initialize(_world);
            }
        }

        private void OnUpdate()
        {
            for (int i = 0; i < _systems.Count; i++)
            {
                _systems[i].Update();
            }
        }

        public void Dispose()
        {
            _updater.UpdateEvent -= OnUpdate;
            _updater.Stop();

            foreach (var system in _systems)
            {
                system.Dispose();
            }
        }
    }
}