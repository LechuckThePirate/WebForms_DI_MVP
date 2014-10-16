using System;
using System.Collections.Generic;
using System.Linq;
using ITCR.Data.Interfaces;

namespace ITCR.Data.Mocks.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected abstract List<TEntity> MockDbSet {get;}

        public IQueryable<TEntity> All()
        {
            return MockDbSet.AsQueryable();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> condition)
        {
            return MockDbSet.Where(condition).AsQueryable();
        }

        public TEntity GetOne(Func<TEntity, bool> condition)
        {
            return MockDbSet.FirstOrDefault(condition);
        }

        public TEntity Add(TEntity entity)
        {
            MockDbSet.Add(entity);
            return entity;
        }

        public bool Delete(TEntity entity)
        {
            MockDbSet.Remove(entity);
            return true;
        }

        public bool Update(TEntity entity)
        {
            return true;
        }

        public int Count
        {
            get { return MockDbSet.Count(); }
        }
    }
}
