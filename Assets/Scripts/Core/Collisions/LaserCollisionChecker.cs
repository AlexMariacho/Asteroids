using System;
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
                if (baseUnit == _worldContainer.Player)
                    continue;

                if (CheckCollision(baseUnit.View.transform.position))
                {
                    baseUnit.DestroyableComponent.TakeDamage();
                }
            }
        }

        private bool CheckCollision(Vector3 target)
        {
            var selfPosition = _selfCollider.Transform.position;
            var laserEndPoint = _selfCollider.Transform.TransformDirection(Vector3.up) * _distance;

            var vectorToTarget = target - selfPosition;
            var vectorToLaser = laserEndPoint - selfPosition;
            
            var lenghtA = vectorToLaser.magnitude;
            var lenghtB = vectorToTarget.magnitude;
            var lenghtC = (target - laserEndPoint).magnitude;
            var p = (lenghtA + lenghtB + lenghtC) / 2;
            
            var resultCalculation = 2 * Math.Sqrt(p * (p - lenghtA) * (p - lenghtB) * (p - lenghtC)) / lenghtA;
            return resultCalculation < _selfCollider.SizeCollider &&
                   MultiplyVectors(ref vectorToTarget, ref vectorToLaser) > 0;
        }

        private float MultiplyVectors(ref Vector3 vector1, ref Vector3 vector2)
        {
            var result = vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
            return result;
        }

    }
}