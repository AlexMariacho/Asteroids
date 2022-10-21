using System;

namespace Asteroids.Core
{
    public interface ISystem : IDisposable
    {
        void Initialize(GameWorld world);
        void Update();
    }

}