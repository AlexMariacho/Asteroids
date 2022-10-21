using System.Collections.Generic;

namespace Asteroids.Core
{
    public sealed class GameManager
    {
        private GameWorld _world;
        
        private IUpdater _updater;
        private PlayerInputActions _playerInput;
        
        private List<ISystem> _systems = new List<ISystem>();

        public GameManager(IUpdater updater, PlayerInputActions playerInput)
        {
            _updater = updater;
            _playerInput = playerInput;
        }

        public void Initialize()
        {
            _world = new GameWorld();
            
            CreateFakeData();
            CreateSystems();
            InitializeSystems();
            
            _updater.UpdateEvent += OnUpdate;
            _updater.Start();
        }

        private void CreateFakeData()
        {
            var entity = _world.GetEntity();
            var moveModel = new MovementComponent();
            var moveModel2 = new MovementComponent();
            _world.AddComponent(entity, moveModel);
            entity.AddComponent(_world, moveModel2);
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

        public void Dispose()
        {
            _updater.UpdateEvent -= OnUpdate;
            _updater.Stop();

            foreach (var system in _systems)
            {
                system.Dispose();
            }
        }

        private void OnUpdate()
        {
            for (int i = 0; i < _systems.Count; i++)
            {
                _systems[i].Update();
            }
        }
        
    }
}