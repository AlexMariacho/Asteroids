using UnityEngine;

namespace Asteroids.Core
{
    public class PlayerCollisionChecker : ICollisionChecker
    {
        private readonly WorldContainer _worldContainer;

        private ICollider _selfCollider;
        private readonly IDestroyable _playerDestroyable;

        public PlayerCollisionChecker(WorldContainer worldContainer, IDestroyable destroyable, ICollider collider)
        {
            _worldContainer = worldContainer;
            _selfCollider = collider;
            _playerDestroyable = destroyable;
        }

        public void CheckCollisions()
        {
            foreach (var baseUnit in _worldContainer.EnemyUnits)
            {
                if (CheckDistance(
                        _selfCollider.Transform.position, 
                        baseUnit.ColliderComponent.Transform.position, 
                        _selfCollider.SizeCollider / 2 + baseUnit.ColliderComponent.SizeCollider / 2))
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