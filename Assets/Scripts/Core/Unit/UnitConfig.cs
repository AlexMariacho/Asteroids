using UnityEngine;

namespace Asteroids.Core
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "Configs/Unit", order = 0)]
    public class UnitConfig : ScriptableObject
    {
        public WeaponConfig WeaponConfig;
        public int Health;

        public float MoveSpeed;
        public float AngularSpeed;

        public GameObject View;
    }
}