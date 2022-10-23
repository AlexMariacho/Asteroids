namespace Asteroids.Core
{
    public interface IAttacker
    {
        BaseWeapon Weapon { get; }
        void Attack(IHealth target);
    }
}