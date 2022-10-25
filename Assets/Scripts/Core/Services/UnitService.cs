namespace Asteroids.Core
{
    public class UnitService : BaseService<BaseUnit>
    {
        private UnitFactory _factory;

        public UnitService(UnitFactory factory)
        {
            _factory = factory;
            _factory.Created += OnCreated;
        }

        public override void Dispose()
        {
            _factory.Created -= OnCreated;
            _elements.Clear();
        }

        private void OnCreated(BaseUnit source)
        {
            _elements.Add(source);
        }
    }
}