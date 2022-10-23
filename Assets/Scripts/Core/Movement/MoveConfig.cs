using UnityEngine;

namespace Asteroids.Core
{
    [CreateAssetMenu(fileName = "MoveConfig", menuName = "Configs/Move", order = 0)]
    public class MoveConfig : ScriptableObject
    {
        public float MoveSpeed;
        public float Acceleration;
        public float RotationSpeed;
    }
}