using UnityEngine;

namespace Asteroids.Unitls
{
    public static class RandomHelper
    {
        public static Vector2 GetRandomPosition(float xMin, float xMax, float yMin, float yMax)
        {
            return new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        }
    }
}