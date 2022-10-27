using Asteroids.Core;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Settings/Unit Settings", order = 0)]
    public class UnitSettings : ScriptableObject
    {
        public PlayerConfiguration PlayerConfiguration;
        public EnemyConfiguration AsteroidConfiguration;
        public EnemyConfiguration UfoConfiguration;
    }
}