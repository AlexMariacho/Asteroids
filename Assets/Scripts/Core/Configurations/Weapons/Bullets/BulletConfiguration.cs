using System;

namespace Asteroids.Core
{
    [Serializable]
    public class BulletConfiguration
    {
        public MoveConfiguration MoveConfiguration;
        public CollisionConfiguration CollisionConfiguration;
        public UnitViewConfiguration ViewConfiguration;
        public DestroyableConfiguration DestroyableConfiguration;
        
        public float Distance;
    }
}