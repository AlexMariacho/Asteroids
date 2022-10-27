using UnityEngine;

namespace Asteroids.Core
{
    public class PlayerCollisionChecker : ICollisionChecker
    {
        private readonly WorldContainer _worldContainer;
        
        private readonly Transform _transform;
        private readonly float _sizeCollision;
        private readonly IDestroyable _playerDestroyable;

        public PlayerCollisionChecker(WorldContainer worldContainer, IDestroyable destroyable, Transform transform, float sizeCollision)
        {
            _worldContainer = worldContainer;
            _transform = transform;
            _sizeCollision = sizeCollision;
            _playerDestroyable = destroyable;
        }

        public void CheckCollisions()
        {
            foreach (var collider in _worldContainer.Units)
            {
                if (collider.View.transform == _transform)
                    continue;
                
                if (CheckDistance(
                        _transform.position, 
                        collider.ColliderComponent.Transform.position, 
                        _sizeCollision / 2 + collider.ColliderComponent.SizeCollider / 2))
                {
                    _playerDestroyable.TakeDamage();     
                }
            }
        }

        private bool CheckDistance(Vector2 source, Vector2 target, float minimumDistance)
        {
            return Vector2.Distance(source, target) < minimumDistance;
        }
    }
}