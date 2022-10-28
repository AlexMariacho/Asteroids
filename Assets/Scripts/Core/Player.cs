using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Core
{
    public class Player : BaseUnit
    {
        public IWeapon SelectedWeapon;
        
        private IWeapon _primaryWeapon;
        private IWeapon _secondaryWeapon;
        
        private PlayerInputActions _playerInput;
        private PlayerConfiguration _configuration;

        public Player(
            PlayerConfiguration configuration, 
            WorldContainer worldContainer,
            PlayerInputActions playerInput, 
            Vector2 viewSize)
        {
            _configuration = configuration;
            _playerInput = playerInput;
            
            View = GameObject.Instantiate(configuration.UnitConfiguration.View);
            MoveComponent = new PlayerMover(
                playerInput,
                View.transform,
                configuration.UnitConfiguration.Acceleration,
                configuration.UnitConfiguration.RotationSpeed,
                15);
            CheckBorderComponent = new TeleportableBorder(viewSize, View.transform);
            ColliderComponent = new StandardCollider(View.transform, configuration.UnitConfiguration.ColliderSize);
            DestroyableComponent = new StandardDestroy(configuration.UnitConfiguration.Health, View);
            CollisionChecker = new PlayerCollisionChecker(
                worldContainer,
                DestroyableComponent,
                ColliderComponent);
        }

        public void Initialize(UnitFactory factory)
        {
            _primaryWeapon = new DefaultWeapon(_playerInput, View.transform, _configuration.DefaultWeaponConfiguration.FireRate, factory);
            _secondaryWeapon = new LaserWeapon(_playerInput, factory, _configuration.LaserConfiguration);

            SelectedWeapon = _primaryWeapon;
            
            _playerInput.Player.NextWeapon.started += OnChangeWeapon;
        }

        private void OnChangeWeapon(InputAction.CallbackContext obj)
        {
            SelectedWeapon = SelectedWeapon == _primaryWeapon ? _secondaryWeapon : _primaryWeapon;
        }
    }
}