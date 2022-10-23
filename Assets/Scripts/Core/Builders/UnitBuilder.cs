using Asteroids.Utils;
using UnityEngine;

namespace Asteroids.Core
{
    public class UnitBuilder
    {
        private GameWorld _world;
        private UnitSetting _unitSetting;

        public UnitBuilder(GameWorld world, UnitSetting unitSetting)
        {
            _unitSetting = unitSetting;
            _world = world;
        }

        public Entity CreateUnit(UnitType type)
        {
            var entity = _world.GetEntity();
            var information = _unitSetting.GetInformation(type);
            
            foreach (var component in information.Components)
            {
                var cloneComponent = CloneObjectHelper.CreateDeepCopy(component.Value);
                _world.AddComponent(entity, cloneComponent);
            }

            //todo: Unity View has problems when serializing 
            if (information.UnitView != null)
            {
                var view = new UnitViewComponent() { View = GameObject.Instantiate(information.UnitView) };
                _world.AddComponent(entity, view);
            }

            return entity;
        }

    }
    
}