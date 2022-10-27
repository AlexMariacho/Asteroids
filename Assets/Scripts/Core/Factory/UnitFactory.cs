using System;
using UnityEngine;

namespace Asteroids.Core
{
    public class UnitFactory : BaseFactory<UnitType, BaseUnit>
    {
        private readonly Transform _playerTransform;
        private readonly Vector2 _viewSize;
        
        public UnitFactory(
            UnitSettings unitSettings, 
            WorldContainer worldContainer, 
            Transform playerTransform, 
            Vector2 viewSize,
            Transform root) : base(unitSettings, worldContainer, root)
        {
            _playerTransform = playerTransform;
            _viewSize = viewSize;
        }

        public override BaseUnit Create(UnitType type)
        {
            switch (type)
            {
                case UnitType.Asteroid:
                    var viewAsteroid = GameObject.Instantiate((UnitSettings.AsteroidConfiguration.ViewConfiguration.View), _root);
                    var asteroid = new Asteroid(UnitSettings.AsteroidConfiguration, this, viewAsteroid, _viewSize);
                    _worldContainer.RegisterUnit(asteroid);
                    return asteroid;
                    break;
                case UnitType.SmallAsteroid:
                    var viewSmallAsteroid = GameObject.Instantiate((UnitSettings.SmallAsteroidConfiguration.ViewConfiguration.View), _root);
                    var smallAsteroid = new SmallAsteroid(UnitSettings.AsteroidConfiguration, viewSmallAsteroid, _viewSize);
                    _worldContainer.RegisterUnit(smallAsteroid);
                    return smallAsteroid;
                case UnitType.Ufo:
                    var viewUfo = GameObject.Instantiate((UnitSettings.UfoConfiguration.ViewConfiguration.View), _root);
                    var ufo = new Ufo(UnitSettings.UfoConfiguration, viewUfo, _playerTransform, _viewSize);
                    _worldContainer.RegisterUnit(ufo);
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
        SmallAsteroid,
        Ufo
    }
}