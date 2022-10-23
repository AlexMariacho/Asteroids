using System;

namespace Asteroids.Core
{
    [Serializable]
    public class MovementComponent : IData
    {
        public float MaxAcceleration;
        public float Acceleration;
        public float RotationSpeed;
        public float Speed;
    }
}