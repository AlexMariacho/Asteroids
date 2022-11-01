using System;

namespace Asteroids.Settings
{
    [Serializable]
    public class UnitConfiguration
    {
        public float MoveSpeed;
        public float Acceleration;
        public float RotationSpeed;

        public float ColliderSize;

        public int Health;
        
        public ConfigurationView View;
    }
}