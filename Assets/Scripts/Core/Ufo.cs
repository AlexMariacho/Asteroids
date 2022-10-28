using Asteroids.Unitls;
using UnityEngine;

namespace Asteroids.Core
{
    public class Ufo : BaseUnit
    {
        private readonly Transform _target;

        public Ufo(UnitConfiguration configuration, MonoBehaviour view, Transform target, Vector2 viewSize)
        {
            _target = target;
            View = view;
            View.transform.SetRandomBorderPosition(-viewSize.x, viewSize.x, -viewSize.y, viewSize.y);
            MoveComponent = new ChaserMover(configuration.MoveSpeed, View.transform, _target);
            CheckBorderComponent = new TeleportableBorder(viewSize, View.transform);
            ColliderComponent = new StandardCollider(View.transform, configuration.ColliderSize);
            DestroyableComponent = new StandardDestroy(configuration.Health, view);
            CollisionChecker = new DummyCollisionChecker();
        }
        
    }
}