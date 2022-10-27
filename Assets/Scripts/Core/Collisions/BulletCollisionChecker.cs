using System.Linq;
using UnityEngine;

namespace Asteroids.Core
{
    public class BulletCollisionChecker : ICollisionChecker
    {
        private WorldContainer _worldContainer;
        private ICollider _selfCollider;
        private IDestroyable _selfDestroyable;

        public BulletCollisionChecker(WorldContainer worldContainer, ICollider selfCollider, IDestroyable selfDestroyable)
        {
            _worldContainer = worldContainer;
            _selfCollider = selfCollider;
            _selfDestroyable = selfDestroyable;
        }

        public void CheckCollisions()
        {
            var enemies = _worldContainer.Units.ToArray();
            
            foreach (var baseUnit in enemies)
            {
                if (baseUnit == _worldContainer.Player)
                    continue;
                
                if (CheckDistance(
                        _selfCollider.Transform.position,
                        baseUnit.View.transform.position,
                        _selfCollider.SizeCollider / 2 + baseUnit.ColliderComponent.SizeCollider / 2))
                {
                    baseUnit.DestroyableComponent.TakeDamage();
                    _selfDestroyable.TakeDamage();
                }
            }
            
        }
        
        private bool CheckDistance(Vector2 source, Vector2 target, float minimumDistance)
        {
            return Vector2.Distance(source, target) < minimumDistance;
        }
    }
}