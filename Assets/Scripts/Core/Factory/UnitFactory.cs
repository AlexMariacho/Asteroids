using System;
using UnityEngine;

namespace Asteroids.Core.Factory
{
    public class UnitFactory : BaseFactory<UnitType, BaseEnemy>
    {
        private readonly Transform _playerTransform;
        private readonly Vector2 _viewSize;
        
        public UnitFactory(
            UnitSettings unitSettings, 
            WorldContainer worldContainer, 
            Transform playerTransform, 
            Vector2 viewSize) : base(unitSettings, worldContainer)
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
                    _worldContainer.RegisterEnemy(asteroid);
                    return asteroid;
                    break;
                case UnitType.Ufo:
                    var ufo = new Ufo(_unitSettings.UfoConfiguration, _playerTransform, _viewSize);
                    _worldContainer.RegisterEnemy(ufo);
                    return ufo;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    public enum UnitType
    {
        Asteroid,
        Ufo
    }
}