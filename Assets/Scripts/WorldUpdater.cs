namespace Asteroids
{
    public class WorldUpdater
    {
        private WorldContainer _worldContainer;

        public WorldUpdater(WorldContainer worldContainer)
        {
            _worldContainer = worldContainer;
        }

        public void Update()
        {
            foreach (var element in _worldContainer.Movers)
            {
                element.Move();
            }

            foreach (var element in _worldContainer.CheckBorders)
            {
                element.CheckBorder();
            }

            foreach (var element in _worldContainer.PlayerCollisionCheckers)
            {
                element.CheckCollisions();
            }
        }

    }
}