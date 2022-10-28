using System;
using Asteroids.Core.Common;
using Asteroids.Core.Views;
using Asteroids.Core.Weapons;
using UnityEngine;

namespace Asteroids.Core
{
    public class UnitFactory : BaseFactory<UnitType, BaseUnit>
    {
        private readonly Transform _playerTransform;
        private readonly Vector2 _viewSize;
        private Transform _rootBullets;
        
        private PoolObject<MonoBehaviour> _bulletsPool;
        private PoolObject<MonoBehaviour> _asteroidsPool;
        private PoolObject<MonoBehaviour> _smallAsteroidsPool;

        public UnitFactory(
            UnitSettings unitSettings, 
            WorldContainer worldContainer, 
            Transform playerTransform, 
            Vector2 viewSize,
            Transform root,
            Transform rootBullets) : base(unitSettings, worldContainer, root)
        {
            _playerTransform = playerTransform;
            _viewSize = viewSize;
            _rootBullets = rootBullets;
            
            CreatePools(rootBullets);
        }

        private void CreatePools(Transform rootBullets)
        {
            _bulletsPool = new PoolObject<MonoBehaviour>(
                UnitSettings.PlayerConfiguration.RifleWeaponConfiguration.BulletConfiguration.ViewConfiguration.View,
                10,
                rootBullets);

            _asteroidsPool = new PoolObject<MonoBehaviour>(
                UnitSettings.AsteroidConfiguration.ViewConfiguration.View,
                10,
                _root);

            _smallAsteroidsPool = new PoolObject<MonoBehaviour>(
                UnitSettings.SmallAsteroidConfiguration.ViewConfiguration.View,
                10,
                _root);
        }

        public override BaseUnit Create(UnitType type)
        {
            switch (type)
            {
                case UnitType.Asteroid:
                    var viewAsteroid = _asteroidsPool.GetObject();
                    var asteroid = new Asteroid(UnitSettings.AsteroidConfiguration, this, viewAsteroid, _viewSize);
                    _worldContainer.RegisterEnemyUnit(asteroid);
                    return asteroid;
                    break;
                case UnitType.SmallAsteroid:
                    var viewSmallAsteroid = _smallAsteroidsPool.GetObject();
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
                    var viewLaser = GameObject.Instantiate(UnitSettings.PlayerConfiguration.LaserConfiguration.View, _rootBullets);
                    var laser = new Laser(UnitSettings.PlayerConfiguration.LaserConfiguration, _worldContainer, viewLaser);
                    _worldContainer.RegisterPlayerBullet(laser);
                    return laser;
                case UnitType.Bullet:
                    var view = _bulletsPool.GetObject();
                    var bullet = new Bullet(
                        UnitSettings.PlayerConfiguration.RifleWeaponConfiguration.BulletConfiguration,
                        _worldContainer,
                        _bulletsPool,
                        view, 
                        _viewSize,
                        UnitSettings.PlayerConfiguration.RifleWeaponConfiguration.BulletConfiguration.Distance);
                    _worldContainer.RegisterPlayerBullet(bullet);
                    return bullet;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

    }

    public enum UnitType
    {
        Asteroid,
        SmallAsteroid,
        Ufo,
        Laser,
        Bullet
    }
}