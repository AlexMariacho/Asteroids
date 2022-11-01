using System;

namespace Asteroids.Settings
{
    [Serializable]
    public class RifleWeaponConfiguration
    {
        public float BulletColliderSize;
        public float BulletSpeed;
        public float BulletFlyDistance;
        public float FireRate;
        
        public ConfigurationView View;
    }
}