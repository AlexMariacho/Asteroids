namespace Asteroids.Core
{
    public class PlayerService : BaseService<Player>
    {
        private PlayerFactory _factory;

        public PlayerService(PlayerFactory factory)
        {
            _factory = factory;
            _factory.Created += OnCreated;
        }

        public override void Dispose()
        {
            _factory.Created -= OnCreated;
            _elements.Clear();
        }

        private void OnCreated(Player source)
        {
            _elements.Add(source);
        }
    }
}