using System;
using System.Linq;

namespace ITCR.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> Get(Func<TEntity, bool> condition);
        TEntity GetOne(Func<TEntity, bool> condition);
        TEntity Add(TEntity entity);
        bool Delete(TEntity entity);
        bool Update(TEntity eentity);
        int Count { get;}
        
    }
}
