using UnityEngine;

namespace Asteroids.Core
{
    public class AsteroidDestroy : BaseDestroy
    {
        private UnitFactory _unitFactory;
        private MonoBehaviour _selfView;

        public AsteroidDestroy(int health, UnitFactory unitFactory, MonoBehaviour selfView) : base(health)
        {
            _unitFactory = unitFactory;
            _selfView = selfView;
        }

        public override void Destroy()
        {
            CreateSmallAsteroids(3);
            GameObject.Destroy(_selfView.gameObject);
            base.Destroy();
        }

        private void CreateSmallAsteroids(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var smallAsteroid = _unitFactory.Create(UnitType.SmallAsteroid);
                smallAsteroid.View.transform.position = _selfView.transform.position;
            }
        }

    }
}