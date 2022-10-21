using System;

namespace Asteroids.Core
{
    [Serializable]
    public class UnitTypeComponent : IData
    {
        public UnitType Type;
        
        public enum UnitType
        {
            Player,
            Asteroid,
            Ufo
        }
    }
}