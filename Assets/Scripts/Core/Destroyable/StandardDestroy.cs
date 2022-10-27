using UnityEngine;

namespace Asteroids.Core
{
    public class StandardDestroy : BaseDestroy
    {
        private MonoBehaviour _selfView;

        public StandardDestroy(int health, MonoBehaviour selfView) : base(health)
        {
            _selfView = selfView;
        }

        public override void Destroy()
        {
            GameObject.Destroy(_selfView.gameObject);
            base.Destroy();
        }
    }
}