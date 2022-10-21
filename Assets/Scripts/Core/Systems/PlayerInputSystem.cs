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

        public void Update()
        {
            if (_playerInput.Player.Acceleration.IsPressed())
            {
                var models = _world.GetComponents<MovementComponent>();
                foreach (var model in models)
                {
                    model.Acceleration += 1;
                    Debug.Log($"Acceleration TRUE / Value:{model.Acceleration}");
                }

            }
        }
        
        public void Dispose()
        {
            _playerInput.Disable();
        }
    }
}