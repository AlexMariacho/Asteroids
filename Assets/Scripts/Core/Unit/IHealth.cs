namespace Asteroids.Core
{
    public interface IHealth
    {
        int Hp { get; }
        void TakeDamage(uint damage);
    }
}