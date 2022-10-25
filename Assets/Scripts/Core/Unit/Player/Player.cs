namespace Asteroids.Core
{
    public class Player : BaseUnit
    {
        private PlayerInputActions _playerInput;

        public Player()
        {
            _playerInput = new PlayerInputActions();
        }
        
        
    }
}