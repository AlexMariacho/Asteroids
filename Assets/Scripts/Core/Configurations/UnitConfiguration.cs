using System;
using Asteroids.Core.Views;

namespace Asteroids.Core
{
    [Serializable]
    public class UnitConfiguration
    {
        public float MoveSpeed;
        public float Acceleration;
        public float RotationSpeed;

        public float ColliderSize;

        public int Health;
        
        public BaseGameObjectView View;
    }
}