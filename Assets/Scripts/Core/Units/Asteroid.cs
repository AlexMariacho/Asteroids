using Asteroids.Unitls;
using UnityEngine;

namespace Asteroids.Core
{
    public class Asteroid : BaseUnit
    {
        public Asteroid(UnitConfiguration configuration, UnitFactory factory, MonoBehaviour view, Vector2 viewSize)
        {
            View = view;
            View.transform.SetRandomBorderPosition(-viewSize.x, viewSize.x, -viewSize.y, viewSize.y);
            View.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
            MoveComponent = new DirectionMover(View.transform, configuration.MoveSpeed);
            CheckBorderComponent = new TeleportableBorder(viewSize, View.transform);
            ColliderComponent = new StandardCollider(View.transform, configuration.ColliderSize);
            DestroyableComponent = new AsteroidDestroy(configuration.Health, factory, view);
            CollisionChecker = new DummyCollisionChecker();
        }

    }
}