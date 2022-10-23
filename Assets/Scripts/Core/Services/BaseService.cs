using System.Collections.Generic;

namespace Asteroids.Core
{
    public interface BaseService<T>
    {
        void Add(T element);
        void Remove(T element);
        List<T> GetElements();
    }
}