using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids.Core
{
    public class PoolObject<T> where T : MonoBehaviour
    {
        public int Count => _allObjects.Count;
        public bool Expandable { get; private set; }

        public HashSet<T> ActiveObjects { get; private set; }
        
        private Transform _rootObject;
        private T _prefab;
        private Queue<T> _allObjects;

        public PoolObject(T prefab, int size, Transform rootObject, bool expandable = true)
        {
            ActiveObjects = new HashSet<T>();
            _allObjects = new Queue<T>();

            _prefab = prefab;
            Expandable = expandable;
            _rootObject = rootObject;

            for (var i = 0; i < size; i++)
            {
                Add(prefab);
            }
        }

        public T GetObject(bool autoActivate = true)
        {
            if (_allObjects.Count > 0)
            {
                var result = _allObjects.Dequeue();
                ActiveObjects.Add(result);
                result.gameObject.SetActive(autoActivate);
                return result;
            }
            
            if (Expandable)
            {
                Add(_prefab);
            }

            return GetObject(autoActivate);
        }

        public void ReturnObject(T poolObj)
        {
            if (ActiveObjects.Contains(poolObj))
            {
                ActiveObjects.Remove(poolObj);
                _allObjects.Enqueue(poolObj);
                poolObj.gameObject.SetActive(false);
            }
        }

        public void ReturnAll()
        {
            var activeObjects = ActiveObjects.ToArray();
            foreach (var activeObject in activeObjects)
            {
                ReturnObject(activeObject);
            }
        }

        public void Dispose()
        {
            foreach (var poolObject in _allObjects)
            {
                if (poolObject != null)
                {
                    GameObject.Destroy(poolObject.gameObject);
                }
            }
            ActiveObjects.Clear();
            _allObjects.Clear();
        }

        private void Add(T prefab)
        {
            var newObject = GameObject.Instantiate(prefab, _rootObject);
            if (!string.IsNullOrEmpty(prefab.name))
                newObject.name = $"{prefab.name}_{Count.ToString()}";

            newObject.gameObject.SetActive(false);
            _allObjects.Enqueue(newObject);
        }
    }
}
