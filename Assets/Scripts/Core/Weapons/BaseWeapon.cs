namespace Asteroids.Core
{
    public abstract class BaseWeapon : IWeapon
    {
        protected WeaponConfig WeaponConfig;

        public virtual void Attack()
        {
        }
    }
}