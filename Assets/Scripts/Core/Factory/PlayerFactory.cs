using System;
using System.Collections.Generic;
using Asteroids.ConfigurationInfo;
using UnityEngine;

namespace Asteroids.Core
{
    public class PlayerFactory : BaseFactory<PlayerType, PlayerConfig, Player>
    {
        public PlayerFactory(List<PlayerInformation> settings) : base(settings.ToArray())
        {
        }

        public override Player CreateUnit(PlayerType type)
        {
            if (_typeToConfig.ContainsKey(type))
            {
                var player = new Player();
                var config = _typeToConfig[type];
                player
                    .SetSpeed(config.UnitConfig.MoveSpeed)
                    .SetHp(config.UnitConfig.Health);
                GameObject.Instantiate(config.UnitConfig.View);
                InvokeCreateEvent(player);
            }
            return null;
        }
    }

    public enum PlayerType
    {
        Classic
    }
    
}