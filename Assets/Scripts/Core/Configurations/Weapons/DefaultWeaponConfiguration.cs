using System;
using Asteroids.Core.Views;

namespace Asteroids.Core.Weapons
{
    [Serializable]
    public class DefaultWeaponConfiguration
    {
        public float BulletColliderSize;
        public float BulletSpeed;
        public float BulletFlyDistance;
        public float FireRate;
        
        public BaseGameObjectView View;
    }
}