using Asteroids.Core;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private UnitSettings _unitSettings;

        [SerializeField] private Transform _rootUnits;

        private WorldUpdater _worldUpdater;
        private Player _player;

        private void Awake()
        {
            var worldContainer = new WorldContainer();
            _worldUpdater = new WorldUpdater(worldContainer);
            Vector2 viewSize = new Vector2 (_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
            
            CreatePlayer(worldContainer, viewSize);
            var unitFactory = new UnitFactory(_unitSettings, worldContainer, _player.View.transform, viewSize, _rootUnits);
            _player.Initialize(unitFactory);
            CreateEnemies(unitFactory);

            _worldUpdater.Start();
        }

        private void CreatePlayer(WorldContainer worldContainer, Vector2 viewSize)
        {
            var playerInput = new PlayerInputActions();
            _player = new Player(_unitSettings.PlayerConfiguration, worldContainer, playerInput, viewSize);
            _player.View.transform.SetParent(_rootUnits);
            worldContainer.RegisterPlayer(_player);
            _player.DestroyableComponent.Death += OnEndGame;
            playerInput.Enable();
        }

        private void CreateEnemies(UnitFactory unitFactory)
        {
            unitFactory.Create(UnitType.Asteroid);
            unitFactory.Create(UnitType.Asteroid);
            unitFactory.Create(UnitType.Asteroid);
            unitFactory.Create(UnitType.Asteroid);
            unitFactory.Create(UnitType.Ufo);
            unitFactory.Create(UnitType.Ufo);
            unitFactory.Create(UnitType.Ufo);
        }

        private void Update()
        {
            _worldUpdater.Update();
        }

        private void OnEndGame(IDestroyable sender)
        {
            _player.DestroyableComponent.Death -= OnEndGame;
            _worldUpdater.Stop();
            Debug.Log("End game!");
        }
    }
}


    