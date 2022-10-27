using System;
using System.Collections.Generic;
using Asteroids.Core.Common;
using UnityEngine;

namespace Asteroids.Core
{
    public class BulletFactory : BaseFactory<BulletType, BaseBullet>
    {
        private PoolObject<MonoBehaviour> _rifleBulletPool;
        private readonly Vector2 _viewSize;

        private Dictionary<IDestroyable, BaseBullet> _destroyableToBullet = new Dictionary<IDestroyable, BaseBullet>();

        public BulletFactory(UnitSettings unitSettings, WorldContainer worldContainer, Vector2 viewSize, Transform root) : base(unitSettings, worldContainer, root)
        {
            UnitSettings = unitSettings;

            _root = root;
            _viewSize = viewSize;

            _rifleBulletPool = new PoolObject<MonoBehaviour>(
                UnitSettings.PlayerConfiguration.RifleWeaponConfiguration.BulletConfiguration.ViewConfiguration.View,
                10, 
                _root, 
                true);
        }
 
        public override BaseBullet Create(BulletType type)
        {
            switch (type)
            {
                case BulletType.Rifle:
                    var view = _rifleBulletPool.GetObject();
                    var rifleBullet = new RifleBullet(
                        UnitSettings.PlayerConfiguration.RifleWeaponConfiguration.BulletConfiguration, 
                        view, 
                        _viewSize,
                        UnitSettings.PlayerConfiguration.RifleWeaponConfiguration.BulletConfiguration.Distance);
                    _worldContainer.RegisterBullet(rifleBullet);
                    if (!_destroyableToBullet.ContainsKey(rifleBullet.Destroyable))
                    {
                        _destroyableToBullet[rifleBullet.Destroyable] = rifleBullet;
                        rifleBullet.Destroyable.Death += OnDestroyRifleBullet;
                    }
                    
                    return rifleBullet;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
            return null;
        }

        private void OnDestroyRifleBullet(IDestroyable sender)
        {
            _rifleBulletPool.ReturnObject(_destroyableToBullet[sender].View);
        }
    }

    public enum BulletType
    {
        Rifle
    }
}