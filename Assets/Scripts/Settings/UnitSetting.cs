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

        private Dictionary<UnitTypeComponent.UnitType, UnitInformation> _typeToInformation =
            new Dictionary<UnitTypeComponent.UnitType, UnitInformation>();

        private void Awake()
        {
            foreach (var unitInformation in _units)
            {
                if (_typeToInformation.ContainsKey(unitInformation.Type))
                {
                    Debug.LogWarning($"Unit Settings contains duplicate |{unitInformation.Type.ToString()}| type!");
                }
                _typeToInformation[unitInformation.Type] = unitInformation;
            }
        }

        public UnitInformation GetInformation(UnitTypeComponent.UnitType type)
        {
            if (_typeToInformation.ContainsKey(type))
            {
                return _typeToInformation[type];
            }
            Debug.LogError($"Unit Settings not contains |{type.ToString()}| type!");
            return null;
        }

        [Serializable]
        public class UnitInformation
        {
            public UnitTypeComponent.UnitType Type;
            public List<SerializableInterface<IData>> Components;
        }
    }
    

}