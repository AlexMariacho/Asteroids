using System;
using Asteroids.Core.Views;
using Asteroids.Core.Weapons;
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
                    _worldContainer.RegisterEnemyUnit(asteroid);
                    return asteroid;
                    break;
                case UnitType.SmallAsteroid:
                    var viewSmallAsteroid = GameObject.Instantiate((UnitSettings.SmallAsteroidConfiguration.ViewConfiguration.View), _root);
                    var smallAsteroid = new SmallAsteroid(UnitSettings.AsteroidConfiguration, viewSmallAsteroid, _viewSize);
                    _worldContainer.RegisterEnemyUnit(smallAsteroid);
                    return smallAsteroid;
                case UnitType.Ufo:
                    var viewUfo = GameObject.Instantiate((UnitSettings.UfoConfiguration.ViewConfiguration.View), _root);
                    var ufo = new Ufo(UnitSettings.UfoConfiguration, viewUfo, _playerTransform, _viewSize);
                    _worldContainer.RegisterEnemyUnit(ufo);
                    return ufo;
                    break;
                case UnitType.Laser:
                    var viewLaser = GameObject.Instantiate(UnitSettings.PlayerConfiguration.LaserConfiguration.View, _root);
                    var laser = new Laser(UnitSettings.PlayerConfiguration.LaserConfiguration, _worldContainer, viewLaser);
                    _worldContainer.RegisterPlayerBullet(laser);
                    ResizeLaser((LaserView)viewLaser, UnitSettings.PlayerConfiguration.LaserConfiguration);
                    return laser;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void ResizeLaser(LaserView view, LaserConfiguration configuration)
        {
            view.Laser.transform.localScale = new Vector3(configuration.SizeCollision, configuration.Distance);
            view.Laser.transform.localPosition = new Vector3(0, configuration.Distance / 2 + 0.5f, 0);
        }

    }

    public enum UnitType
    {
        Asteroid,
        SmallAsteroid,
        Ufo,
        Laser
    }
}