using Asteroids.Core;

namespace Asteroids.Core
{
    public class HealthSystem : ISystem
    {
        private GameWorld _world;

        public void Initialize(GameWorld world)
        {
            _world = world;
        }

        public void Update(float deltaTime)
        {
            
        }

        public void Dispose()
        {
        }
    }
}