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

        public void Update()
        {
            var healthModels = _world.GetComponents<HealthComponent>();
            foreach (var healthModel in healthModels)
            {
                if (healthModel.Health <= 0)
                {
                    
                }
            }
        }

        public void Dispose()
        {
        }
    }
}