using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TI.Repository.API;

namespace TI.Repository
{
    /// <summary>
    /// Abstract Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IRepository<T>
    {
        #region Implementation of IDisposable

        public bool IsDisposed { get; private set; }

        public virtual void Dispose()
        {
            if (IsDisposed)
                throw new ObjectDisposedException("The object has been disposed.");


            IsDisposed = true;
        }

        #endregion

        #region Implementation of IRepository<T>

        public abstract T First();
        public abstract T Last();
        public abstract void Add(T o);
        public abstract void AddRange(IEnumerable<T> objs);
        public abstract void Remove(T obj);
        public abstract void RemoveRange(IEnumerable<T> objs);
        public abstract void RemoveAt(int index);
        public abstract void Clear();
        public abstract bool Contains(T item);
        public abstract IReadOnlyCollection<T> All();
        public abstract IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        public abstract IEnumerable<T> Where(Func<T, bool> predicate);

        #endregion
    }
}