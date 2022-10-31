using System;
using Asteroids.Core.Weapons;

namespace Asteroids.Core
{
    [Serializable]
    public class PlayerConfiguration
    {
        public UnitConfiguration UnitConfiguration;

        public DefaultWeaponConfiguration DefaultWeaponConfiguration;
        public LaserConfiguration LaserConfiguration;
    }
}