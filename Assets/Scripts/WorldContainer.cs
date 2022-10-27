using System.Collections.Generic;
using Asteroids.Core;
using UnityEngine;

namespace Asteroids
{
    public class WorldContainer
    {
        public IEnumerable<BaseUnit> Units => _units;
        public IEnumerable<BaseBullet> Bullets => _bullets;

        public Player Player { get; private set; }

        private Dictionary<IDestroyable, BaseUnit> _destroyableToUnits = new Dictionary<IDestroyable, BaseUnit>();
        private Dictionary<IDestroyable, BaseBullet> _destroyableToBullets = new Dictionary<IDestroyable, BaseBullet>();

        private List<BaseUnit> _units = new List<BaseUnit>();
        private List<BaseBullet> _bullets = new List<BaseBullet>();


        public void RegisterPlayer(Player player)
        {
            Player = player;
            RegisterUnit(Player);
        }

        public void RegisterUnit(BaseUnit unit)
        {
            _destroyableToUnits[unit.DestroyableComponent] = unit;
            _units.Add(unit);
        }

        public void UnRegisterUnit(BaseUnit unit)
        {
            _destroyableToUnits.Remove(unit.DestroyableComponent);
            _units.Remove(unit);
        }

        public void RegisterBullet(BaseBullet bullet)
        {
            _destroyableToBullets[bullet.Destroyable] = bullet;
            _bullets.Add(bullet);
        }

        public void UnRegisterBullet(BaseBullet bullet)
        {
            _destroyableToBullets.Remove(bullet.Destroyable);
            _bullets.Remove(bullet);
        }
    }
}