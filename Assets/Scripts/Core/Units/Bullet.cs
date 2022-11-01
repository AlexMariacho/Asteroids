using Asteroids.Core;
using Asteroids.Settings;
using UnityEngine;

namespace Asteroids.Core
{
    public class Bullet : BaseUnit
    {
        public Bullet(
            RifleWeaponConfiguration configuration, 
            WorldContainer worldContainer, 
            PoolObject<MonoBehaviour> bulletPool, 
            MonoBehaviour view, 
            Vector2 viewSize, 
            float maxDistance)
        {
            View = view;
            DestroyableComponent = new PoolableDestroy(1, bulletPool, View);
            MoveComponent = new DistanceDirectionMover(
                View.transform,
                DestroyableComponent,
                configuration.BulletSpeed,
                maxDistance);
            CheckBorderComponent = new TeleportableBorder(viewSize, View.transform);
            ColliderComponent = new StandardCollider(view.transform, configuration.BulletColliderSize);
            CollisionChecker = new BulletCollisionChecker(worldContainer, ColliderComponent, DestroyableComponent);
        }
    }
}