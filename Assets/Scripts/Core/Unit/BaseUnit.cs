namespace Asteroids.Core
{
    public abstract class BaseUnit
    {
        protected UnitConfig _unitConfig;
        
        public IHealth Health { get; }
        public IMover Mover { get; }
        public IAttacker Attacker { get; }
    }
}