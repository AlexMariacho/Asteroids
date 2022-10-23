using UnityEngine;

namespace Asteroids.Core
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "Configs/Unit", order = 0)]
    public class UnitConfig : ScriptableObject
    {
        public MoveConfig MoveConfig;
        public WeaponConfig WeaponConfig;
        public int Health;
    }
}