using Asteroids.Core.Configuration;
using Asteroids.Unitls;
using UnityEngine;

namespace Asteroids.Core
{
    public class Ufo : BaseEnemy
    {
        private EnemyConfiguration _configuration;
        private Transform _target;

        public Ufo(EnemyConfiguration configuration, Transform target, Vector2 viewSize)
        {
            _configuration = configuration;
            _target = target;
            
            View = GameObject.Instantiate(configuration.ViewConfiguration.View);
            View.transform.SetRandomBorderPosition(-viewSize.x, viewSize.x, -viewSize.y, viewSize.y);
            MoveComponent = new UfoMover(_configuration.MoveConfiguration.Speed, View.transform, _target);
            CheckBorder = new StandardCheckBorders(viewSize, View.transform);
        }
        
    }
}