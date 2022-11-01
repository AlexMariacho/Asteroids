using UnityEngine;

namespace Asteroids.Settings
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Settings/Unit Settings", order = 0)]
    public class UnitSettings : ScriptableObject
    {
        public PlayerConfiguration PlayerConfiguration;
        public UnitConfiguration AsteroidConfiguration;
        public UnitConfiguration SmallAsteroidConfiguration;
        public UnitConfiguration UfoConfiguration;
    }
}