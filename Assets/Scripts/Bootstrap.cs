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

        private Player _player;

        private void Awake()
        {
            _worldContainer = new WorldContainer();
            _worldUpdater = new WorldUpdater(_worldContainer);
            var playerInput = new PlayerInputActions();
            Vector2 viewSize = new Vector2 (_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
            
            var playerFactory = new PlayerFactory(_unitSettings, _worldContainer, playerInput, viewSize);
            _player = playerFactory.Create(PlayerType.Classic);
            
            var unitFactory = new UnitFactory(_unitSettings, _worldContainer, _player.View.transform, viewSize);
            CreateEnemies(unitFactory);

            playerInput.Enable();
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
        
    }
}


    