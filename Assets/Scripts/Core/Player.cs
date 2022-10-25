using Asteroids.Core.Configuration;
using UnityEngine;

namespace Asteroids.Core
{
    public class Player
    {
        private PlayerConfiguration _configuration;
        private PlayerInputActions _playerInput;
        
        public IMove MoveComponent;
        public GameObject View;
        
        public Player(PlayerConfiguration configuration, PlayerInputActions playerInput)
        {
            _configuration = configuration;
            _playerInput = playerInput;

            var moveConfig = _configuration.MoveConfiguration;
            View = GameObject.Instantiate(configuration.ViewConfiguration.View);
            MoveComponent = new PlayerMover(
                _playerInput,
                View.transform,
                moveConfig.Acceleration,
                moveConfig.RotationSpeed,
                30);
        }
    }
}