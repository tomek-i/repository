using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TI.Repository.API
{
    public interface IRepository<T>:IDisposable
    {
        T First();
        T Last();
        IReadOnlyCollection<T> All();

        void Add(T o);
        void AddRange(IEnumerable<T> objs);
       

        void Remove(T obj);
        void RemoveRange(IEnumerable<T> objs);
        void RemoveAt(int index);

        void Clear();

        bool Contains(T item);
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);

    }
}