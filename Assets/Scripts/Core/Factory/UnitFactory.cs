using System;

namespace Asteroids.Core.Factory
{
    public class UnitFactory
    {
        private UnitSettings _unitSettings;
        private PlayerInputActions _playerInput;

        public UnitFactory(UnitSettings unitSettings, PlayerInputActions playerInput)
        {
            _unitSettings = unitSettings;
            _playerInput = playerInput;
        }

        public T Create<T>(UnitType type) where T : class
        {
            switch (type)
            {
                case UnitType.Player:
                    //if (typeof(T) is Player)
                    {
                        var player = new Player(_unitSettings.PlayerConfiguration, _playerInput);
                        return player as T;
                    }
                    break;
                case UnitType.Asteroid:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return null;
        }
        
    }

    public enum UnitType
    {
        Player,
        Asteroid
    }
}