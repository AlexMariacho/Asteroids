using System;

namespace Asteroids.Core.Configuration
{
    [Serializable]
    public class AsteroidConfiguration
    {
        public MoveConfiguration MoveConfiguration;
        public UnitViewConfiguration ViewConfiguration;
    }
}