using Asteroids.Core.Configuration;
using UnityEngine;

namespace Asteroids.Core
{
    public class Player
    {
        public readonly IMove MoveComponent;
        public readonly ICheckBorder CheckBorder;
        public readonly GameObject View;

        public Player(PlayerConfiguration configuration, PlayerInputActions playerInput, Vector2 viewSize)
        {
            var moveConfig = configuration.MoveConfiguration; 
            View = GameObject.Instantiate(configuration.ViewConfiguration.View);
            MoveComponent = new PlayerMover(
                playerInput,
                View.transform,
                moveConfig.Acceleration,
                moveConfig.RotationSpeed,
                30);
            CheckBorder = new StandardCheckBorders(viewSize, View.transform);
        }
    }
}