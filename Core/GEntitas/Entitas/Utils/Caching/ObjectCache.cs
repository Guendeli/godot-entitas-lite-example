using System;
using System.Collections.Generic;

namespace GEntitas.Utils {

    public class ObjectCache {

        readonly Dictionary<Type, object> _objectPools;

        public ObjectCache() {
            _objectPools = new Dictionary<Type, object>();
        }

        public ObjectPool<T> GetObjectPool<T>() where T : new() {
            object objectPool;
            var type = typeof(T);
            if (!_objectPools.TryGetValue(type, out objectPool)) {
                objectPool = new ObjectPool<T>(() => new T());
                _objectPools.Add(type, objectPool);
            }

            return ((ObjectPool<T>)objectPool);
        }

        public T Get<T>() where T : new() {
            return GetObjectPool<T>().Get();
        }

        public void Push<T>(T obj) where T : new() {
            GetObjectPool<T>().Push(obj);
        }

        public void RegisterCustomObjectPool<T>(ObjectPool<T> objectPool) {
            _objectPools.Add(typeof(T), objectPool);
        }

        public void Reset() {
            _objectPools.Clear();
        }
    }
}
