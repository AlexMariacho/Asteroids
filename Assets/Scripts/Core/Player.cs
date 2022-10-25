using Asteroids.Core.Configuration;
using UnityEngine;

namespace Asteroids.Core
{
    public class Player
    {
        private PlayerConfiguration _configuration;

        public IMove MoveComponent;
        public ICheckBorder CheckBorder;
        public GameObject View;
        
        public Player(PlayerConfiguration configuration, PlayerInputActions playerInput, Camera camera)
        {
            _configuration = configuration;

            var moveConfig = _configuration.MoveConfiguration;
            View = GameObject.Instantiate(configuration.ViewConfiguration.View);
            MoveComponent = new PlayerMover(
                playerInput,
                View.transform,
                moveConfig.Acceleration,
                moveConfig.RotationSpeed,
                30);
            CheckBorder = new StandardCheckBorders(camera, View.transform);
        }
    }
}