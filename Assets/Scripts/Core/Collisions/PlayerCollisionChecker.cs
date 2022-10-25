using UnityEngine;

namespace Asteroids.Core
{
    public class PlayerCollisionChecker : ICollisionChecker
    {
        private readonly WorldContainer _worldContainer;
        
        private readonly Transform _transform;
        private readonly float _sizeCollision;

        public PlayerCollisionChecker(WorldContainer worldContainer, Transform transform, float sizeCollision)
        {
            _worldContainer = worldContainer;
            _transform = transform;
            _sizeCollision = sizeCollision;
        }

        public void CheckCollisions()
        {
            foreach (var collider in _worldContainer.EnemyColliders)
            {
                if (CheckDistance(
                        _transform.position, 
                        collider.Transform.position, 
                        _sizeCollision / 2 + collider.SizeCollider / 2))
                {
                    Debug.Log("Collide!");
                }
            }
        }

        private bool CheckDistance(Vector2 source, Vector2 target, float minimumDistance)
        {
            return Vector2.Distance(source, target) < minimumDistance;
        }
    }
}