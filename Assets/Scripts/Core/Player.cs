using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Core
{
    public class Player : BaseUnit
    {
        public readonly IWeapon SelectedWeapon;
        public readonly ICollisionChecker CollisionChecker;

        public Player(PlayerConfiguration configuration, WorldContainer worldContainer, BulletFactory bulletFactory, PlayerInputActions playerInput, Vector2 viewSize)
        {
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

            SelectedWeapon = new RifleWeapon(playerInput, View.transform,
                configuration.RifleWeaponConfiguration.FireRate, bulletFactory);
        }
    }
}