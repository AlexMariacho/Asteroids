using System;
using UnityEngine;

namespace Asteroids.Core.Factory
{
    public class UnitFactory : BaseFactory<UnitType, BaseEnemy>
    {
        private Transform _playerTransform;
        private Camera _camera;
        
        public UnitFactory(UnitSettings unitSettings, Transform playerTransform, Camera camera) : base(unitSettings)
        {
            _playerTransform = playerTransform;
            _camera = camera;
        }

        public override BaseEnemy Create(UnitType type)
        {
            switch (type)
            {
                case UnitType.Asteroid:
                    var asteroid = new Asteroid(_unitSettings.AsteroidConfiguration, _camera);
                    return asteroid;
                    break;
                case UnitType.Ufo:
                    var ufo = new Ufo(_unitSettings.UfoConfiguration, _playerTransform, _camera);
                    return ufo;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            return null;
        }
    }

    public enum UnitType
    {
        Asteroid,
        Ufo
    }
}