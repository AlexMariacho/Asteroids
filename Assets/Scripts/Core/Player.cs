using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Core
{
    public class Player : BaseUnit
    {
        public PlayerInputActions PlayerInput { get; private set; }
        public IWeapon SelectedWeapon;

        private IWeapon _primaryWeapon;
        private IWeapon _secondaryWeapon;

        private PlayerConfiguration _configuration;

        public Player(
            PlayerConfiguration configuration, 
            WorldContainer worldContainer,
            PlayerInputActions playerInput, 
            Vector2 viewSize)
        {
            _configuration = configuration;
            PlayerInput = playerInput;
            
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
            
            PlayerInput.Player.NextWeapon.started += OnChangeWeapon;
        }

        public void SetWeapons(IWeapon primary, IWeapon secondary)
        {
            _primaryWeapon = primary;
            _secondaryWeapon = secondary;

            SelectedWeapon = primary;
        }

        private void OnChangeWeapon(InputAction.CallbackContext obj)
        {
            SelectedWeapon = SelectedWeapon == _primaryWeapon ? _secondaryWeapon : _primaryWeapon;
        }
    }
}