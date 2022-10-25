using System;
using UnityEngine;

namespace Asteroids.Core.Factory
{
    public class PlayerFactory : BaseFactory<PlayerType, Player>
    {
        private Vector2 _viewSize;
        private PlayerInputActions _playerInput;
        
        public PlayerFactory(UnitSettings unitSettings, PlayerInputActions input, Vector2 viewSize) : base(unitSettings)
        {
            _playerInput = input;
            _viewSize = viewSize;
        }

        public override Player Create(PlayerType type)
        {
            switch (type)
            {
                case PlayerType.Classic:
                    var player = new Player(_unitSettings.PlayerConfiguration, _playerInput, _viewSize);
                    InvokeCreatedEvent(player);
                    return player;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    public enum PlayerType
    {
        Classic
    }
}