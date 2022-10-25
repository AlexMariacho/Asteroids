using Asteroids.Core.Configuration;
using Asteroids.Unitls;
using UnityEngine;

namespace Asteroids.Core
{
    public class Asteroid : BaseEnemy
    {
        private EnemyConfiguration _configuration;
        
        public Asteroid(EnemyConfiguration configuration, Camera camera)
        {
            _configuration = configuration;
            
            View = GameObject.Instantiate(configuration.ViewConfiguration.View);
            MoveComponent = new AsteroidMover(View.transform, _configuration.MoveConfiguration.Speed);
            CheckBorder = new StandardCheckBorders(camera, View.transform);
        }

    }
}