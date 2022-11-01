using System;

namespace Asteroids.Settings
{
    [Serializable]
    public class LaserConfiguration
    {
        public float Distance;
        public int ChargeCount;
        public float ChargeReloadTime;
        public float ReloadTime;
        public float FireTime;
        public float SizeCollision;

        public ConfigurationView View;
    }
}