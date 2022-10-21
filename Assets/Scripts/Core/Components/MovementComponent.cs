using System;

namespace Asteroids.Core
{
    [Serializable]
    public class MovementComponent : IData
    {
        public float Acceleration;
        public float AngularSpeed;
        public float Speed;
    }
}