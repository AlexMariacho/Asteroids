using System;
using UnityEngine;

namespace Asteroids.Core
{
    public abstract class BaseFactory<T1, T2> 
        where T1 : Enum
        where T2 : class
    {
        protected UnitSettings UnitSettings;
        protected WorldContainer _worldContainer;
        protected Transform _root;
        
        protected BaseFactory(UnitSettings unitSettings, WorldContainer worldContainer, Transform root)
        {
            UnitSettings = unitSettings;
            _worldContainer = worldContainer;
            _root = root;
        }

        public abstract T2 Create(T1 type);
    }
}