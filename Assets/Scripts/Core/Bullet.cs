using Asteroids.Core.Common;
using UnityEngine;

namespace Asteroids.Core
{
    public class Bullet : BaseUnit
    {
        public Bullet(
            BulletConfiguration configuration, 
            WorldContainer worldContainer, 
            PoolObject<MonoBehaviour> bulletPool, 
            MonoBehaviour view, 
            Vector2 viewSize, 
            float maxDistance)
        {
            View = view;
            DestroyableComponent = new PoolableDestroy(configuration.DestroyableConfiguration.Health, bulletPool, View);
            MoveComponent = new DistanceDirectionMover(
                View.transform,
                DestroyableComponent,
                configuration.MoveConfiguration.Speed,
                maxDistance);
            CheckBorderComponent = new TeleportableBorder(viewSize, View.transform);
            ColliderComponent = new StandardCollider(view.transform, configuration.CollisionConfiguration.SizeCollider);
            CollisionChecker = new BulletCollisionChecker(worldContainer, ColliderComponent, DestroyableComponent);
        }
    }
}