using System.Linq;
using Asteroids.Core;
using Asteroids.Core.Views;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameHud Hud;
        [SerializeField] private StartGamePanel StartGamePanel;
        [SerializeField] private RestartGamePanel RestartGamePanel;
        
        [Header("General")]
        [SerializeField] private Camera _camera;
        [SerializeField] private UnitSettings _unitSettings;

        [Header("Roots")]
        [SerializeField] private Transform _rootUnits;
        [SerializeField] private Transform _rootBullets;

        private Vector2 _viewSize;
        
        private WorldUpdater _worldUpdater;
        private WorldContainer _worldContainer;
        private Player _player;
        private UnitFactory _unitFactory;

        private LaserWeapon _laserWeapon;

        private void Awake()
        {
            _viewSize = new Vector2 (_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
            
            StartGamePanel.gameObject.SetActive(true);
            StartGamePanel.StartGameClick += OnStartGame;
            RestartGamePanel.StartGameClick += OnStartGame;
        }

        private void OnStartGame()
        {
            _worldContainer = new WorldContainer();
            _worldUpdater = new WorldUpdater(_worldContainer);

            CreatePlayer(_viewSize);
            //CreateEnemies(_viewSize);
            
            Hud.Initialize((PlayerMover)_player.MoveComponent, _laserWeapon);
            StartGamePanel.gameObject.SetActive(false);
            RestartGamePanel.gameObject.SetActive(false);
            Hud.gameObject.SetActive(true);
            
            _worldUpdater.Start();
        }

        private void CreatePlayer(Vector2 viewSize)
        {
            var playerInput = new PlayerInputActions();
            _player = new Player(_unitSettings.PlayerConfiguration, _worldContainer, playerInput, viewSize);
            _player.View.transform.SetParent(_rootUnits);
            _worldContainer.RegisterPlayer(_player);
            _player.DestroyableComponent.Death += OnEndGame;
            _unitFactory = new UnitFactory(_unitSettings, _worldContainer, _player.RotationTransform, viewSize, _rootUnits, _rootBullets);
            var primaryWeapon = new DefaultWeapon(_player.PlayerInput, _player.RotationTransform,
                _unitSettings.PlayerConfiguration.DefaultWeaponConfiguration.FireRate, _unitFactory);
            _laserWeapon = new LaserWeapon(_player.PlayerInput, _unitFactory,
                _unitSettings.PlayerConfiguration.LaserConfiguration);
            _player.SetWeapons(primaryWeapon, _laserWeapon);
            _player.PlayerInput.Enable();
        }

        private void CreateEnemies(Vector2 viewSize)
        {
            _unitFactory.Create(UnitType.Asteroid);
            _unitFactory.Create(UnitType.Asteroid);
            _unitFactory.Create(UnitType.Ufo);
        }

        private void Update()
        {
            if (_worldUpdater != null)
            {
                _worldUpdater.Update();
            }
        }

        private void OnEndGame(IDestroyable sender)
        {
            _worldUpdater.Stop();
            
            var allUnits = _worldContainer.AllUnits.Select(t => t.DestroyableComponent).ToList();
            foreach (var unit in allUnits)
            {
                unit.Destroy();
            }
            
            _player.DestroyableComponent.Death -= OnEndGame;
            _player.PlayerInput.Dispose();

            _worldContainer = null;
            _worldUpdater = null;
            _player = null;
            
            RestartGamePanel.gameObject.SetActive(true);
            Hud.gameObject.SetActive(false);
        }
    }
}


    