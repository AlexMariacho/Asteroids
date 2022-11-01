using UnityEngine;

namespace Asteroids.Core.Unitls
{
    public static class Vector3Helper
    {
        public static float MultiplyVectors(ref Vector3 vector1, ref Vector3 vector2)
        {
            var result = vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
            return result;
        }
    }
}