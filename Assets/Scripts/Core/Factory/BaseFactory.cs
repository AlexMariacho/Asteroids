using System;
using System.Collections.Generic;
using Asteroids.ConfigurationInfo;
using UnityEngine;

namespace Asteroids.Core
{
    public abstract class BaseFactory<T1, T2, T3> 
        where T1 : Enum
        where T2 : ScriptableObject
        where T3 : class
    {
        public delegate void FactoryCreateHandle(T3 source);
        public event FactoryCreateHandle Created;

        protected IList<BaseConfigInformation<T1, T2>> _settings = new List<BaseConfigInformation<T1, T2>>();
        protected Dictionary<T1, T2> _typeToConfig = new Dictionary<T1, T2>();

        protected BaseFactory(IList<BaseConfigInformation<T1, T2>> settings)
        {
            _settings = settings;
            foreach (var setting in settings)
            {
                _typeToConfig[setting.Type] = setting.Config;
            }
        }

        public abstract T3 CreateUnit(T1 type);

        protected void InvokeCreateEvent(T3 element)
        {
            Created?.Invoke(element);
        }
    }
}