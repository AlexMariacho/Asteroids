using System;

namespace Asteroids.Core.Configuration
{
    [Serializable]
    public class EnemyConfiguration
    {
        public MoveConfiguration MoveConfiguration;
        public UnitViewConfiguration ViewConfiguration;
        public CollisionConfiguration CollisionConfiguration;
    }
}