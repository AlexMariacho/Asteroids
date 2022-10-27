using Asteroids.Core.Common;
using UnityEngine;

namespace Asteroids.Core
{
    public class PoolableDestroy : BaseDestroy
    {
        private PoolObject<MonoBehaviour> _bulletPool;
        private MonoBehaviour _selfView;

        public PoolableDestroy(int health, PoolObject<MonoBehaviour> bulletPool, MonoBehaviour selfView) : base(health)
        {
            _bulletPool = bulletPool;
            _selfView = selfView;
        }

        public override void Destroy()
        {
            _bulletPool.ReturnObject(_selfView);
            base.Destroy();
        }
    }
}