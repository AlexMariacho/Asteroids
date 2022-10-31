using System;
using Asteroids.Unitls;
using UnityEngine;

namespace Asteroids.Core
{
    public class LaserCollisionChecker : ICollisionChecker
    {
        private WorldContainer _worldContainer;
        private ICollider _selfCollider;
        private float _distance;

        public LaserCollisionChecker(WorldContainer worldContainer, ICollider selfCollider, float distance)
        {
            _worldContainer = worldContainer;
            _selfCollider = selfCollider;
            _distance = distance;
        }

        public void CheckCollisions()
        {
            foreach (var baseUnit in _worldContainer.EnemyUnits)
            {
                if (CheckCollision(baseUnit.View.transform.position))
                {
                    baseUnit.DestroyableComponent.TakeDamage();
                }
            }
        }

        private bool CheckCollision(Vector3 target)
        {
            var selfPosition = _selfCollider.Transform.position;
            
            var angle = _selfCollider.Transform.rotation.eulerAngles.z;
            angle = angle * 0.0174533f;
            var laserEndPoint = new Vector3(
                -Mathf.Sin(angle) * _distance + selfPosition.x, 
                Mathf.Cos(angle) * _distance + selfPosition.y,
                0);

            var lenghtA = (selfPosition - laserEndPoint).magnitude;
            var lenghtB = (target - selfPosition).magnitude;
            var lenghtC = (laserEndPoint - target).magnitude;
            var p = (lenghtA + lenghtB + lenghtC) / 2;

            var targetVector = target - selfPosition;
            var laserVector = laserEndPoint - selfPosition;
            var resultCalculation = 2 * Math.Sqrt(p * (p - lenghtA) * (p - lenghtB) * (p - lenghtC)) / lenghtA;
            var multiply = Vector3Helper.MultiplyVectors(ref laserVector, ref targetVector);
            
            return resultCalculation < _selfCollider.SizeCollider &&
                   multiply  > 0 &&
                   targetVector.magnitude < _distance;
        }
        
    }
}