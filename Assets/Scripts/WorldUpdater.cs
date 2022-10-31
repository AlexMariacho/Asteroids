using System.Collections.Generic;
using System.Linq;
using Asteroids.Core;

namespace Asteroids
{
    public class WorldUpdater
    {
        private WorldContainer _worldContainer;
        private bool _isEnabled;
        
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
            CheckDestroyable();
        }

        private void MoveUpdate()
        {
            if (!_isEnabled) return;
            foreach (var baseUnit in _worldContainer.AllUnits)
            {
                baseUnit.MoveComponent.Move();
            }
        }

        private void CheckBorders()
        {
            if (!_isEnabled) return;
            foreach (var baseUnit in _worldContainer.AllUnits)
            {
                baseUnit.CheckBorderComponent.CheckBorder();
            }
        }

        private void CheckCollisions()
        {
            if (!_isEnabled) return;
            foreach (var baseUnit in _worldContainer.AllUnits)
            {
                baseUnit.CollisionChecker.CheckCollisions();
            }
        }

        private void FireWeapons()
        {
            if (!_isEnabled) return;
            _worldContainer.Player.SelectedWeapon.Fire();
        }

        private void CheckDestroyable()
        {
            if (!_isEnabled) return;
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
            _isEnabled = true;
        }

        public void Stop()
        {
            _isEnabled = false;
        }

    }
}