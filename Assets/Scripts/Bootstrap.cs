using Asteroids.Core;
using Asteroids.Core.Views;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameHud Hud;
        
        [SerializeField] private Camera _camera;
        [SerializeField] private UnitSettings _unitSettings;

        [SerializeField] private Transform _rootUnits;
        [SerializeField] private Transform _rootBullets;

        private WorldUpdater _worldUpdater;
        private WorldContainer _worldContainer;
        private Player _player;
        private UnitFactory _unitFactory;

        private void Awake()
        {
            _worldContainer = new WorldContainer();
            _worldUpdater = new WorldUpdater(_worldContainer);
            Vector2 viewSize = new Vector2 (_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
            
            CreatePlayer(viewSize);
            CreateEnemies(viewSize);

            var primaryWeapon = new DefaultWeapon(_player.PlayerInput, _player.View.transform,
                _unitSettings.PlayerConfiguration.DefaultWeaponConfiguration.FireRate, _unitFactory);
            var secondaryWeapon = new LaserWeapon(_player.PlayerInput, _unitFactory,
                _unitSettings.PlayerConfiguration.LaserConfiguration);
            _player.SetWeapons(primaryWeapon, secondaryWeapon);
            Hud.Initialize((PlayerMover)_player.MoveComponent, secondaryWeapon);
            
            _worldUpdater.Start();
        }

        private void CreatePlayer(Vector2 viewSize)
        {
            var playerInput = new PlayerInputActions();
            _player = new Player(_unitSettings.PlayerConfiguration, _worldContainer, playerInput, viewSize);
            _player.View.transform.SetParent(_rootUnits);
            _worldContainer.RegisterPlayer(_player);
            _player.DestroyableComponent.Death += OnEndGame;
            playerInput.Enable();
        }

        private void CreateEnemies(Vector2 viewSize)
        {
            _unitFactory = new UnitFactory(_unitSettings, _worldContainer, _player.View.transform, viewSize, _rootUnits, _rootBullets);
            _unitFactory.Create(UnitType.Asteroid);
            _unitFactory.Create(UnitType.Asteroid);
            _unitFactory.Create(UnitType.Ufo);
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


    