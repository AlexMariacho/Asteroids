using UnityEngine;

namespace Asteroids.Core
{
    public class RifleBullet : BaseBullet
    {
        public RifleBullet(BulletConfiguration configuration, MonoBehaviour view, Vector2 viewSize, float maxDistance)
        {
            View = view;
            Destroyable = new StandardDestroyable(configuration.DestroyableConfiguration.Health);
            MoveComponent = new DistanceDirectionMover(
                View.transform,
                Destroyable,
                configuration.MoveConfiguration.Speed,
                maxDistance);
            CheckBorder = new StandardCheckBorders(viewSize, View.transform);
        }
    }
}