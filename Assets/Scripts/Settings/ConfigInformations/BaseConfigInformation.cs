using System;
using UnityEngine;

namespace Asteroids.ConfigurationInfo
{
    public class BaseConfigInformation<T1, T2>
        where T1 : Enum
        where T2 : ScriptableObject
    {
        public T1 Type;
        public T2 Config;
    }
}