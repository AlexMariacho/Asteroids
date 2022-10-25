using Asteroids.Core.Configuration;
using Asteroids.Unitls;
using UnityEngine;

namespace Asteroids.Core
{
    public class Ufo : BaseEnemy
    {
        private readonly Transform _target;

        public Ufo(EnemyConfiguration configuration, Transform target, Vector2 viewSize)
        {
            _target = target;
            
            View = GameObject.Instantiate(configuration.ViewConfiguration.View);
            View.transform.SetRandomBorderPosition(-viewSize.x, viewSize.x, -viewSize.y, viewSize.y);
            MoveComponent = new UfoMover(configuration.MoveConfiguration.Speed, View.transform, _target);
            CheckBorder = new StandardCheckBorders(viewSize, View.transform);
        }
        
    }
}