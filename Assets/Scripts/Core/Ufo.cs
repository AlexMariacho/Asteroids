using Asteroids.Core;
using Asteroids.Unitls;
using UnityEngine;

namespace Asteroids.Core
{
    public class Ufo : BaseUnit
    {
        private readonly Transform _target;

        public Ufo(EnemyConfiguration configuration, MonoBehaviour view, Transform target, Vector2 viewSize)
        {
            _target = target;
            View = view;
            View.transform.SetRandomBorderPosition(-viewSize.x, viewSize.x, -viewSize.y, viewSize.y);
            MoveComponent = new ChaserMover(configuration.MoveConfiguration.Speed, View.transform, _target);
            CheckBorderComponent = new StandardCheckBorders(viewSize, View.transform);
            ColliderComponent = new StandardCollider(View.transform, configuration.CollisionConfiguration.SizeCollider);
            DestroyableComponent = new StandardDestroy(configuration.DestroyableConfiguration.Health, view);
        }
        
    }
}