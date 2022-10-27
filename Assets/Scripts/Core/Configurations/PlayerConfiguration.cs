using System;
using Asteroids.Core.Weapons;

namespace Asteroids.Core
{
    [Serializable]
    public class PlayerConfiguration
    {
        public MoveConfiguration MoveConfiguration;
        public UnitViewConfiguration ViewConfiguration;
        public CollisionConfiguration CollisionConfiguration;
        public DestroyableConfiguration DestroyableConfiguration;

        public RifleWeaponConfiguration RifleWeaponConfiguration;
        public LaserConfiguration LaserConfiguration;
    }
}