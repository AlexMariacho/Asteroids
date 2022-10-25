using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids
{
    public class WorldContainer
    {
        public IEnumerable<IMove> Movers => _movers;
        public IEnumerable<ICheckBorder> CheckBorders => _checkBorders;

        private List<IMove> _movers = new List<IMove>();
        private List<ICheckBorder> _checkBorders = new List<ICheckBorder>();
        
        public void RegisterEnemy(BaseEnemy enemy)
        {
            _movers.Add(enemy.MoveComponent);
            _checkBorders.Add(enemy.CheckBorder);
        }

        public void RegisterPlayer(Player player)
        {
            _movers.Add(player.MoveComponent);
            _checkBorders.Add(player.CheckBorder);
        }
    }
}