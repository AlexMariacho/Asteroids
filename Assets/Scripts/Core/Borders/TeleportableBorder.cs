using UnityEngine;

namespace Asteroids.Core
{
    public class TeleportableBorder : ICheckBorder
    {
        private Transform _transform;

        private Vector2 _viewSize;
        private float minX;
        private float maxX;
        private float minY;
        private float maxY;

        public TeleportableBorder(Vector2 viewSize, Transform transform)
        {
            _transform = transform;

            _viewSize = viewSize;
            minX = -_viewSize.x;
            maxX = _viewSize.x;
            minY = -_viewSize.y;
            maxY = _viewSize.y;
        }

        public void CheckBorder()
        {
            var currentPos = _transform.position;

            if (currentPos.x > maxX)
            {
                _transform.position = new Vector3(minX, currentPos.y, 0);
            }
            
            if (currentPos.x < minX)
            {
                _transform.position = new Vector3(maxX, currentPos.y, 0);
            }

            if (currentPos.y > maxY)
            {
                _transform.position = new Vector3(currentPos.x, minY, 0);
            }
            
            if (currentPos.y < minY)
            {
                _transform.position = new Vector3(currentPos.x, maxY, 0);
            }
        }
    }
}