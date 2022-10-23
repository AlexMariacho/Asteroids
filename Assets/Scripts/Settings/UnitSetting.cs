using System;
using System.Collections.Generic;
using Asteroids.Core;
using TNRD;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "UnitSetting", menuName = "Settings/Unit Setting", order = 0)]
    public class UnitSetting : ScriptableObject
    {
        [SerializeField] private List<UnitInformation> _units = new List<UnitInformation>();
        
        public UnitInformation GetInformation(UnitType type)
        {
            return _units.Find(item => item.Type == type);
        }

        [Serializable]
        public class UnitInformation
        {
            public UnitType Type;
            public GameObject UnitView;
            public List<SerializableInterface<IData>> Components;
        }
    }
    

}