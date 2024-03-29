using System.Collections.Generic;
using UnityEngine;

namespace Train.Core
{
    public class PoolObjects<T> where T : PoolObject
    {
        private Stack<T> _stack;
        private T _object;
        private int _initialCapacity;
        private Transform _parent;

        private int _increaseCapacity = 5;

        public PoolObjects(T obj, int initialCapacity, Transform parent)
        {
            _initialCapacity = initialCapacity;
            _object = obj;
            _parent = parent;
            _stack = new (_initialCapacity);
            for (var i = 0; i < _initialCapacity; i++) 
            {
                CreateInstance();
            }
        }

        public T GetObject()
        {
            if(_stack.Count == 0)
            {
                _stack = new(_initialCapacity + _increaseCapacity);
                for (var i = 0; i < _increaseCapacity; i++)
                {
                    CreateInstance();
                }
            }

            return _stack.Pop();
        }

        public void PushObject(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.ClearPlaces();
            _stack.Push(obj);
        }

        private void CreateInstance()
        {
            var instance = GameObject.Instantiate<T>(_object, _parent);
            instance.gameObject.SetActive(false);
            _stack.Push(instance);
        }
    }
}
