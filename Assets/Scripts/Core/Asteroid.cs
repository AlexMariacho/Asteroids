using Asteroids.Core.Configuration;
using Asteroids.Unitls;
using UnityEngine;

namespace Asteroids.Core
{
    public class Asteroid : BaseEnemy
    {
        private AsteroidConfiguration _configuration;
        
        public Asteroid(AsteroidConfiguration configuration, Camera camera)
        {
            _configuration = configuration;
            
            View = GameObject.Instantiate(configuration.ViewConfiguration.View);
            MoveComponent = new AsteroidMover(
                View.transform,
                _configuration.MoveConfiguration.Speed,
                RandomHelper.GetRandomPosition(-500, 500, -200, 200),
                Random.Range(0, 360));
            CheckBorder = new StandardCheckBorders(camera, View.transform);
        }

    }
}