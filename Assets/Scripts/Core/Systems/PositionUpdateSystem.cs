using UnityEngine;

namespace Asteroids.Core
{
    public class PositionUpdateSystem : ISystem
    {
        private GameWorld _gameWorld;
        
        public void Initialize(GameWorld world)
        {
            _gameWorld = world;
        }

        public void Update(float deltaTime)
        {
            var models = _gameWorld.GetComponents<PositionComponent, UnitViewComponent>();
            foreach (var model in models)
            {
                Debug.Log("IN");
                // var currentPos = model.Item2.View.transform.position;
                // model.Item2.View.transform.position =
                //     Vector2.MoveTowards(
                //         currentPos, 
                //         model.Item1.Position, 
                //         deltaTime);

                model.Item2.View.transform.position = new Vector2(2, 2);
                Debug.Log("dkfj");
            }
        }

        public void Dispose()
        {
        }
        
    }
}
