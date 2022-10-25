using System;

namespace Asteroids.Core.Factory
{
    public abstract class BaseFactory<T1, T2> 
        where T1 : Enum
        where T2 : class
    {
        protected UnitSettings _unitSettings;
        protected WorldContainer _worldContainer;
        
        protected BaseFactory(UnitSettings unitSettings, WorldContainer worldContainer)
        {
            _unitSettings = unitSettings;
            _worldContainer = worldContainer;
        }

        public abstract T2 Create(T1 type);
    }
}