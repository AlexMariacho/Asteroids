using Asteroids.Core.Configuration;
using UnityEngine;

namespace Asteroids.Core
{
    public class Ufo : BaseEnemy
    {
        private EnemyConfiguration _configuration;
        private Transform _target;

        public Ufo(EnemyConfiguration configuration, Transform target, Camera camera)
        {
            _configuration = configuration;
            _target = target;
            
            View = GameObject.Instantiate(configuration.ViewConfiguration.View);
            MoveComponent = new UfoMover(_configuration.MoveConfiguration.Speed, View.transform, _target);
            CheckBorder = new StandardCheckBorders(camera, View.transform);
        }
        
        
    }
}