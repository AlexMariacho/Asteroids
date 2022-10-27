using Asteroids.Core.Common;
using UnityEngine;

namespace Asteroids.Core
{
    public class RifleBullet : BaseBullet
    {
        public RifleBullet(
            BulletConfiguration configuration, 
            WorldContainer worldContainer, 
            PoolObject<MonoBehaviour> bulletPool, 
            MonoBehaviour view, 
            Vector2 viewSize, 
            float maxDistance)
        {
            View = view;
            Destroyable = new PoolableDestroy(configuration.DestroyableConfiguration.Health, bulletPool, View);
            MoveComponent = new DistanceDirectionMover(
                View.transform,
                Destroyable,
                configuration.MoveConfiguration.Speed,
                maxDistance);
            CheckBorder = new StandardCheckBorders(viewSize, View.transform);
            Collider = new StandardCollider(view.transform, configuration.CollisionConfiguration.SizeCollider);
            CollisionChecker = new BulletCollisionChecker(worldContainer, Collider, Destroyable);
        }
    }
}