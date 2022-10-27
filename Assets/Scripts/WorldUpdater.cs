using System.Linq;

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
            if (!_isEnabled)
            {
                return;
            }

            MoveUpdate();
            CheckBorders();
            CheckCollisions();
            FireWeapons();
            CheckDestroyable();

        }

        private void MoveUpdate()
        {
            foreach (var unit in _worldContainer.Units)
            {
                unit.MoveComponent.Move();
            }

            foreach (var bullet in _worldContainer.Bullets)
            {
                bullet.MoveComponent.Move();
            }
        }

        private void CheckBorders()
        {
            foreach (var unit in _worldContainer.Units)
            {
                unit.CheckBorderComponent.CheckBorder();
            }

            foreach (var bullet in _worldContainer.Bullets)
            {
                bullet.CheckBorder.CheckBorder();
            }
        }

        private void CheckCollisions()
        {
            _worldContainer.Player.CollisionChecker.CheckCollisions();
            foreach (var bullet in _worldContainer.Bullets)
            {
                bullet.CollisionChecker.CheckCollisions();
            }
        }

        private void FireWeapons()
        {
            _worldContainer.Player.SelectedWeapon.Fire();
        }

        private void CheckDestroyable()
        {
            var units = _worldContainer.Units.ToArray();
            foreach (var unit in units)
            {
                if (unit.DestroyableComponent.Health <= 0)
                {
                    unit.DestroyableComponent.Destroy();
                    _worldContainer.UnRegisterUnit(unit);
                }
            }

            var bullets = _worldContainer.Bullets.ToArray();
            foreach (var bullet in bullets)
            {
                if (bullet.Destroyable.Health <= 0)
                {
                    bullet.Destroyable.Destroy();
                    _worldContainer.UnRegisterBullet(bullet);
                }
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