using System;
using Asteroids.Core.Views;

namespace Asteroids.Core.Weapons
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

        public BaseGameObjectView View;
    }
}