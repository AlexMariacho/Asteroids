using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Core
{
    [Serializable]
    public sealed class GameWorld : IDisposable
    {
        private readonly Dictionary<Type, Object> _allModels = new Dictionary<Type, Object>();
        private readonly Dictionary<Entity, HashSet<IData>> _entities = new Dictionary<Entity, HashSet<IData>>();
        private readonly Dictionary<IData, Entity> _dataOwners = new Dictionary<IData, Entity>();

        public void AddComponent<T>(Entity target, T model) where T : IData
        {
            var type = model.GetType();
            if (!_allModels.ContainsKey(type))
            {
                _allModels[type] = new List<IData>();
            }
            _entities[target].Add(model);
            _dataOwners[model] = target;
        }

        public void RemoveComponent<T>(Entity target, T model) where T : IData
        {
            // var type = model.GetType();
            // if (_allModels.ContainsKey(type))
            // {
            //     _allModels[type].Remove(model);
            // }
            //
            // if (_dataOwners.ContainsKey(model))
            // {
            //     var entity = _dataOwners[model];
            //     if (_entities.ContainsKey(entity))
            //     {
            //         _entities[entity].Remove(model);
            //     }
            //     _dataOwners.Remove(model);
            // }
        }

        public List<T> GetComponents<T>() where T : IData
        {
            var type = typeof(T);
            if (_allModels.ContainsKey(type))
            {
                return _allModels[type] as List<T>;
            }
            return null;
        }
        
        public IEnumerable<(T1, T2)> GetComponents<T1, T2>() 
            where T1 : IData 
            where T2 : IData
        {
            // var type1 = typeof(T1);
            // var type2 = typeof(T2);
            //
            // HashSet<Entity> type1Collection = new HashSet<Entity>();
            // foreach (var data in _allModels[type1])
            // {
            //     type1Collection.Add(_dataOwners[data]);
            // }
            //
            // HashSet<Entity> type2Collection = new HashSet<Entity>();
            // foreach (var data in _allModels[type2])
            // {
            //     type2Collection.Add(_dataOwners[data]);
            // }
            //
            // var intersectEntities = type1Collection.Intersect(type2Collection);
            // List<(T1, T2)> result = 
            // foreach (var entity in intersectEntities)
            // {
            //     (T1, T2) element = new();
            //     element.Item1 = (T1)_entities[entity].First(component => component.GetType() == type1);
            //     element.Item2 = (T2)_entities[entity].First(component => component.GetType() == type2);
            //
            //     result.Add(element);
            // }

            return new List<(T1, T2)>();
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