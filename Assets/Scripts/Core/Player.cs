using UnityEngine;

namespace Asteroids.Core
{
    public class Player : BaseUnit
    {
        public IWeapon SelectedWeapon;
        
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
            
            var moveConfig = configuration.MoveConfiguration; 
            View = GameObject.Instantiate(configuration.ViewConfiguration.View);
            MoveComponent = new PlayerMover(
                playerInput,
                View.transform,
                moveConfig.Acceleration,
                moveConfig.RotationSpeed,
                15);
            CheckBorderComponent = new StandardCheckBorders(viewSize, View.transform);
            ColliderComponent = new StandardCollider(View.transform, configuration.CollisionConfiguration.SizeCollider);
            DestroyableComponent = new StandardDestroy(configuration.DestroyableConfiguration.Health, View);
            CollisionChecker = new PlayerCollisionChecker(
                worldContainer,
                DestroyableComponent,
                ColliderComponent);
        }

        public void Initialize(UnitFactory factory)
        {
            SelectedWeapon = new LaserWeapon(_playerInput, factory, _configuration.LaserConfiguration);
        }
    }
}