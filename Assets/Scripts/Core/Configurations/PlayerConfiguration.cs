using System;

namespace Asteroids.Core.Configuration
{
    [Serializable]
    public class PlayerConfiguration
    {
        public MoveConfiguration MoveConfiguration;
        public UnitViewConfiguration ViewConfiguration;
        public CollisionConfiguration CollisionConfiguration;
    }
}