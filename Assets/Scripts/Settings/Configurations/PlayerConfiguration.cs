using System;

namespace Asteroids.Settings
{
    [Serializable]
    public class PlayerConfiguration
    {
        public UnitConfiguration UnitConfiguration;

        public RifleWeaponConfiguration _rifleWeaponConfiguration;
        public LaserConfiguration LaserConfiguration;
    }
}