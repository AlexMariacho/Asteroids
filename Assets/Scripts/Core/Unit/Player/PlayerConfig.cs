using UnityEngine;

namespace Asteroids.Core
{
    [CreateAssetMenu(fileName = "Player", menuName = "Configs/Player", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public UnitConfig UnitConfig;
        public float Acceleration;
    }
}