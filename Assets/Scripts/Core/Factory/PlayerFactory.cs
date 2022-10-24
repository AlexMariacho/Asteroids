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
            if (_typeToConfig.ContainsKey(PlayerType.Classic))
            {
                var player = new Player();
                var config = _typeToConfig[PlayerType.Classic];
                player
                    .SetSpeed(config.UnitConfig.MoveSpeed)
                    .SetHp(config.UnitConfig.Health);

                GameObject.Instantiate(config.UnitConfig.View);
            }
            return null;
        }
    }

    public enum PlayerType
    {
        Classic
    }
    
}