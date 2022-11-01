using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Core
{
    public class WorldContainer : IDisposable
    {
        public IEnumerable<BaseUnit> PlayerBullets => _playerBullets;
        public IEnumerable<BaseUnit> EnemyUnits => _enemyUnits;
        public IEnumerable<BaseUnit> AllUnits => _allUnits;

        public Player Player { get; private set; }

        private List<BaseUnit> _playerBullets = new List<BaseUnit>();
        private List<BaseUnit> _enemyUnits = new List<BaseUnit>();
        private List<BaseUnit> _allUnits = new List<BaseUnit>();

        private Dictionary<IDestroyable, BaseUnit> _destroyableToUnit = new Dictionary<IDestroyable, BaseUnit>();

        public void RegisterPlayer(Player player)
        {
            Player = player;
            RegisterUnit(player);
        }

        public void RegisterEnemyUnit(BaseUnit enemy)
        {
            _enemyUnits.Add(enemy);
            RegisterUnit(enemy);
        }
        
        public void RegisterPlayerBullet(BaseUnit baseUnit)
        {
            _playerBullets.Add(baseUnit);
            RegisterUnit(baseUnit);
        }

        private void RegisterUnit(BaseUnit unit)
        {
            _allUnits.Add(unit);
            _destroyableToUnit[unit.DestroyableComponent] = unit;
            unit.DestroyableComponent.Death += OnDestroyUnit;
        }

        private void OnDestroyUnit(IDestroyable destroyable)
        {
            var unit = _destroyableToUnit[destroyable];
            _allUnits.Remove(unit);
            if (_enemyUnits.Contains(unit))
            {
                _enemyUnits.Remove(unit);
            }
            if (_playerBullets.Contains(unit))
            {
                _playerBullets.Remove(unit);
            }
        }

        public void Dispose()
        {
            var allUnits = AllUnits.Select(t => t.DestroyableComponent).ToList();
            foreach (var unit in allUnits)
            {
                unit.Destroy();
            }
        }
        
    }
}