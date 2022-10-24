using System;
using Asteroids.Core;

namespace Asteroids.ConfigurationInfo
{
    [Serializable]
    public class PlayerInformation : BaseConfigInformation<PlayerType, PlayerConfig> { }

    [Serializable]
    public class UnitInformation : BaseConfigInformation<UnitType, UnitConfig> { }
}