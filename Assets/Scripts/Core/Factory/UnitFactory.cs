using System;
using UnityEngine;

namespace Asteroids.Core.Factory
{
    public class UnitFactory : BaseFactory<UnitType, BaseEnemy>
    {
        private Transform _playerTransform;
        private Vector2 _viewSize;
        
        public UnitFactory(UnitSettings unitSettings, Transform playerTransform, Vector2 viewSize) : base(unitSettings)
        {
            _playerTransform = playerTransform;
            _viewSize = viewSize;
        }

        public override BaseEnemy Create(UnitType type)
        {
            switch (type)
            {
                case UnitType.Asteroid:
                    var asteroid = new Asteroid(_unitSettings.AsteroidConfiguration, _viewSize);
                    return asteroid;
                    break;
                case UnitType.Ufo:
                    var ufo = new Ufo(_unitSettings.UfoConfiguration, _playerTransform, _viewSize);
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