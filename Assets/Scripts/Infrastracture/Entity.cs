namespace Asteroids.Infrastracture
{
    public class Entity
    {
    }

    public static class EntityExtensions
    {
        public static void AddComponent<T>(this Entity target, GameWorld world, T model) where T : IData
        {
            world.AddComponent(target, model);
        }
    }


}