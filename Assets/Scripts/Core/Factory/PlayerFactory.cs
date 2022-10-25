using System;
using UnityEngine;

namespace Asteroids.Core.Factory
{
    public class PlayerFactory : BaseFactory<PlayerType, Player>
    {
        private readonly Vector2 _viewSize;
        private readonly PlayerInputActions _playerInput;
        
        public PlayerFactory(
            UnitSettings unitSettings, 
            WorldContainer worldContainer, 
            PlayerInputActions input, 
            Vector2 viewSize) : base(unitSettings, worldContainer)
        {
            _playerInput = input;
            _viewSize = viewSize;
        }

        public override Player Create(PlayerType type)
        {
            switch (type)
            {
                case PlayerType.Classic:
                    var player = new Player(_unitSettings.PlayerConfiguration, _worldContainer, _playerInput, _viewSize);
                    _worldContainer.RegisterPlayer(player);
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