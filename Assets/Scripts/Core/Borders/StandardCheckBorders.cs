using UnityEngine;

namespace Asteroids.Core
{
    public class StandardCheckBorders : ICheckBorder
    {
        private Camera _camera;
        private Transform _transform;

        private Vector2 _viewSize;
        private float minX;
        private float maxX;
        private float minY;
        private float maxY;

        public StandardCheckBorders(Camera camera, Transform transform)
        {
            _camera = camera;
            _transform = transform;
            
            _viewSize = new Vector2 (_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
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