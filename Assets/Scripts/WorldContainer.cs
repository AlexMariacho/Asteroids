using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids
{
    public class WorldContainer
    {
        public IEnumerable<BaseUnit> PlayerBullets => _playerBullets;
        public IEnumerable<BaseUnit> EnemyUnits => _enemyUnits;
        public IEnumerable<BaseUnit> AllUnits => _allUnits;

        public Player Player { get; private set; }

        private List<BaseUnit> _playerBullets = new List<BaseUnit>();
        private List<BaseUnit> _enemyUnits = new List<BaseUnit>();
        private List<BaseUnit> _allUnits = new List<BaseUnit>();

        public void RegisterPlayer(Player player)
        {
            Player = player;
            _allUnits.Add(player);
        }

        public void RegisterEnemyUnit(BaseUnit enemy)
        {
            _enemyUnits.Add(enemy);
            _allUnits.Add(enemy);
        }
        
        public void RegisterPlayerBullet(BaseUnit baseUnit)
        {
            _playerBullets.Add(baseUnit);
            _allUnits.Add(baseUnit);
        }

        public void UnRegisterUnit(BaseUnit baseUnit)
        {
            _allUnits.Remove(baseUnit);
            if (_enemyUnits.Contains(baseUnit))
            {
                _enemyUnits.Remove(baseUnit);
            }
            if (_playerBullets.Contains(baseUnit))
            {
                _playerBullets.Remove(baseUnit);
            }
        }



    }
}