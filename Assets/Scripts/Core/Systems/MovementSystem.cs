using UnityEngine;

namespace Asteroids.Core
{
    public class MovementSystem : ISystem
    {
        private GameWorld _world;
        
        public void Initialize(GameWorld world)
        {
            _world = world;
        }

        public void Update(float deltaTime)
        {
            var models = _world.GetComponents<MovementComponent, PositionComponent>();
            foreach (var model in models)
            {
                model.Item2.Position = new Vector2(model.Item1.Acceleration * deltaTime,0);
            }
        }

        public void Dispose()
        {
            
        }
    }
}