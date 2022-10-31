using UnityEngine;

namespace Asteroids.Core
{
    public class SmallAsteroid : BaseUnit
    {
        public SmallAsteroid(UnitConfiguration configuration, MonoBehaviour view, Vector2 viewSize)
        {
            View = view;
            View.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
            MoveComponent = new DirectionMover(View.transform, configuration.MoveSpeed);
            CheckBorderComponent = new TeleportableBorder(viewSize, View.transform);
            ColliderComponent = new StandardCollider(View.transform, configuration.ColliderSize);
            DestroyableComponent = new StandardDestroy(configuration.Health, view);
            CollisionChecker = new DummyCollisionChecker();
        }
    }
}