using Asteroids.Utils;

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
                _world.AddComponent(entity, new UnitViewComponent() { View = information.UnitView.View});
            }

            return entity;
        }

    }
    
}