using System;

namespace Asteroids.Core.Factory
{
    public abstract class BaseFactory<T1, T2> 
        where T1 : Enum
        where T2 : class
    {
        public event Action<T2> Created;
        protected UnitSettings _unitSettings;

        protected BaseFactory(UnitSettings unitSettings)
        {
            _unitSettings = unitSettings;
        }

        public abstract T2 Create(T1 type);

        protected void InvokeCreatedEvent(T2 instance)
        {
            Created?.Invoke(instance);
        }
    }
}