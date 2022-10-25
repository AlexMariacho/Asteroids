using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.ConfigurationInfo;
using UnityEngine;

namespace Asteroids.Core
{
    public class UnitFactory : BaseFactory<UnitType, UnitConfig, BaseUnit>
    {
        public UnitFactory(IList<UnitInformation> settings) : base(settings.ToArray())
        {
        }

        public override BaseUnit CreateUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.Asteroid:
                    if (_typeToConfig.ContainsKey(type))
                    {
                        var unit = new Asteroid();
                        var config = _typeToConfig[type];
                        var view = GameObject.Instantiate(config.View);
                        unit
                            .SetSpeed(config.MoveSpeed)
                            .SetHp(config.Health)
                            .SetTransform(view.transform)
                            .SetView(view);
                        InvokeCreateEvent(unit);
                    }
                    break;
                case UnitType.Ufo:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            return null;
        }
        
    }

    public enum UnitType
    {
        Asteroid,
        Ufo
    }
}