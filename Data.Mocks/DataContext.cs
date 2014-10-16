using ITCR.Data.Interfaces;
using System;

namespace ITCR.Data.Mocks
{
    public class DataContext : IDataContext
    {
        public System.Data.Entity.IDbSet<Domain.Entities.Citizen> Citizens
        {
            get { throw new NotImplementedException(); }
        }

        public System.Data.Entity.IDbSet<Domain.Entities.Role> Roles
        {
            get { throw new NotImplementedException(); }
        }

        public System.Data.Entity.IDbSet<Domain.Entities.Specie> Species
        {
            get { throw new NotImplementedException(); }
        }

        public void SetModified(object entity)
        {
            throw new NotImplementedException();
        }

        public System.Data.Entity.DbSet<T> Set<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public System.Data.Entity.Infrastructure.DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
