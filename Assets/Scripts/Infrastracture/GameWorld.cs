using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Infrastracture
{
    public sealed class GameWorld : IDisposable
    {
        private readonly Dictionary<Type, HashSet<IData>> _allModels = new Dictionary<Type, HashSet<IData>>();
        private readonly Dictionary<Entity, HashSet<IData>> _entities = new Dictionary<Entity, HashSet<IData>>();
        private readonly Dictionary<IData, Entity> _dataOwners = new Dictionary<IData, Entity>();

        public void AddComponent<T>(Entity target, T model) where T : IData
        {
            var type = model.GetType();
            if (!_allModels.ContainsKey(type))
            {
                _allModels[type] = new HashSet<IData>();
            }
            _allModels[type].Add(model);
            _entities[target].Add(model);
            _dataOwners[model] = target;
        }

        public void RemoveComponent<T>(Entity target, T model) where T : IData
        {
            var type = model.GetType();
            if (_allModels.ContainsKey(type))
            {
                _allModels[type].Remove(model);
            }

            if (_dataOwners.ContainsKey(model))
            {
                var entity = _dataOwners[model];
                if (_entities.ContainsKey(entity))
                {
                    _entities[entity].Remove(model);
                }
                _dataOwners.Remove(model);
            }
        }

        public IEnumerable<T> GetComponents<T>() where T : IData
        {
            var type = typeof(T);
            if (_allModels.ContainsKey(type))
            {
                return _allModels[type].Cast<T>();
            }
            return null;
        }

        public Entity GetEntity()
        {
            var entity = new Entity();
            _entities.Add(entity, new HashSet<IData>());
            return entity;
        }

        public Entity GetEntity(params IData[] models)
        {
            var entity = GetEntity();
            foreach (var model in models)
            {
                AddComponent(entity, model);
            }
            return entity;
        }

        public void RemoveEntity(Entity entity)
        {
            if (_entities.ContainsKey(entity))
            {
                foreach (var data in _entities[entity])
                {
                    RemoveComponent(entity, data);
                }

                _entities.Remove(entity);
                entity = null;
            }
        }

        public void Dispose()
        {
            _allModels.Clear();
            _entities.Clear();
            _dataOwners.Clear();
        }
    }
}