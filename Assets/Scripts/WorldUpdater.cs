using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Core.Factory;

namespace Asteroids
{
    public class WorldUpdater
    {
        private UnitFactory _unitFactory;

        private List<IMove> _movers = new List<IMove>();
        private List<ICheckBorder> _checkBorders = new List<ICheckBorder>();

        public WorldUpdater(UnitFactory unitFactory)
        {
            _unitFactory = unitFactory;
            _unitFactory.Created += OnCreateEnemy;
        }

        public void InitializePlayer(Player player)
        {
            _movers.Add(player.MoveComponent);
            _checkBorders.Add(player.CheckBorder);
        }

        public void Update()
        {
            _movers.ForEach(t => t.Move());
            _checkBorders.ForEach(t => t.CheckBorder());
        }

        private void OnCreateEnemy(BaseEnemy enemy)
        {
            _movers.Add(enemy.MoveComponent);
            _checkBorders.Add(enemy.CheckBorder);
        }
    }
}