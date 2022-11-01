using System.Collections.Generic;
using Asteroids.Core;
using UnityEngine;

namespace Asteroids.Core
{
    public class WorldUpdater
    {
        public bool IsRunning => _isRunning;
        
        private WorldContainer _worldContainer;
        private bool _isRunning;

        private PlayerScore _score;
        
        public WorldUpdater(WorldContainer worldContainer)
        {
            _worldContainer = worldContainer;
        }

        public void Update()
        {
            MoveUpdate();
            CheckBorders();
            CheckCollisions();
            FireWeapons();
            CheckTakeScore();
            CheckDestroyable();
        }

        private void MoveUpdate()
        {
            if (!_isRunning) return;
            foreach (var baseUnit in _worldContainer.AllUnits)
            {
                baseUnit.MoveComponent.Move();
            }
        }

        private void CheckBorders()
        {
            if (!_isRunning) return;
            foreach (var baseUnit in _worldContainer.AllUnits)
            {
                baseUnit.CheckBorderComponent.CheckBorder();
            }
        }

        private void CheckCollisions()
        {
            if (!_isRunning) return;
            foreach (var baseUnit in _worldContainer.AllUnits)
            {
                baseUnit.CollisionChecker.CheckCollisions();
            }
        }

        private void FireWeapons()
        {
            if (!_isRunning) return;
            _worldContainer.Player.SelectedWeapon.Fire();
        }

        private void CheckTakeScore()
        {
            foreach (var baseUnit in _worldContainer.EnemyUnits)
            {
                if (baseUnit.DestroyableComponent.Health <= 0)
                {
                    _score.TakeScore();
                }
            }

        }

        private void CheckDestroyable()
        {
            if (!_isRunning) return;
            var destroyList = new List<BaseUnit>();
            foreach (var baseUnit in _worldContainer.AllUnits)
            {
                if (baseUnit.DestroyableComponent.Health <= 0)
                {
                    destroyList.Add(baseUnit);
                }
            }

            foreach (var baseUnit in destroyList)
            {
                baseUnit.DestroyableComponent.Destroy();
            }
        }

        public void Start()
        {
            _score = _worldContainer.Player.Score;
            _isRunning = true;
        }

        public void Stop()
        {
            _isRunning = false;
        }

    }
}