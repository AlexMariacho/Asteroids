namespace Asteroids.Core
{
    public interface IWeapon
    {
        void Fire();
        bool IsReload { get; }
    }
}