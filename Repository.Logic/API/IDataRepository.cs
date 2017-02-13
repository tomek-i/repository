using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TIRepository.API
{
    public interface IDataRepository<T>
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties);

        bool Contains(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties);
    }
}