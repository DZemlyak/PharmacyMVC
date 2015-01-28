using System;
using System.Linq;
using System.Linq.Expressions;
using Pharmacy.Contracts.Entities;

namespace Pharmacy.Contracts.Manager
{
    public interface IManager<T> where T : class, IDbEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(params object[] keys);
        T GetByPrimaryKey(params object[] keys);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
    }
}
