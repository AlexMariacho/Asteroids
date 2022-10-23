using Asteroids.Core;
using UnityEngine;

namespace Asteroids.Core
{
    public class PlayerInputSystem : ISystem
    {
        private GameWorld _world;
        private PlayerInputActions _playerInput;

        public PlayerInputSystem(PlayerInputActions playerInput)
        {
            _playerInput = playerInput;
        }

        public void Initialize(GameWorld world)
        {
            _world = world;
            _playerInput.Enable();
        }

        public void Update(float deltaTime)
        {
            var models = _world.GetComponents<MovementComponent, PlayerMarker>();
            
            if (_playerInput.Player.Acceleration.IsPressed())
            {
                foreach (var model in models)
                {
                    model.Item1.Acceleration += 5 * deltaTime;
                    Debug.Log($"Acceleration TRUE / Value:{model.Item1.Acceleration}");
                }
            }
            else
            {
                foreach (var model in models)
                {
                    model.Item1.Acceleration -= 2 * deltaTime;
                    if (model.Item1.Acceleration <= 0)
                    {
                        model.Item1.Acceleration = 0;
                    }
                    Debug.Log($"Acceleration TRUE / Value:{model.Item1.Acceleration}");
                }
            }
        }

        public void Dispose()
        {
            _playerInput.Disable();
        }
    }
}