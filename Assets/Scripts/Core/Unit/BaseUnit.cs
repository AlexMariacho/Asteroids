using UnityEngine;

namespace Asteroids.Core
{
    public abstract class BaseUnit : IHealth, IMover, IAttacker, IGameObjectView
    {
        public int Hp { get; private set; }
        public float Speed { get; private set; }
        public Transform Transform { get; private set; }
        public BaseWeapon Weapon { get; private set; }
        public GameObject View { get; private set; }

        public BaseUnit SetHp(int hp)
        {
            Hp = hp;
            return this;
        }

        public BaseUnit SetSpeed(float speed)
        {
            Speed = speed;
            return this;
        }

        public BaseUnit SetWeapon(BaseWeapon weapon)
        {
            Weapon = weapon;
            return this;
        }

        public BaseUnit SetTransform(Transform transform)
        {
            Transform = transform;
            return this;
        }

        public BaseUnit SetView(GameObject gameObject)
        {
            View = gameObject;
            return this;
        }
    }
    
}