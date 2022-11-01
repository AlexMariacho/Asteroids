using System.Collections;
using System.Linq;
using Asteroids.Core;
using Asteroids.Settings;
using Asteroids.Ui;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [Header("UI")] 
        [SerializeField] private UiContext _uiContext;
        
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

        private void Awake()
        {
            _viewSize = new Vector2 (_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
            _uiContext.ShowStartGamePanel();
            _uiContext.StartGame += OnStartGame;
        }

        private void OnStartGame()
        {
            _worldContainer = new WorldContainer();
            _worldUpdater = new WorldUpdater(_worldContainer);

            CreatePlayer(_viewSize);
            StartCoroutine(CreateEnemies());
            
            _uiContext.Initialize((PlayerMover)_player.MoveComponent, (LaserWeapon)_player.LaserWeapon);
            _uiContext.ShowGameHud();
            _worldUpdater.Start();
        }

        private void CreatePlayer(Vector2 viewSize)
        {
            var playerInput = new PlayerInputActions();
            _player = new Player(_unitSettings.PlayerConfiguration, _worldContainer, playerInput, viewSize);
            _player.View.transform.SetParent(_rootUnits);
            _worldContainer.RegisterPlayer(_player);
            _player.DestroyableComponent.Death += OnEndGame;
            
            _unitFactory = new UnitFactory(_unitSettings, _worldContainer, viewSize, _rootUnits, _rootBullets);
            
            var rifleWeapon = new RifleWeapon(_player.PlayerInput, _player.RotationTransform,
                _unitSettings.PlayerConfiguration._rifleWeaponConfiguration.FireRate, _unitFactory);
            var laserWeapon = new LaserWeapon(_player.PlayerInput, _unitFactory,
                _unitSettings.PlayerConfiguration.LaserConfiguration);
            
            _player.SetWeapons(rifleWeapon, laserWeapon);
            _player.PlayerInput.Enable();
        }

        private IEnumerator CreateEnemies()
        {
            while (true)
            {
                CreateEnemyWave();
                yield return new WaitForSeconds(5);
            }
        }

        private void CreateEnemyWave()
        {
            _unitFactory.Create(UnitType.Asteroid);
            _unitFactory.Create(UnitType.Asteroid);
            _unitFactory.Create(UnitType.Ufo);
        }

        private void Update()
        {
            _worldUpdater?.Update();
        }

        private void OnEndGame(IDestroyable sender)
        {
            _worldUpdater.Stop();
            var score = _player.Score;
            _uiContext.ShowRestartGamePanel(score.CurrentScore);
            
            _player.DestroyableComponent.Death -= OnEndGame;
            _player.PlayerInput.Dispose();
            _worldContainer.Dispose();
            _unitFactory.Dispose();
            
            StopAllCoroutines();
        }

        private void OnDestroy()
        {
            _uiContext.StartGame -= OnStartGame;
        }
        
    }
}


    