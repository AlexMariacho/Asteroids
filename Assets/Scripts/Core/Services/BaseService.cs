using System;
using System.Collections.Generic;

namespace Asteroids.Core
{
    public abstract class BaseService<T> : IDisposable
    {
        public IEnumerable<T> GetElements => _elements;
        protected List<T> _elements = new List<T>();

        public virtual void Dispose(){ }
    }
}