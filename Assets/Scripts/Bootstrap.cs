using Asteroids.Core;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private UnitSettings _unitSettings;

        [SerializeField] private Transform _rootUnits;
        [SerializeField] private Transform _rootBullets;

        private WorldUpdater _worldUpdater;
        private Player _player;

        private void Awake()
        {
            var worldContainer = new WorldContainer();
            _worldUpdater = new WorldUpdater(worldContainer);
            var playerInput = new PlayerInputActions();
            Vector2 viewSize = new Vector2 (_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);

            var bulletFactory = new BulletFactory(_unitSettings, worldContainer, viewSize, _rootBullets);
            _player = new Player(_unitSettings.PlayerConfiguration, worldContainer, bulletFactory, playerInput, viewSize);
            worldContainer.RegisterPlayer(_player);
            _player.DestroyableComponent.Death += OnEndGame;
            
            var unitFactory = new UnitFactory(_unitSettings, worldContainer, _player.View.transform, viewSize, _rootUnits);
            CreateEnemies(unitFactory);

            playerInput.Enable();
            _worldUpdater.Start();
        }

        private void CreateEnemies(UnitFactory unitFactory)
        {
            unitFactory.Create(UnitType.Asteroid);
            unitFactory.Create(UnitType.Asteroid);
            unitFactory.Create(UnitType.Ufo);
        }

        private void Update()
        {
            _worldUpdater.Update();
        }

        private void OnEndGame(IDestroyable sender)
        {
            _worldUpdater.Stop();
            Debug.Log("End game!");
        }
    }
}


    