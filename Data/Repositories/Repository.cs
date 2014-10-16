using ITCR.Data.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using ITCR.Domain.Exceptions;

namespace ITCR.Data.Repositories
{
    /// <summary>
    /// Base class for all the application repositories. Impelements interface IRepository<TEntity> 
    /// The constructor takes a interface for the datacontext, that should be DIed 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {

        private IDataContext _context;
        protected IDataContext Context { get { return _context; } }

        public Repository(IDataContext context)
        {
            _context = context;
        }

        protected abstract IDbSet<TEntity> DbSet { get; }

        public IQueryable<TEntity> All()
        {
            IQueryable<TEntity> result = null;
            try
            {
                result = DbSet.AsQueryable();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> condition)
        {
            IQueryable<TEntity> result = null;
            try
            {
                result = DbSet.Where(condition).AsQueryable();
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public TEntity GetOne(Func<TEntity, bool> condition)
        {
            TEntity result = default(TEntity);
            try
            {
                result =  DbSet.FirstOrDefault(condition);
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public TEntity Add(TEntity entity)
        {
            TEntity result = default(TEntity);
            try
            {
                var newObj = DbSet.Add(entity);
                Context.SaveChanges();
                result = newObj;
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public bool Delete(TEntity entity)
        {
            bool result = false;
            try
            {
                DbSet.Remove(entity);
                Context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public bool Update(TEntity entity)
        {
            bool result = false;
            try
            {
                DbSet.Attach(entity);
                Context.SetModified(entity);
                Context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                BaseException.HandleException(ex);
            }
            return result;
        }

        public int Count
        {
            get
            {
                int result = 0;
                try
                {
                    result = DbSet.Count();
                }
                catch (Exception ex)
                {
                    BaseException.HandleException(ex);
                }
                return result;
            }
        }

    }
}
