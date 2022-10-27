using Asteroids.Core;
using Asteroids.Unitls;
using UnityEngine;

namespace Asteroids.Core
{
    public class Asteroid : BaseUnit
    {
        public Asteroid(EnemyConfiguration configuration, MonoBehaviour view, Vector2 viewSize)
        {
            View = view;
            View.transform.SetRandomBorderPosition(-viewSize.x, viewSize.x, -viewSize.y, viewSize.y);
            View.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
            MoveComponent = new DirectionMover(View.transform, configuration.MoveConfiguration.Speed);
            CheckBorderComponent = new StandardCheckBorders(viewSize, View.transform);
            ColliderComponent = new StandardCollider(View.transform, configuration.CollisionConfiguration.SizeCollider);
            DestroyableComponent = new StandardDestroy(configuration.DestroyableConfiguration.Health, view);
        }

    }
}