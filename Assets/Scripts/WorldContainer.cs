using System.Collections.Generic;
using Asteroids.Core;

namespace Asteroids
{
    public class WorldContainer
    {
        public IEnumerable<IMove> Movers => _movers;
        public IEnumerable<ICheckBorder> CheckBorders => _checkBorders;
        public IEnumerable<ICollisionChecker> PlayerCollisionCheckers => _playerCollisionCheckers;
        public IEnumerable<ICollider> EnemyColliders => _enemyColliders;

        private List<IMove> _movers = new List<IMove>();
        private List<ICheckBorder> _checkBorders = new List<ICheckBorder>();
        private List<ICollisionChecker> _playerCollisionCheckers = new List<ICollisionChecker>();
        private List<ICollider> _enemyColliders = new List<ICollider>();
        
        public void RegisterEnemy(BaseEnemy enemy)
        {
            _movers.Add(enemy.MoveComponent);
            _checkBorders.Add(enemy.CheckBorder);
            _enemyColliders.Add(enemy.Collider);
        }

        public void RegisterPlayer(Player player)
        {
            _movers.Add(player.MoveComponent);
            _checkBorders.Add(player.CheckBorder);
            _playerCollisionCheckers.Add(player.CollisionChecker);
        }
    }
}