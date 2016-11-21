using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TI.Repository.API;

namespace TI.Repository
{
    public abstract class RepositoryStorage<T, TStorage> : IRepository<T> 
        where TStorage : ICollection<T>, new()
    {
        private readonly TStorage _storage;

        protected RepositoryStorage()
        {
            _storage = new TStorage();
        }

        #region Implementation of IDisposable

        public bool IsDisposed { get; private set; }

        public virtual void Dispose()
        {
            if (IsDisposed)
                throw new ObjectDisposedException("The object has been disposed.");

            foreach (IDisposable item in _storage.OfType<IDisposable>())
                item.Dispose();

            Clear();

            IsDisposed = true;
        }

        #endregion

        #region Implementation of IRepository<T>

        public T First()
        {
            return _storage.First();
        }

        public T Last()
        {
            return _storage.Last();
        }

        public virtual void Add(T o)
        {
            var before = _storage.Count;
            _storage.Add(o);
           
        }

        public virtual bool Contains(T item)
        {
            return _storage.Contains(item);
        }

        public virtual void AddRange(IEnumerable<T> objs)
        {
            var before = _storage.Count;
            int i = 0;
            foreach (var obj in objs)
            {
                Add(obj);
                i++;
            }
           
        }

        public virtual void Remove(T obj)
        {
            _storage.Remove(obj);
           
        }

        public virtual void RemoveRange(IEnumerable<T> objs)
        {
            bool removedAll = true;
            foreach (var obj in objs)
            {
                Remove(obj);
                if (removedAll)
                    removedAll = !_storage.Contains(obj);
            }
           
        }

        public virtual void RemoveAt(int index)
        {
            if (index > _storage.Count - 1)
                throw new IndexOutOfRangeException("The index is out of bounds.");
            int i = 0;
            T itemToRemove = default(T);
            foreach (var item in _storage)
            {
                itemToRemove = item;
                if (index == i)
                    break;
                i++;
            }
           
        }

        public virtual void Clear()
        {
            _storage.Clear();
        }

        public virtual IReadOnlyCollection<T> All()
        {
            return new ReadOnlyCollectionBuilder<T>(_storage).ToReadOnlyCollection();
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _storage.Where(predicate.Compile());
        }
        public virtual IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return _storage.Where(predicate);
        }
        #endregion
    }
}