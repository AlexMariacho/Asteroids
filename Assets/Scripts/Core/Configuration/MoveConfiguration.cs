using System;

namespace Asteroids.Core.Configuration
{
    [Serializable]
    public class MoveConfiguration
    {
        public float Speed;
        public float Acceleration;
        public float RotationSpeed;
    }
}