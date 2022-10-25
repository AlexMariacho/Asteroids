using Asteroids.Core.Configuration;
using Asteroids.Unitls;
using UnityEngine;

namespace Asteroids.Core
{
    public class Asteroid : BaseEnemy
    {
        private EnemyConfiguration _configuration;
        
        public Asteroid(EnemyConfiguration configuration, Vector2 viewSize)
        {
            _configuration = configuration;
            
            View = GameObject.Instantiate(configuration.ViewConfiguration.View);
            View.transform.SetRandomBorderPosition(-viewSize.x, viewSize.x, -viewSize.y, viewSize.y);
            View.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
            MoveComponent = new AsteroidMover(View.transform, _configuration.MoveConfiguration.Speed);
            CheckBorder = new StandardCheckBorders(viewSize, View.transform);
        }

    }
}