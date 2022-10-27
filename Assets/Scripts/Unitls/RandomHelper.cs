using UnityEngine;

namespace Asteroids.Unitls
{
    public static class RandomHelper
    {
        public static void SetRandomBorderPosition(this Transform source, float xMin, float xMax, float yMin, float yMax)
        {
            var randomSide = Random.Range(0, 3);
            SetPositionWithCondition(randomSide == 0, source, Random.Range(xMin, xMax), yMin);
            SetPositionWithCondition(randomSide == 1, source, Random.Range(xMin, xMax), yMin);
            SetPositionWithCondition(randomSide == 2, source, xMin, Random.Range(yMin, yMax));
            SetPositionWithCondition(randomSide == 3, source, xMax, Random.Range(yMin, yMax));
        }

        private static void SetPositionWithCondition(bool condition, Transform target, float x, float y)
        {
            if (condition)
            {
                target.position = new Vector3(x, y, 0);
            }
        }
        
    }
}