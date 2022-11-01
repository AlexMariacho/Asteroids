using Asteroids.Core;
using Asteroids.Settings;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Core
{
    public class Player : BaseUnit
    {
        public PlayerInputActions PlayerInput { get; private set; }
        public PlayerScore Score { get; private set; }
        public IWeapon SelectedWeapon { get; private set; }

        public Transform RotationTransform
        {
            get
            {
                var playerView = (PlayerView)View;
                return playerView.View.transform;
            }
        }

        public IWeapon RifleWeapon { get; private set; }
        public IWeapon LaserWeapon { get; private set; }

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

        public void SetWeapons(IWeapon rifle, IWeapon laser)
        {
            RifleWeapon = rifle;
            LaserWeapon = laser;

            SelectedWeapon = rifle;
        }

        private void OnChangeWeapon(InputAction.CallbackContext obj)
        {
            if (!SelectedWeapon.IsReload)
            {
                SelectedWeapon = SelectedWeapon == RifleWeapon ? LaserWeapon : RifleWeapon;
            }
        }
        
    }
}