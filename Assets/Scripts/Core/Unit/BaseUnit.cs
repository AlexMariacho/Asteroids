using UnityEngine;

namespace Asteroids.Core
{
    public abstract class BaseUnit : IHealth, IMover, IAttacker
    {
        public int Hp { get; private set; }
        public float Speed { get; private set; }
        public BaseWeapon Weapon { get; private set; }

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

        public virtual void TakeDamage(uint damage)
        {
        }

        public virtual void Move(Vector2 point, float time)
        {
        }

        public virtual void Attack(IHealth target)
        {
        }
        
    }
    
}