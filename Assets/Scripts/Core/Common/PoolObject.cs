using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Core
{
    public class PoolObject<T> where T : MonoBehaviour
    {
        public int Count => _objectsList.Count;
        public bool Expandable { get; private set; }
        public Transform ParentObject { get; private set; }
        
        public List<T> ActiveObjects
        {
            get
            {
                var result = new List<T>();
                foreach (var objectPool in _objectsList)
                {
                    if (objectPool.gameObject.activeInHierarchy)
                    {
                        result.Add(objectPool);
                    }
                }

                return result;
            }
        }
        
        private T _prefab;
        private List<T> _objectsList;
        
        public PoolObject(T prefab, int size, Transform parentObject, bool expandable = true)
        {
            _objectsList = new List<T>();

            _prefab = prefab;
            Expandable = expandable;
            ParentObject = parentObject;

            for (var i = 0; i < size; i++)
            {
                Add(prefab);
            }
        }
        
        public T this[int index]
        {
            get { return _objectsList[index]; }
            set { _objectsList[index] = value; }
        }
        
        private void Add(T prefab)
        {
            var newObject = GameObject.Instantiate(prefab, ParentObject);
            if (!string.IsNullOrEmpty(prefab.name))
                newObject.name = $"{prefab.name}_{Count.ToString()}";

            newObject.gameObject.SetActive(false);
            _objectsList.Add(newObject);
        }
        
        public T GetObject(bool autoActivate = true)
        {
            if (_objectsList.Count != 0)
            {
                for (var index = 0; index < _objectsList.Count; index++)
                {
                    var candidate = _objectsList[index];
                    if (candidate == null) continue;
                    if (candidate.gameObject.activeSelf) continue;
                    
                    if (autoActivate)
                        candidate.gameObject.SetActive(true);
                    return candidate;
                }
            }
            
            if (Expandable)
            {
                Add(_prefab);
            }

            return GetObject(autoActivate);
        }
        
        public void ReturnObject(T poolObj)
        {
            if (_objectsList.Contains(poolObj) && poolObj != null && poolObj.gameObject.activeSelf)
            {
                poolObj.gameObject.SetActive(false);
            }
        }
        
        public void ReturnAll()
        {
            foreach (var poolObject in _objectsList)
            {
                ReturnObject(poolObject);
            }
        }

        public void Dispose()
        {
            foreach (var monoBehaviour in _objectsList)
            {
                if (monoBehaviour != null)
                {
                    GameObject.Destroy(monoBehaviour.gameObject);
                }
            }
        }
        
    }
}
