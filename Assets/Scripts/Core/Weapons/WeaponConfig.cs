using UnityEngine;

namespace Asteroids.Core
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/Weapon", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        public BulletConfig BulletConfig;
        public float Coldown;
    }
}