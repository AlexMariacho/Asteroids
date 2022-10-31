using Asteroids.Core.Score;
using Asteroids.Core.Views;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Core
{
    public class Player : BaseUnit
    {
        public PlayerInputActions PlayerInput { get; private set; }
        public PlayerScore Score;
        public IWeapon SelectedWeapon;

        public Transform RotationTransform
        {
            get
            {
                var playerView = (PlayerView)View;
                return playerView.View.transform;
            }
        }

        private IWeapon _primaryWeapon;
        private IWeapon _secondaryWeapon;

        public Player(
            PlayerConfiguration configuration, 
            WorldContainer worldContainer,
            PlayerInputActions playerInput, 
            Vector2 viewSize)
        {
            PlayerInput = playerInput;
            
            View = GameObject.Instantiate(configuration.UnitConfiguration.View);
            MoveComponent = new PlayerMover(
                playerInput,
                (PlayerView)View,
                configuration.UnitConfiguration.Acceleration,
                configuration.UnitConfiguration.RotationSpeed);
            CheckBorderComponent = new TeleportableBorder(viewSize, View.transform);
            ColliderComponent = new StandardCollider(View.transform, configuration.UnitConfiguration.ColliderSize);
            DestroyableComponent = new StandardDestroy(configuration.UnitConfiguration.Health, View);
            CollisionChecker = new PlayerCollisionChecker(
                worldContainer,
                DestroyableComponent,
                ColliderComponent);
            Score = new PlayerScore();
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
            if (!SelectedWeapon.IsReload)
            {
                SelectedWeapon = SelectedWeapon == _primaryWeapon ? _secondaryWeapon : _primaryWeapon;
            }
        }
        
    }
}