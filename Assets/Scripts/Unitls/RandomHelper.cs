using UnityEngine;

namespace Asteroids.Unitls
{
    public static class RandomHelper
    {
        public static Vector2 GetRandomPosition(float xMin, float xMax, float yMin, float yMax)
        {
            return new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        }

        public static void SetRandomBorderPosition(this Transform source, float xMin, float xMax, float yMin, float yMax)
        {
            var randomSide = Random.Range(0, 3);
            if (randomSide == 0)
            {
                source.position = new Vector3(Random.Range(xMin, xMax), yMin);
            }

            if (randomSide == 1)
            {
                source.position = new Vector3(Random.Range(xMin, xMax), yMax);
            }
            
            if (randomSide == 2)
            {
                source.position = new Vector3(xMin, Random.Range(yMin, yMax));
            }
            
            if (randomSide == 3)
            {
                source.position = new Vector3(xMax, Random.Range(yMin, yMax));
            }
        }
    }
}