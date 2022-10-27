using System;

namespace Asteroids.Core
{
    [Serializable]
    public class EnemyConfiguration
    {
        public MoveConfiguration MoveConfiguration;
        public UnitViewConfiguration ViewConfiguration;
        public CollisionConfiguration CollisionConfiguration;
        public DestroyableConfiguration DestroyableConfiguration;
    }
}